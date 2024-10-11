using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories
{
    public class BonusRepository :GenericRepository<Bonus>, IBonusRepository
    {
        public BonusRepository(DBContextClass dbContext):base(dbContext) { }
    }
}