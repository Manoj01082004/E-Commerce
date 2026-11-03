using System;
using System.Collections.Generic;
using System.Text;

namespace ProductServices.DTO.ProductDTO_s
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; }

        public int CategoryId { get; set; }

        public required string CategoryName { get; set; }
        public int? AvailableQuantity { get; set; }
    }
}
