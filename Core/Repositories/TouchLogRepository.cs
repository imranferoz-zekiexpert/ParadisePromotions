using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories
{
    public class TouchLogRepository :GenericRepository<TouchLog>, ITouchLogRepository
    {
        public TouchLogRepository(DBContextClass dbContext):base(dbContext) { }
    }
}