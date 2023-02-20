using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.CashierConsoleUseCases;

public class SellProductUseCase : ISellProductUseCase
{
    private readonly IProductRepository _productRepository;

    public SellProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public void Execute(int productId, int quantityToSell)
    {
        var product = _productRepository.GetProductById(productId);
        if (product == null) { return; }
        product.Quantity -= quantityToSell;

        _productRepository.UpdateProduct(product);
    }
}