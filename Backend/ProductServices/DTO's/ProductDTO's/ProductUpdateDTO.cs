using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductServices.DTO.ProductDTO_s
{
    public class ProductUpdateDTO
    {
        [Required]
        [MaxLength(200)]
        public required string Name { get; set; }

        [MaxLength(2000)]
        public string? Description { get; set; }

        [Range(0.01, 1000000)]
        public decimal Price { get; set; }

        [MaxLength(500)]
        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }
    }
}
