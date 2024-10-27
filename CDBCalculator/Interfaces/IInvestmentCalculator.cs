using CDBCalculator.Models;

namespace CDBCalculator.Interfaces
{
    public interface IInvestmentCalculator
    {
        InvestmentResult Calcular(InvestmentRequest request);
    }
}
