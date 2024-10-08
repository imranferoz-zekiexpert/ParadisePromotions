using ParadisePromotions.Core.Interfaces.ICodes;
using ParadisePromotions.Core.Models.Codes;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories.Codes
{
    public class ColorsRepository : GenericRepository<Colors>, IColorsRepository
    {
        public ColorsRepository(DBContextClass dbContext) : base(dbContext) { }
    }
}