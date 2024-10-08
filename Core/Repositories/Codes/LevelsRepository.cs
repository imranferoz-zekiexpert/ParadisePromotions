using ParadisePromotions.Core.Interfaces.ICodes;
using ParadisePromotions.Core.Models.Codes;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories.Codes
{
    public class LevelsRepository : GenericRepository<Levels>, ILevelsRepository
    {
        public LevelsRepository(DBContextClass dbContext) : base(dbContext) { }
    }
}