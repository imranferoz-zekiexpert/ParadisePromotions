using ParadisePromotions.Core.Interfaces.ICodes;
using ParadisePromotions.Core.Models.Codes;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories.Codes
{
    public class ReturnTypeRepository : GenericRepository<ReturnType>, IReturnTypeRepository
    {
        public ReturnTypeRepository(DBContextClass dbContext) : base(dbContext) { }
    }
}