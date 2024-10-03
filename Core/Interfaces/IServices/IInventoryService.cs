using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Core.Interfaces.IServices
{
    public interface IInventoryService
    {
        Task<bool> CreateInventory(Inventory inventory);
        Task<IEnumerable<Inventory>> GetAllInventory();
        Task<Inventory> GetInventoryById(int id);
        Task<bool> UpdateInventory(Inventory inventory);
        Task<bool> DeleteInventory(int id);
    }
}
