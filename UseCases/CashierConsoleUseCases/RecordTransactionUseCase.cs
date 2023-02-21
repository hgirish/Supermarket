using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.CashierConsoleUseCases;

public class RecordTransactionUseCase : IRecordTransactionUseCase
{

    private readonly ITransactionRepository _transactionRepository;
    private readonly IGetProductByIdUseCase _getProductByIdUseCase;

    public RecordTransactionUseCase(ITransactionRepository transactionRepository,
        IGetProductByIdUseCase getProductByIdUseCase)
    {

        _transactionRepository = transactionRepository;
        _getProductByIdUseCase = getProductByIdUseCase;
    }

    public void Execute(string cashierName, int productId, int quantity)
    {
        var product = _getProductByIdUseCase.Execute(productId);
        if (product == null) { return; }
        var price = product!.Price!.Value;
        _transactionRepository.Save(cashierName, productId, product.Name, price,product.Quantity.Value, quantity);
    }
}
