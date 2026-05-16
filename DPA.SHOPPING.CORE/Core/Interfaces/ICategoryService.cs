using DPA.SHOPPING.CORE.Core.DTOs;

namespace DPA.SHOPPING.CORE.Core.Interfaces
{
    public interface ICategoryService
    {
        Task CreateCategory(CreateCategoryDTO createCategoryDTO);
        Task DeleteCategory(DeleteCategoryDTO deleteCategoryDTO);
        Task<IEnumerable<CategoryListDTO>> GetCategories();
        Task<CategoryListDTO> GetCategoryById(int id);
        Task UpdateCategory(UpdateCategoryDTO updateCategoryDTO);
    }
}