
using ParadisePromotions.Core.Interfaces.IReportsRepositories;
using ParadisePromotions.Core.Models.ReportsModels;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories.ReportsRepositories
{
    public class NextCallBackRepository : GenericRepository<NextCallBack>, INextCallBackRepository
    {
        public NextCallBackRepository(DBContextClass dbContext) : base(dbContext) { }
    }
}