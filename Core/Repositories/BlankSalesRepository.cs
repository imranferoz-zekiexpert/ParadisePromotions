using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories
{
    public class BlankSalesRepository :GenericRepository<BlankSale>, IBlankSalesRepository
    {
        public BlankSalesRepository(DBContextClass dbContext):base(dbContext) { }
    }
}