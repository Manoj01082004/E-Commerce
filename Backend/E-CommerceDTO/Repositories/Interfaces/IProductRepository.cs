using E_CommerceDTO.models;

namespace E_CommerceDTO.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
