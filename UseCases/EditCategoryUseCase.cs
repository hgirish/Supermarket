using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases;

public class EditCategoryUseCase : IEditCategoryUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public EditCategoryUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public void Execute(Category category)
    {
        _categoryRepository.UpdateCategory(category);
    }
}