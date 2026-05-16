using System;
using System.Collections.Generic;
using System.Text;

namespace DPA.SHOPPING.CORE.Core.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
    }

    public class ProductListDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }

    public class CreateProductDTO
    {
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int CategoryId { get; set; }
    }

    public class UpdateProductDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int CategoryId { get; set; }
    }

    public class DeleteProductDTO
    {
        public int Id { get; set; }
    }
}
