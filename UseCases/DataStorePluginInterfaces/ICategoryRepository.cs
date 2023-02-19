using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;
public interface ICategoryRepository
{
    void AddCategory(Category category);
    IEnumerable<Category> GetCategories();
}
