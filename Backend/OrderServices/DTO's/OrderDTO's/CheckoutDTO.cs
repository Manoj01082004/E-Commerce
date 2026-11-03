using System.ComponentModel.DataAnnotations;

namespace OrderServices.DTO_s.OrderDTO_s
{
    public class CheckoutDTO
    {
        [Required]
        [MaxLength(500)]
        public required string ShippingAddress { get; set; }
    }
}
