using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Core.Interfaces.IServices
{
    public interface IUserService
    {
        Task<bool> CreateUser(Staff user);
        Task<IEnumerable<Staff>> GetAllUsers();
        Task<Staff> GetUserById(int id);
        Task<bool> UpdateUser(Staff user);
        Task<bool> DeleteUser(int id);
        Task<LoginResponceModel> Login(LoginRequestModel model);
    }
}
