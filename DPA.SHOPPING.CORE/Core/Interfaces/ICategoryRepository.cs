using DPA.SHOPPING.CORE.Core.Entities;

namespace DPA.SHOPPING.CORE.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task CreateCategory(Category category);
        Task DeleteCategory(int id);
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
        Task UpdateCategory(Category category);
    }
}