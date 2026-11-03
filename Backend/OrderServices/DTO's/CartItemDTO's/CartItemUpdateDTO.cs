using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderServices.DTO_s.CartItemDTO_s
{
    public class CartItemUpdateDTO
    {
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; } = 1;
    }
}
