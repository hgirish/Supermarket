using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;

public interface IProductRepository
{
    void AddProduct(Product product);
    void DeleteProduct(int productId);
    IEnumerable<Product> GetProducts();
    Product GetProductById(int productId);
    void UpdateProduct(Product product);
    IEnumerable<Product> GetProductsByCategoryId(int categoryId);
}
