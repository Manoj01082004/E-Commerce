using E_CommerceDTO.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceDTO.DTO.CartItemDTO_s
{
    public class CartItemDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }

        public int Quantity { get; set; } = 1;
    }
}
