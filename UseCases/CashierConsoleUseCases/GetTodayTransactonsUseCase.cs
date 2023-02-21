using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.CashierConsoleUseCases;

public class GetTodayTransactonsUseCase : IGetTodayTransactonsUseCase
{
    private readonly ITransactionRepository _transactionRepository;

    public GetTodayTransactonsUseCase(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }
    public IEnumerable<Transaction> Execute(string cashierName = "")
    {
        Console.WriteLine($"GetTodayTransactonsUseCase : cashierName: {cashierName}");
        return _transactionRepository.GetByDay(DateTime.UtcNow, cashierName);
    }
}