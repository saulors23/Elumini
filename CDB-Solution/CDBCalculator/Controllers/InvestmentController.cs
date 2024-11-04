using CDBCalculator.Interfaces;
using CDBCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace CDBCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentCalculator _calculator;

        public InvestmentController(IInvestmentCalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpPost("calcular")]
        public IActionResult Calcular([FromBody] InvestmentRequest request)
        {
            if (request.ValorInicial <= 0 || request.PrazoMeses <= 1)
            {
                return BadRequest("O Valor inicial deve ser positivo e prazo maior que 1.");
            }

            var result = _calculator.Calcular(request);
            return Ok(result);
        }
    }
}
