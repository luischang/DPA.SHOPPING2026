using DPA.SHOPPING.CORE.Core.Entities;
using DPA.SHOPPING.CORE.Core.Interfaces;
using DPA.SHOPPING.CORE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPA.SHOPPING.CORE.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _context;

        public CategoryRepository(StoreDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Category.Where(c => c.IsActive == true).ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Category.Where(c => c.Id == id && c.IsActive == true).FirstOrDefaultAsync();
        }

        // Create category
        public async Task CreateCategory(Category category)
        {
            category.IsActive = true;
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
        }
        // Update category
        public async Task UpdateCategory(Category category)
        {
            // Check if the category exists
            var existingCategory = await _context.Category.FindAsync(category.Id);
            if (existingCategory != null)
            {
                existingCategory.Description = category.Description;
            }
            await _context.SaveChangesAsync();
        }

        //Delete logic category
        public async Task DeleteCategory(int id)
        {
            var existingCategory = await _context.Category.FindAsync(id);
            if (existingCategory != null)
            {
                existingCategory.IsActive = false;
            }
            await _context.SaveChangesAsync();
        }

    }
}
