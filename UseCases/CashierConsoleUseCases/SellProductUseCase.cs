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

public class RecordTransactionUseCase
{
    
    private readonly ITransactionRepository _transactionRepository;
    private readonly IGetProductByIdUseCase _getProductByIdUseCase;

    public RecordTransactionUseCase(ITransactionRepository transactionRepository,
        IGetProductByIdUseCase getProductByIdUseCase)
    {
        
        _transactionRepository = transactionRepository;
        _getProductByIdUseCase = getProductByIdUseCase;
    }

    public void Execute(int productId, int quantity)
    {
        var product = _getProductByIdUseCase.Execute(productId);
        if (product == null) { return; }
        var price = product!.Price!.Value ;
        _transactionRepository.Save(productId, price,quantity);
    }
}