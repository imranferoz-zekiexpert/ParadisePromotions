
using ParadisePromotions.Core.Interfaces.IReportsRepositories;
using ParadisePromotions.Core.Models.ReportsModels;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories.ReportsRepositories
{
    public class BuyingHistoryRepository : GenericRepository<BuyingHistory>, IBuyingHistoryRepository
    {
        public BuyingHistoryRepository(DBContextClass dbContext) : base(dbContext) { }
    }
}