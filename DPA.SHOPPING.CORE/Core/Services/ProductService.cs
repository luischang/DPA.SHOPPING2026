using DPA.SHOPPING.CORE.Core.DTOs;
using DPA.SHOPPING.CORE.Core.Entities;
using DPA.SHOPPING.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.SHOPPING.CORE.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductListDTO>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            var list = new List<ProductListDTO>();
            foreach (var p in products)
            {
                list.Add(new ProductListDTO
                {
                    Id = p.Id,
                    Description = p.Description,
                    Price = p.Price ?? 0,
                    ImageUrl = p.ImageUrl
                });
            }
            return list;
        }

        public async Task<ProductListDTO> GetProductById(int id)
        {
            var p = await _productRepository.GetProductById(id);
            if (p == null) return null;
            return new ProductListDTO
            {
                Id = p.Id,
                Description = p.Description,
                Price = p.Price ?? 0,
                ImageUrl = p.ImageUrl
            };
        }

        public async Task CreateProduct(CreateProductDTO createProductDTO)
        {
            var product = new Product
            {
                Description = createProductDTO.Description,
                ImageUrl = createProductDTO.ImageUrl,
                Stock = createProductDTO.Stock,
                Price = createProductDTO.Price,
                Discount = createProductDTO.Discount,
                CategoryId = createProductDTO.CategoryId,
                IsActive = true
            };
            await _productRepository.CreateProduct(product);
        }

        public async Task UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            var product = await _productRepository.GetProductById(updateProductDTO.Id);
            if (product == null) return;
            product.Description = updateProductDTO.Description;
            product.ImageUrl = updateProductDTO.ImageUrl;
            product.Stock = updateProductDTO.Stock;
            product.Price = updateProductDTO.Price;
            product.Discount = updateProductDTO.Discount;
            product.CategoryId = updateProductDTO.CategoryId;
            await _productRepository.UpdateProduct(product);
        }

        public async Task DeleteProduct(DeleteProductDTO deleteProductDTO)
        {
            var product = await _productRepository.GetProductById(deleteProductDTO.Id);
            if (product == null) return;
            product.IsActive = false;
            await _productRepository.UpdateProduct(product);
        }
    }
}
