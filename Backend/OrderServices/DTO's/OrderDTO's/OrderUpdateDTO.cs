using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderServices.DTO_s.OrderDTO_s
{
    public class OrderUpdateDTO
    {
        [Required]
        [MaxLength(20)]
        public required string Status { get; set; }

        [Required]
        [MaxLength(500)]
        public required string ShippingAddress { get; set; }
    }
}
