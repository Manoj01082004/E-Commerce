using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductServices.DTO.InventoryDTO_s
{
    public class InventoryCreateDTO
    {
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }

        [Range(0, int.MaxValue)]
        public int QuantityOnHand { get; set; }

        [Range(0, int.MaxValue)]
        public int ReservedQuantity { get; set; }

        [Range(0, int.MaxValue)]
        public int ReorderLevel { get; set; }
    }
}
