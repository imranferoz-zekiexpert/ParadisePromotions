using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Core.Interfaces.IServices
{
    public interface IRoleManagementService
    {
        Task<bool> CreateRole(UserRole role);
        Task<bool> AddRoleModule(RoleModule module);
        Task<IEnumerable<UserRole>> GetAllRoles();
        Task<IEnumerable<RoleModule>> GetAllRoleModeules();
        Task<bool> UpdateRole(UserRole role);
        Task<bool> DeleteRole(int id);
        Task<bool> DeleteRoleModule(int id);
    }
}
