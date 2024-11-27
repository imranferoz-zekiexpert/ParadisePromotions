using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories
{
    public class AppModuleRepository :GenericRepository<AppModule>, IAppModuleRepository
    {
        public AppModuleRepository(DBContextClass dbContext):base(dbContext) { }
    }
}