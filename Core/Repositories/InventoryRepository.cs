using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories
{
    public class InventoryRepository :GenericRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(DBContextClass dbContext):base(dbContext) { }
    }
}