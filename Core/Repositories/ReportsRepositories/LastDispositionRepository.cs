
using ParadisePromotions.Core.Interfaces.IReportsRepositories;
using ParadisePromotions.Core.Models.ReportsModels;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories.ReportsRepositories
{
    public class LastDispositionRepository : GenericRepository<LastDisposition>, ILastDispositionRepository
    {
        public LastDispositionRepository(DBContextClass dbContext) : base(dbContext) { }
    }
}