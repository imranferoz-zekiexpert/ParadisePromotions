using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Core.Interfaces.IServices
{
    public interface IRoleManagementService
    {
        Task<bool> CreateRole(UserRole role);
        Task<bool> AddRoleModule(RoleModule module);
        Task<IEnumerable<UserRole>> GetAllRoles();
        Task<IEnumerable<AppModule>> GetAllAppModule();
        Task<IEnumerable<RoleModule>> GetAllRoleModeules(int id);
        Task<bool> UpdateRole(UserRole role);
        Task<RoleMngResponse> DeleteRole(int id);
        Task<bool> DeleteRoleModule(int id);
    }
}
