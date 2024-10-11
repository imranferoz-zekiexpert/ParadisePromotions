using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories
{
    public class ParsRepository :GenericRepository<Pars>, IParsRepository
    {
        public ParsRepository(DBContextClass dbContext):base(dbContext) { }
    }
}