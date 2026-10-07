using E_CommerceDTO.Context;
using E_CommerceDTO.DTO.OrderDTO_s;
using E_CommerceDTO.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceDTO.Repositories
{
    public class OrderRepository
    {
        private readonly ECommerceDBContext _db;
        public OrderRepository(ECommerceDBContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _db.Orders
            .Include(o=>o.User)
            .Include(o => o.Payment)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)  
            .ToListAsync();
        }
        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _db.Orders
            .Include(o => o.User)
            .Include(o => o.Payment)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _db.Orders
            .Include(o => o.User)
            .Include(o => o.Payment)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .Where(o => o.UserId == userId)
            .ToListAsync();
        }
        public async Task CreateOrderAsync(Order order)
        {
            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateOrderAsync(Order order)
        {
            _db.Orders.Update(order);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteOrderAsync(int id)
        {
            var order = await _db.Orders.FindAsync(id);
            if (order != null)
            {
                _db.Orders.Remove(order);
                await _db.SaveChangesAsync();
            }
        }
    }
}
