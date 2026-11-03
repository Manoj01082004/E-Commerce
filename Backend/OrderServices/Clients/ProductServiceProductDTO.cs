
namespace OrderServices.Clients
{
    public class ProductServiceProductDTO
    {
        public int ProductId { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; }

        public int CategoryId { get; set; }

        public int AvailableQuantity { get; set; }
    }
}
