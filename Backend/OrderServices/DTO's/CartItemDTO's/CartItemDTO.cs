namespace OrderServices.DTO_s.CartItemDTO_s
{
    public class CartItemDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public string? ProductImageUrl { get; set; }

        public decimal ProductPrice { get; set; }

        public int? AvailableQuantity { get; set; }

        public int Quantity { get; set; }
    }
}