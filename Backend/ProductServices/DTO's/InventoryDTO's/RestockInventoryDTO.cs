using System.ComponentModel.DataAnnotations;

namespace ProductServices.DTO.InventoryDTO_s
{
    public class RestockInventoryDTO
    {
        [Range(1, int.MaxValue)]
        public int QuantityToAdd { get; set; }
    }
}