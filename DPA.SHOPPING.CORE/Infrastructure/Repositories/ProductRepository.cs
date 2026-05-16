using DPA.SHOPPING.CORE.Core.Entities;
using DPA.SHOPPING.CORE.Core.Interfaces;
using DPA.SHOPPING.CORE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPA.SHOPPING.CORE.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _context;

        public ProductRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Product.Where(p => p.IsActive == true).ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Product.Where(p => p.Id == id && p.IsActive == true).FirstOrDefaultAsync();
        }

        public async Task CreateProduct(Product product)
        {
            product.IsActive = true;
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            var existing = await _context.Product.FindAsync(product.Id);
            if (existing != null)
            {
                existing.Description = product.Description;
                existing.ImageUrl = product.ImageUrl;
                existing.Stock = product.Stock;
                existing.Price = product.Price;
                existing.Discount = product.Discount;
                existing.CategoryId = product.CategoryId;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var existing = await _context.Product.FindAsync(id);
            if (existing != null)
            {
                existing.IsActive = false;
            }
            await _context.SaveChangesAsync();
        }
    }
}
