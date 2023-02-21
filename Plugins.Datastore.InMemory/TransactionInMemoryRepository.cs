using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.Datastore.InMemory;

public class TransactionInMemoryRepository : ITransactionRepository
{
    private List<Transaction> _transactions= new List<Transaction>();
    public TransactionInMemoryRepository()
    {
        _transactions = new List<Transaction>();
    }
    public IEnumerable<Transaction> GetByDay(DateTime date, string cashierName)
    {
        Console.WriteLine($"Get By Day: cashier name: {cashierName}, date : {date.Date}");
        var transactions = _transactions.Where(x => x.Timestamp.Date == date.Date);
        if (!string.IsNullOrWhiteSpace(cashierName))
        {
            var trans =  _transactions.Where(x => x.Timestamp.Date == date.Date &&
            x.CashierName.Equals(cashierName, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"Trans count: {trans.Count()}");
            return trans;

        }
        return transactions;

    }
    public IEnumerable<Transaction> Get(string cashierName)
    {
        
        if (!string.IsNullOrWhiteSpace(cashierName))
        {
            return _transactions.Where(x =>
            x.CashierName.Equals(cashierName, StringComparison.OrdinalIgnoreCase));

        }
        return _transactions;

    }
    public void Save(string cashierName,int productId, string productName, double price,int beforeQty, int soldQuantity)
    {
        Console.WriteLine($"Cashier: {cashierName}, productId: {productId}, price: {price}, quantity:{soldQuantity}");
        int maxId = 0;
        if (_transactions != null && _transactions.Any())
        {
            maxId = _transactions.Max(x => x.TransactionId);
        }


        _transactions.Add(new Transaction
        {
            ProductId = productId,
            ProductName = productName,
            Price = price,
            BeforeQuantity= beforeQty,
            SoldQuantity = soldQuantity,
            Timestamp = DateTime.UtcNow,
            TransactionId = maxId + 1,
            CashierName = cashierName

        });

        Console.WriteLine($"Transactions count: {_transactions.Count()}");
    }
}