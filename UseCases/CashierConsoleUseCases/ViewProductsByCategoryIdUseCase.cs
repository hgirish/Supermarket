using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.CashierConsoleUseCases;

public class ViewProductsByCategoryIdUseCase : IViewProductsByCategoryIdUseCase
{
    private readonly IProductRepository _productRepository;

    public ViewProductsByCategoryIdUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public IEnumerable<Product> Execute(int categoryId)
    {
        return _productRepository.GetProductsByCategoryId(categoryId);
    }
}
