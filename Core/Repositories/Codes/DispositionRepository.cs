using ParadisePromotions.Core.Interfaces.ICodes;
using ParadisePromotions.Core.Models.Codes;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories.Codes
{
    public class DispositionRepository : GenericRepository<Disposition>, IDispositionRepository
    {
        public DispositionRepository(DBContextClass dbContext) : base(dbContext) { }
    }
}