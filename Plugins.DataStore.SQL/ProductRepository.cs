using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL;

public class ProductRepository : IProductRepository
{
    private readonly MarketContext _db;
    public ProductRepository(MarketContext db)
    {
        _db = db;
    }

    public void AddProduct(Product product)
    {
        _db.Products.Add(product);
        _db.SaveChanges();
    }

    public void DeleteProduct(int productId)
    {
        var product = GetProductById(productId);
        if (product != null)
        {
            _db.Products.Remove(product);
            _db.SaveChanges(); 
        }
    }

    public Product GetProductById(int productId)
    {
        return _db.Products.Find(productId);
    }

    public IEnumerable<Product> GetProducts()
    {
        return _db.Products;
    }

    public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
    {
        return _db.Products.Where(x => x.CategoryId == categoryId);
    }

    public void UpdateProduct(Product product)
    {
        var prod = GetProductById(product.ProductId);
        if (prod != null)
        {
            prod.Price = product.Price;
            prod.Quantity = product.Quantity;
            prod.Name = product.Name;
            prod.Description = product.Description;
            prod.CategoryId = product.CategoryId;

            _db.SaveChanges();
        }
    }
}
