using ProductServices.Models;

namespace ProductServices.Repositories.Interfaces
{
    public interface IInventoryRepository
    {
        Task<ICollection<Inventory>> GetAllInventoriesAsync();
        Task<Inventory?> GetInventoryByIdAsync(int id);
        Task<Inventory?> GetInventoryByProductIdAsync(int productId);
        Task CreateInventoryAsync(Inventory inventory);
        Task UpdateInventoryAsync(Inventory inventory);
        Task DeleteInventoryAsync(int id);
    }
}
