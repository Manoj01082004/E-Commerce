using E_CommerceDTO.models;
using E_CommerceDTO.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceBTO.Services
{
    public class OrderService
    {
        private readonly OrderRepository _repo;
        public OrderService(OrderRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _repo.GetAllOrdersAsync();
        }
        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _repo.GetOrderByIdAsync(id);
        }
        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _repo.GetOrdersByUserIdAsync(userId);
        }
        public async Task CreateOrderAsync(Order order)
        {
            await _repo.CreateOrderAsync(order);
        }
        public async Task UpdateOrderAsync(Order order)
        {
            order.UpdatedAt = DateTime.UtcNow;  
            await _repo.UpdateOrderAsync(order);
        }
        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _repo.GetOrderByIdAsync(id);
            if (order == null)
                return false;

            await _repo.DeleteOrderAsync(id);
            return true;
        }
    }
}
