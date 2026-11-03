using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderServices.DTO_s.PaymentDTO_s
{
    public class PaymentCompleteDTO
    {
        [Required]
        [MaxLength(100)]
        public required string TransactionId { get; set; }
    }
}
