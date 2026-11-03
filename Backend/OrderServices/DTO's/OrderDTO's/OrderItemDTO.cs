namespace OrderServices.DTO_s.OrderDTO_s
{
    public class OrderItemDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public required string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}
