using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Core.Services
{
    public class UserService : IUserService
    {
        public IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateUser(UserModel user)
        {
            if (user != null)
            {
                user.Created_Date = DateTime.Now;
                await _unitOfWork.Users.Insert(user);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteUser(int id)
        {
            if (id > 0)
            {
                var user = await _unitOfWork.Users.GetById(id);
                if (user != null)
                {
                    _unitOfWork.Users.Delete(user);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            var users = await _unitOfWork.Users.GetAll();
            return users; ;
        }

        public async Task<UserModel> GetUserById(int id)
        {
            if (id > 0)
            {
                var user = await _unitOfWork.Users.GetById(id);
                if (user != null)
                {
                    return user;
                }
            }
            return null;
        }

        public async Task<bool> UpdateUser(UserModel user)
        {
            if (user == null)
            {
                return false;
            }

            var existingUser = await _unitOfWork.Users.GetById(user.id);
            if (existingUser == null)
            {
                return false;
            }

            // Update the properties of the existing user
            existingUser.username = user.username;
            existingUser.email = user.email;
            existingUser.password = user.password;
            existingUser.Created_Date = user.Created_Date;
            existingUser.Updated_Date = DateTime.Now;

            _unitOfWork.Users.Update(existingUser);

            var result =  _unitOfWork.Save();
            return result > 0;
        }

        public async Task<UserModel> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null; // Username or password is empty
            }

            // Find user by username (assuming unique usernames)
            var users = await _unitOfWork.Users.GetAll();
            var user = users.FirstOrDefault(u => u.username == username && u.password == password);
            if (user == null)
            {
                return null; // User with the given username does not exist
            }

            // Check if the provided password matches the stored password hash
            if (!VerifyPasswordHash(password, user.password))
            {
                return null; // Password does not match
            }

            // Password matches, return the user
            return user;
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            return password == storedHash;
        }


    }
}
