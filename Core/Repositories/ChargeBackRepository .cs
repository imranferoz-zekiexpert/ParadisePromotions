using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories
{
    public class ChargeBackRepository :GenericRepository<ChargeBack>, IChargeBackRepository
    {
        public ChargeBackRepository(DBContextClass dbContext):base(dbContext) { }
    }
}