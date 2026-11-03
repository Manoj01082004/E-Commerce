using ProductServices.Models;
using ProductServices.Repositories;
using ProductServices.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductServices.Services
{
    public class InventoryService
    {
        private readonly IInventoryRepository _repo;
        public InventoryService(IInventoryRepository repo)
        {
            _repo = repo;
        }
        public async Task<ICollection<Inventory>> GetAllInventoriesAsync()
        {
            return await _repo.GetAllInventoriesAsync();
        }
        public async Task<Inventory?> GetInventoryByIdAsync(int id)
        {
            return await _repo.GetInventoryByIdAsync(id);
        }
        public async Task<Inventory?> GetInventoryByProductIdAsync(int productId)
        {
            return await _repo.GetInventoryByProductIdAsync(productId);
        }
        public async Task CreateInventoryAsync(Inventory inventory)
        {
            await _repo.CreateInventoryAsync(inventory);
        }
        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            await _repo.UpdateInventoryAsync(inventory);
        }
        public async Task RestockInventoryAsync(int id, int quantityToAdd)
        {
            var inventory = await _repo.GetInventoryByIdAsync(id);

            if (inventory != null)
            {
                inventory.QuantityOnHand += quantityToAdd;
                inventory.LastRestockedAt = DateTime.UtcNow;
                inventory.UpdatedAt = DateTime.UtcNow;

                await _repo.UpdateInventoryAsync(inventory);
            }

        }
        public async Task<bool> DeleteInventoryAsync(int id)
        {
            var existingInventory = await _repo.GetInventoryByIdAsync(id);
            if (existingInventory == null)
            {
                return false;
            }
            await _repo.DeleteInventoryAsync(id);
            return true;
        }
    }
}
