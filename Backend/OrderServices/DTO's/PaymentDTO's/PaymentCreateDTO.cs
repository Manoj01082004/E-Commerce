using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderServices.DTO_s.PaymentDTO_s
{
    public class PaymentCreateDTO
    {
        [Range(1,int.MaxValue)]
        public int OrderId { get; set; }
        [Required]
        [MaxLength(30)]
        public required string PaymentMethod { get; set; }
    }
}
