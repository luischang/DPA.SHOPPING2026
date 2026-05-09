using DPA.SHOPPING.CORE.Core.Entities;
using DPA.SHOPPING.CORE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPA.SHOPPING.CORE.Infrastructure.Repositories
{
    public class CategoryRepository
    {
        private readonly StoreDbContext _context;

        public CategoryRepository(StoreDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id) { 
            return await _context.Category.Where(c=>c.Id == id).FirstOrDefaultAsync();
        }



    }
}
