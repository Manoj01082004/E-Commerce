using System;
using System.Collections.Generic;
using System.Text;

namespace ProductServices.DTO.CategoryDTO_s
{
    public class CategoryCreateAndUpdateDTO
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
