using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_CommerceDTO.DTO.OrderDTO_s
{
    public class OrderCreateDTO
    {
        [Required]
        [MaxLength(30)]
        public required string OrderNumber { get; set; }

        [Range(1, int.MaxValue)]
        public int UserId { get; set; }

        [Range(0.01, 1000000)]
        public decimal TotalAmount { get; set; }

        [Required]
        [MaxLength(500)]
        public required string ShippingAddress { get; set; }
    }
}
