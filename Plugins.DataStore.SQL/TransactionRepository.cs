using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL;

public class TransactionRepository : ITransactionRepository
{
    private readonly MarketContext _db;

    public TransactionRepository(MarketContext db)
    {
        _db = db;
    }
    public IEnumerable<Transaction> Get(string cashierName)
    {
        if (string.IsNullOrEmpty(cashierName))
        {
            return _db.Transactions;
        }
        else
        {
            return _db.Transactions.Where(x=> x.CashierName.ToLower() == cashierName.ToLower());
        }
    }

    public IEnumerable<Transaction> GetByDay(DateTime date, string cashierName)
    {
        if (string.IsNullOrEmpty(cashierName))
        {
            return _db.Transactions.Where(x=>x.Timestamp.Date == date.Date);
        }
        else
        {
            return _db.Transactions.Where(x => 
            x.CashierName.ToLower() == cashierName.ToLower() &&
                x.Timestamp.Date == date.Date);
        }
    }

    public void Save(string cashierName, int productId, string productName,
        double price, int beforequantity, int soldQty)
    {
        _db.Transactions.Add(
            new Transaction
            {
                BeforeQuantity = beforequantity,
                CashierName = cashierName,
                Price = price,
                ProductId = productId,
                ProductName = productName,
                SoldQuantity = soldQty,
                Timestamp = DateTime.UtcNow
            });
        _db.SaveChanges();
    }

    public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
    {
        var transactions = _db.Transactions.Where(x=>
        x.Timestamp.Date >= startDate.Date &&
        x.Timestamp.Date <= endDate.AddDays(1).Date);  

        if (string.IsNullOrEmpty(cashierName))
        {
            return transactions;
        }
        else
        {
            return transactions.Where(x => x.CashierName.ToLower() == cashierName.ToLower());
        }
    }
}