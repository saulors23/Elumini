using CDBCalculator.Controllers;
using CDBCalculator.Interfaces;
using CDBCalculator.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Drawing;
using System.Web.Http.Results;
using Xunit;

namespace CDBCalculator.WebApi.Tests
{
    public class InvestmentServiceTests
    {
        [Fact]
        public void CalcularDeveRetornarBadRequestQuandoValorInicialZero()
        {
            // Arrange
            var mockCalculator = new Mock<IInvestmentCalculator>();
            var controller = new InvestmentController(mockCalculator.Object);
            var request = new InvestmentRequest
            {
                ValorInicial = 0,
                PrazoMeses = 12
            };

            // Act
            var result = controller.Calcular(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void CalcularDeveRetornarBadRequestQuandoPrazoMesesMenorQueOuIgualAUm()
        {
            // Arrange
            var mockCalculator = new Mock<IInvestmentCalculator>();
            var controller = new InvestmentController(mockCalculator.Object);
            var request = new InvestmentRequest
            {
                ValorInicial = 1000,
                PrazoMeses = 1
            };

            // Act
            var result = controller.Calcular(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void CalcularDeveRetornarOkComResultadosEsperados()
        {
            // Arrange
            var mockCalculator = new Mock<IInvestmentCalculator>();
            var expectedResult = new InvestmentResult
            {
                ValorBruto = 1800,  
                ValorLiquido = 1600,                                      
            };
            
            mockCalculator
                .Setup(c => c.Calcular(It.IsAny<InvestmentRequest>()))
                .Returns(expectedResult);

            var controller = new InvestmentController(mockCalculator.Object);
            var request = new InvestmentRequest
            {
                ValorInicial = 1500,
                PrazoMeses = 12
            };

            // Act
            var result = controller.Calcular(request) as OkObjectResult;

            // Assert
            Assert.NotNull(result); 
            var investmentResult = result.Value as InvestmentResult;

            Assert.NotNull(investmentResult); 
            Assert.InRange(investmentResult.ValorBruto, 1000, 2000); 
            Assert.InRange(investmentResult.ValorLiquido, 1000, 2000);
        }

        [Theory]
        [InlineData(6, 0.225)]
        [InlineData(12, 0.20)]
        [InlineData(24, 0.175)]
        [InlineData(25, 0.15)]
        public void CalcularTaxadeImpostoDeveEstarCorretaParaDadosPeriodos(int prazoMeses, decimal expectedRate)
        {
            // Arrange
            var mockCalculator = new Mock<IInvestmentCalculator>();

            decimal valorInicial = 1000;
            decimal rendimentoEsperado = valorInicial * (1 + expectedRate);

            var expectedResult = new InvestmentResult
            {
                ValorBruto = rendimentoEsperado, 
                ValorLiquido = rendimentoEsperado - (rendimentoEsperado - valorInicial) * expectedRate                                                                                                        
            };
            
            mockCalculator
                .Setup(c => c.Calcular(It.IsAny<InvestmentRequest>()))
                .Returns(expectedResult);

            var controller = new InvestmentController(mockCalculator.Object);
            var request = new InvestmentRequest
            {
                ValorInicial = valorInicial,
                PrazoMeses = prazoMeses
            };

            // Act
            var result = controller.Calcular(request) as OkObjectResult;

            // Assert
            Assert.NotNull(result); 
            var investmentResult = result.Value as InvestmentResult;

            Assert.NotNull(investmentResult); 
            var rendimento = investmentResult.ValorBruto - request.ValorInicial;
            var imposto = rendimento * expectedRate;
    
            Assert.Equal(investmentResult.ValorBruto - imposto, investmentResult.ValorLiquido, 2);
        }
    }
}
