using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;

public interface ITransactionRepository
{
    IEnumerable<Transaction> GetByDay(DateTime date);
    void Save(int productId, double price, int quantity);
}