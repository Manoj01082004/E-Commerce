using OrderServices.Models;

namespace OrderServices.Repository.Interfaces
{
    public interface ICartItemRepository
    {
        Task<ICollection<CartItem>> GetCartItemsByUserIdAsync(int userId);
        Task<CartItem?> GetCartItemByIdAsync(int id);
        Task<CartItem?> GetCartItemByUserAndProductAsync(int userId, int productId);
        Task AddCartItemAsync(CartItem cartItem);
        Task UpdateCartItemAsync(CartItem cartItem);
        Task DeleteCartItemAsync(int id);
        Task ClearCartItemAsync(int userId);
    }
}
