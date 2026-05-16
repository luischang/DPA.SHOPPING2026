using DPA.SHOPPING.CORE.Core.DTOs;

namespace DPA.SHOPPING.CORE.Core.Interfaces
{
    public interface IProductService
    {
        Task CreateProduct(CreateProductDTO createProductDTO);
        Task DeleteProduct(DeleteProductDTO deleteProductDTO);
        Task<IEnumerable<ProductListDTO>> GetProducts();
        Task<ProductListDTO> GetProductById(int id);
        Task UpdateProduct(UpdateProductDTO updateProductDTO);
    }
}
