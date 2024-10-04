using ParadisePromotions.Core.Interfaces.ICodes;
using ParadisePromotions.Core.Models.Codes;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories.Codes
{
    public class CyclesRepository : GenericRepository<Cycles>, ICyclesRepository
    {
        public CyclesRepository(DBContextClass dbContext) : base(dbContext) { }
    }
}