
using OrderServices.Clients;
using OrderServices.Models;
using OrderServices.Repository.Interfaces;

namespace OrderServices.Services
{
    public class CartItemService
    {
        private readonly ICartItemRepository _repo;
        private readonly ProductServiceClient _productServiceClient;

        public CartItemService(
            ICartItemRepository repo,
            ProductServiceClient productServiceClient)
        {
            _repo = repo;
            _productServiceClient = productServiceClient;
        }

        public async Task<ICollection<CartItem>> GetCartItemsByUserIdAsync(
            int userId)
        {
            return await _repo.GetCartItemsByUserIdAsync(userId);
        }

        public async Task<CartItem?> GetCartItemByIdAsync(int id)
        {
            return await _repo.GetCartItemByIdAsync(id);
        }

        public async Task<CartItem?> AddCartItemAsync(CartItem cartItem)
        {
            var product = await _productServiceClient
                .GetProductByIdAsync(cartItem.ProductId);

            if (product is null || !product.IsActive)
            {
                return null;
            }

            var existingCartItem = await _repo
                .GetCartItemByUserAndProductAsync(
                    cartItem.UserId,
                    cartItem.ProductId);

            if (existingCartItem is not null)
            {
                var newQuantity =
                    existingCartItem.Quantity + cartItem.Quantity;

                if (newQuantity > product.AvailableQuantity)
                {
                    throw new InvalidOperationException(
                        "Out of stock, please reduce the quantity or remove the item.");
                }

                existingCartItem.Quantity = newQuantity;
                existingCartItem.UpdatedAt = DateTime.UtcNow;

                await _repo.UpdateCartItemAsync(existingCartItem);

                return existingCartItem;
            }

            if (cartItem.Quantity > product.AvailableQuantity)
            {
                throw new InvalidOperationException(
                    "Out of stock, please reduce the quantity or remove the item.");
            }

            cartItem.CreatedAt = DateTime.UtcNow;

            await _repo.AddCartItemAsync(cartItem);

            return cartItem;
        }

        public async Task<bool> UpdateCartItemAsync(
            int userId,
            int cartItemId,
            int quantity)
        {
            var cartItem = await _repo.GetCartItemByIdAsync(cartItemId);

            if (cartItem is null || cartItem.UserId != userId)
            {
                return false;
            }

            var product = await _productServiceClient
                .GetProductByIdAsync(cartItem.ProductId);

            if (product is null || !product.IsActive)
            {
                throw new InvalidOperationException(
                    "Product is not available.");
            }

            if (quantity > product.AvailableQuantity)
            {
                throw new InvalidOperationException(
                    "Out of stock, please reduce the quantity or remove the item.");
            }

            cartItem.Quantity = quantity;
            cartItem.UpdatedAt = DateTime.UtcNow;

            await _repo.UpdateCartItemAsync(cartItem);

            return true;
        }

        public async Task<bool> DeleteCartItemAsync(
            int userId,
            int cartItemId)
        {
            var existingCartItem = await _repo.GetCartItemByIdAsync(cartItemId);

            if (existingCartItem is null ||
                existingCartItem.UserId != userId)
            {
                return false;
            }

            await _repo.DeleteCartItemAsync(cartItemId);

            return true;
        }

        public async Task<bool> ClearCartItemAsync(int userId)
        {
            var cartItems = await _repo.GetCartItemsByUserIdAsync(userId);

            if (!cartItems.Any())
            {
                return false;
            }

            await _repo.ClearCartItemAsync(userId);

            return true;
        }
    }
}