using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.CashierConsoleUseCases;

public class SellProductUseCase : ISellProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IRecordTransactionUseCase _recordTransactionUseCase;

    public SellProductUseCase(IProductRepository productRepository,
        IRecordTransactionUseCase recordTransactionUseCase)
    {
        _productRepository = productRepository;
        _recordTransactionUseCase = recordTransactionUseCase;
    }
    public void Execute(string cashierName, int productId, int quantityToSell)
    {
        var product = _productRepository.GetProductById(productId);
        if (product == null) { return; }
        _recordTransactionUseCase.Execute(cashierName, productId, quantityToSell);

        product.Quantity -= quantityToSell;

        _productRepository.UpdateProduct(product);

    }
}
