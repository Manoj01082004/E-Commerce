using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceDTO.models
{
    [Index(nameof(ProductId), IsUnique = true)]
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }

        public int QuantityOnHand { get; set; }

        public int ReservedQuantity { get; set; }

        public int ReorderLevel { get; set; } = 10;

        public DateTime? LastRestockedAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; } = System.Array.Empty<byte>();

        [NotMapped]
        public int AvailableQuantity => QuantityOnHand - ReservedQuantity;
    }
}
