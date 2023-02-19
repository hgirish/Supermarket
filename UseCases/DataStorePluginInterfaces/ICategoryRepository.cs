using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;
public interface ICategoryRepository
{
    void AddCategory(Category category);
    IEnumerable<Category> GetCategories();
    Category GetCategoryById(int categoryId);
    void UpdateCategory(Category category);
}
