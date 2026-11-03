using E_CommerceDTO.Context;
using E_CommerceDTO.models;
using E_CommerceDTO.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceDTO.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ECommerceDBContext _db;
        public InventoryRepository(ECommerceDBContext db)
        {
            _db = db;
        }
        public async Task<ICollection<Inventory>> GetAllInventoriesAsync()
        {
            return await _db.Inventories.Include(inventory => inventory.Product)
            .ToListAsync();
        }
        public async Task<Inventory?> GetInventoryByIdAsync(int id)
        {
            return await _db.Inventories
                .Include(inventory => inventory.Product)
                .FirstOrDefaultAsync(inventory => inventory.Id == id);
        }
        public async Task<Inventory?> GetInventoryByProductIdAsync(int productId)
        {
            return await _db.Inventories
                .Include(inventory => inventory.Product)
                .FirstOrDefaultAsync(inventory => inventory.ProductId == productId);
        }
        public async Task CreateInventoryAsync(Inventory inventory)
        {

            await _db.Inventories.AddAsync(inventory);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            _db.Inventories.Update(inventory);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteInventoryAsync(int id)
        {
            var inventory = await _db.Inventories.FindAsync(id);
            if (inventory != null)
            {
                _db.Inventories.Remove(inventory);
                await _db.SaveChangesAsync();
            }
        }
    }
}
