using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories
{
    public class RoleManagementRepository :GenericRepository<UserRole>, IRoleManagementRepository
    {
        public RoleManagementRepository(DBContextClass dbContext):base(dbContext) { }
    }
}