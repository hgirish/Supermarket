using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.Datastore.InMemory;
public class CategoryInMemoryRepository : ICategoryRepository
{
    private List<Category> _categories;
    public CategoryInMemoryRepository()
    {
        _categories = new List<Category>()
        {
            new Category{CategoryId = 1, Name = "Beberage", Description="Beverage"},
                        new Category{CategoryId = 1, Name = "Bakery", Description="Bakery"},
            new Category{CategoryId = 1, Name = "Meat", Description="Meat"},

        };
    }
    public IEnumerable<Category> GetCategories()
    {
        return _categories;
    }
}
