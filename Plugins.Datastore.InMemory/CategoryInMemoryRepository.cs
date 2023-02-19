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
                        new Category{CategoryId = 2, Name = "Bakery", Description="Bakery"},
            new Category{CategoryId = 3, Name = "Meat", Description="Meat"},

        };
    }

    public void AddCategory(Category category)
    {
        if (_categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase)))
        {
            return;
        }
        int maxId = 0;
        if (_categories != null && _categories.Count() > 0)
        {
            maxId = _categories.Max(x => x.CategoryId);
        }
         
        category.CategoryId = maxId + 1;
        _categories.Add(category);
    }

    public void DeleteCategory(int categoryId)
    {
        var categoryToDelete = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
        if (categoryToDelete == null)
        {
            return;
        }
        _categories.Remove(categoryToDelete);
    }

    public IEnumerable<Category> GetCategories()
    {
        return _categories;
    }

    public Category GetCategoryById(int categoryId)
    {
        return _categories?.FirstOrDefault(x => x.CategoryId == categoryId) ?? new();

    }

    public void UpdateCategory(Category category)
    {
        var categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);

        if (categoryToUpdate != null)
        {
            if (_categories.Any(x=>x.Name == category.Name && x.CategoryId != category.CategoryId))
            {
                return;
            }
            categoryToUpdate.Description = category.Description;
            categoryToUpdate.Name = category.Name;
        }
    }
}
