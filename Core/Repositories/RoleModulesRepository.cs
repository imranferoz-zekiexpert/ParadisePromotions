using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories
{
    public class RoleModulesRepository :GenericRepository<RoleModule>, IRoleModulesRepository
    {
        public RoleModulesRepository(DBContextClass dbContext):base(dbContext) { }
    }
}