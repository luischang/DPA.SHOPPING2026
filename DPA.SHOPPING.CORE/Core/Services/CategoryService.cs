using DPA.SHOPPING.CORE.Core.DTOs;
using DPA.SHOPPING.CORE.Core.Entities;
using DPA.SHOPPING.CORE.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPA.SHOPPING.CORE.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryListDTO>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            var categoryListDTOs = new List<CategoryListDTO>();
            foreach (var category in categories)
            {
                var categoryListDTO = new CategoryListDTO();
                categoryListDTO.Id = category.Id;
                categoryListDTO.Description = category.Description;
                categoryListDTOs.Add(categoryListDTO);
            }
            return categoryListDTOs;
        }

        public async Task<CategoryListDTO> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return null;
            }
            var categoryListDTO = new CategoryListDTO();
            categoryListDTO.Id = category.Id;
            categoryListDTO.Description = category.Description;
            return categoryListDTO;
        }


        public async Task CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            var category = new Category();
            category.Description = createCategoryDTO.Description;
            category.IsActive = true;
            await _categoryRepository.CreateCategory(category);
        }

        public async Task UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            var category = await _categoryRepository.GetCategoryById(updateCategoryDTO.Id);
            if (category == null)
            {
                return;
            }
            category.Description = updateCategoryDTO.Description;
            await _categoryRepository.UpdateCategory(category);
        }

        public async Task DeleteCategory(DeleteCategoryDTO deleteCategoryDTO)
        {
            var category = await _categoryRepository.GetCategoryById(deleteCategoryDTO.Id);
            if (category == null)
            {
                return;
            }
            category.IsActive = false;
            await _categoryRepository.UpdateCategory(category);
        }
    }
}