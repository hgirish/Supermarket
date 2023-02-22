using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;

public interface ITransactionRepository
{
    IEnumerable<Transaction> GetByDay( DateTime date, string cashierName);
    IEnumerable<Transaction> Get(string cashierName);
    void Save(string cashierName, int productId, string productName, double price, int beforequantity, int soldQty);
    IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate);
}