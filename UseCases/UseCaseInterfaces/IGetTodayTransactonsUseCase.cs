using CoreBusiness;

namespace UseCases.UseCaseInterfaces;
public interface IGetTodayTransactonsUseCase
{
    IEnumerable<Transaction> Execute(string cashierName = "");
}