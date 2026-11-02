using E_CommerceDTO.models;
using E_CommerceDTO.Repositories;
using E_CommerceDTO.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceBTO.Services
{
    public class CartItemService
    {
        private readonly ICartItemRepository _repo;
        public CartItemService(ICartItemRepository repo)
        {
            _repo = repo;   
        }
        public async Task<ICollection<CartItem>> GetCartItemsByUserIdAsync(int userId)
        {
            return await _repo.GetCartItemsByUserIdAsync(userId);
        }
        public async Task<CartItem?> GetCartItemByIdAsync(int id)
        {
            return await _repo.GetCartItemByIdAsync(id);
        }
        public async Task<CartItem> AddCartItemAsync(CartItem cartItem)
        {
            var existingCartItem = await _repo.GetCartItemByUserAndProductAsync(cartItem.UserId,cartItem.ProductId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += cartItem.Quantity;
                existingCartItem.UpdatedAt = DateTime.UtcNow;

                await _repo.UpdateCartItemAsync(existingCartItem);

                return existingCartItem;
            }

            cartItem.CreatedAt = DateTime.UtcNow;

            await _repo.AddCartItemAsync(cartItem);

            return cartItem;
        }
        public async Task UpdateCartItemAsync(CartItem cartItem)
        {
            await _repo.UpdateCartItemAsync(cartItem);
        }
        public async Task<bool> DeleteCartItemAsync(int id)
        {
            var existingCartItem = await _repo.GetCartItemByIdAsync(id);
            if (existingCartItem == null)
            {
                return false;
            }
            await _repo.DeleteCartItemAsync(id);
            return true;
        }
        public async Task<bool> ClearCartItemAsync(int userId)
        {
            var cartItems = await _repo.GetCartItemsByUserIdAsync(userId);
            if (cartItems == null || !cartItems.Any())
            {
                return false;
            }
            await _repo.ClearCartItemAsync(userId);
            return true;
        }

    }
}
