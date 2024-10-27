using CDBCalculator.Interfaces;
using CDBCalculator.Models;

namespace CDBCalculator.Services
{
    public class InvestmentCalculator : IInvestmentCalculator
    {
        private const decimal CDI = 0.009m; 
        private const decimal TB = 1.08m; 

        public InvestmentResult Calcular(InvestmentRequest request)
        {
            decimal valorFinal = request.ValorInicial;

            for (int i = 0; i < request.PrazoMeses; i++)
            {
                valorFinal *= (1 + (CDI * TB));
            }

            decimal imposto = CalcularImposto(valorFinal - request.ValorInicial, request.PrazoMeses);
            decimal valorLiquido = valorFinal - imposto;

            return new InvestmentResult
            {
                ValorBruto = valorFinal,
                ValorLiquido = valorLiquido
            };
        }

        private decimal CalcularImposto(decimal lucro, int prazoMeses)
        {
            decimal aliquota = prazoMeses <= 6 ? 0.225m :
                               prazoMeses <= 12 ? 0.20m :
                               prazoMeses <= 24 ? 0.175m : 0.15m;

            return lucro * aliquota;
        }
    }
}
