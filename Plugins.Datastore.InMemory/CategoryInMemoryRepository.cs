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
            new Category{CategoryId = 1, Name = "Beverage", Description="Beverage"},
                        new Category{CategoryId = 1, Name = "Bakery", Description="Bakery"},
            new Category{CategoryId = 1, Name = "Meat", Description="Meat"},

        };
    }

    public void AddCategory(Category category)
    {
        if (_categories.Any(x=>x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase)))
        {
            return;
        }
        var maxId = _categories.Max(x => x.CategoryId);
        category.CategoryId = maxId + 1;
        _categories.Add(category);
    }

    public IEnumerable<Category> GetCategories()
    {
        return _categories;
    }
}
