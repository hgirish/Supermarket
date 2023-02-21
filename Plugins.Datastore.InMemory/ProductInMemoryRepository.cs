using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.Datastore.InMemory;

public class ProductInMemoryRepository : IProductRepository
{
    private List<Product> _products = new List<Product>();
    public ProductInMemoryRepository()
    {
        _products = new List<Product>
        {
            new Product{ProductId =1, CategoryId=1, Name = "Iced Tea", Price = 1.99, Quantity = 100},
            new Product{ProductId =2, CategoryId=1, Name = "Canada Dy", Price = 1.99, Quantity = 200},
         new Product{ProductId =3, CategoryId=2, Name = "Whole Wheat Bread", Price = 1.50, Quantity = 300},
            new Product{ProductId =4, CategoryId=2, Name = "White Bread", Price = 1.50, Quantity = 300},


        };
    }
    public void AddProduct(Product product)
    {
        if (_products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
        {
            return;
        }
        int maxId = 0;
        if (_products != null && _products.Count() > 0)
        {
            maxId = _products.Max(x => x.ProductId);
        }

        product.ProductId = maxId + 1;
        _products.Add(product);
    }

    public void DeleteProduct(int productId)
    {
        var productToDelete = GetProductById(productId);
        if (productToDelete == null)
        {
            return;
        }
        _products.Remove(productToDelete);
    }

    public Product GetProductById(int productId)
    {
        return _products?.FirstOrDefault(x => x.ProductId == productId) ?? new();
    }

    public IEnumerable<Product> GetProducts()
    {
        return _products;
    }

    public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
    {
        return _products.Where(x=> x.CategoryId == categoryId);
    }

    public void UpdateProduct(Product product)
    {
        var productToUpdate = GetProductById(product.ProductId);
        if (productToUpdate != null)
        {
            productToUpdate.Price = product.Price;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.Name = product.Name;
            productToUpdate.Quantity = product.Quantity;
        }
    }
}

public class TransactionInMemoryRepository : ITransactionRepository
{
    public IEnumerable<Transaction> GetByDay(DateTime date)
    {
        throw new NotImplementedException();
    }

    public void Save(int productId, double price, int quantity)
    {
        throw new NotImplementedException();
    }
}