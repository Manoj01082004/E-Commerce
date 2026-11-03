using System;
using System.Collections.Generic;
using System.Text;

namespace OrderServices.DTO_s.PaymentDTO_s
{
    public class PaymentDTO
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public decimal Amount { get; set; }

        public required string PaymentMethod { get; set; }

        public required string Status { get; set; }

        public string? TransactionId { get; set; }

        public DateTime? PaidAt { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
