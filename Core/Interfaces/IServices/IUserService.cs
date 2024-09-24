using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Core.Interfaces.IServices
{
    public interface IUserService
    {
        Task<bool> CreateUser(UserModel user);
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(int id);
        Task<bool> UpdateUser(UserModel user);
        Task<bool> DeleteUser(int id);
        Task<LoginResponceModel> Login(LoginRequestModel model);
    }
}
