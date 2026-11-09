using ProductServices.Models;

namespace ProductServices.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetAllProductsAsync();
        Task<ICollection<Product>> SearchProductsAsync(string? searchQuery);
        Task<Product?> GetProductByIdAsync(int id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
