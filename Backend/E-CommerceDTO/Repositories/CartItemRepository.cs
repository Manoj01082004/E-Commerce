using E_CommerceDTO.Context;
using E_CommerceDTO.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceDTO.Repositories
{
    public class CartItemRepository
    {
        private readonly ECommerceDBContext _db;
        public CartItemRepository(ECommerceDBContext db)
        {
            _db = db;
        }
        public async Task<ICollection<CartItem>> GetCartItemsByUserIdAsync(int userId)
        {
            return await _db.CartItems
                .Where(ci => ci.UserId == userId)
                .Include(ci => ci.Product)
                .ToListAsync();
        }
        public async Task<CartItem?> GetCartItemByIdAsync(int id)
        {
            return await _db.CartItems
                .Include(ci => ci.Product)
                .FirstOrDefaultAsync(ci => ci.Id == id);
        }
        public async Task<CartItem?> GetCartItemByUserAndProductAsync(int userId,int productId)
        {
            return await _db.CartItems.Include(ci => ci.Product)    
                .FirstOrDefaultAsync(cartItem =>
                    cartItem.UserId == userId &&
                    cartItem.ProductId == productId);
        }
        public async Task AddCartItemAsync(CartItem cartItem)
        {
            _db.CartItems.Add(cartItem);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateCartItemAsync(CartItem cartItem)
        {
            _db.CartItems.Update(cartItem);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteCartItemAsync(int id)
        {
            var cartItem=await _db.CartItems.FindAsync(id);
            if(cartItem != null)
            {
                _db.CartItems.Remove(cartItem);
                await _db.SaveChangesAsync();
            }
        }
        public async Task ClearCartItemAsync(int userId)
        {
            var cartItems = await _db.CartItems
                .Where(ci => ci.UserId == userId)
                .ToListAsync();
            if(cartItems.Count > 0)
            {
                _db.CartItems.RemoveRange(cartItems);
                await _db.SaveChangesAsync();
            }
        }
    }
}
