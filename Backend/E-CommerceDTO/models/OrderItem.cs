using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceDTO.models
{
    [Index(nameof(OrderId), nameof(ProductId), IsUnique = true)]
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order? Order { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Product? Product { get; set; }

        [Required]
        [MaxLength(200)]
        public required string ProductName { get; set; }

        [Precision(18, 2)]
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}