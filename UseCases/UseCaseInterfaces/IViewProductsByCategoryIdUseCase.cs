using CoreBusiness;

namespace UseCases.UseCaseInterfaces;
public interface IViewProductsByCategoryIdUseCase
{
    IEnumerable<Product> Execute(int categoryId);
}