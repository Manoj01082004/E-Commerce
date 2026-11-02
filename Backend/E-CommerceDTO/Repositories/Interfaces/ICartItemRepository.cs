using E_CommerceDTO.models;

namespace E_CommerceDTO.Repositories.Interfaces
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
