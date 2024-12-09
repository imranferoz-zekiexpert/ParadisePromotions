using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories
{
    public class LeadsRepository :GenericRepository<Lead>, ILeadsRepository
    {
        public LeadsRepository(DBContextClass dbContext):base(dbContext) { }
    }
}