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
        throw new NotImplementedException();
    }

    public void DeleteProduct(int productId)
    {
        throw new NotImplementedException();
    }

    public Product GetProductById(int productId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetProducts()
    {
        return _products;
    }

    public void UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }
}