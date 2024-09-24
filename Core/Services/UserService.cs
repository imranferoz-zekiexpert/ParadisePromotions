using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ParadisePromotions.Core.Services
{
    public class UserService : IUserService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public UserService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
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

        public async Task<LoginResponceModel> Login([FromBody] LoginRequestModel User)
        {
            if (string.IsNullOrEmpty(User.Username) || string.IsNullOrEmpty(User.Password))
            {
                return null; // Username or password is empty
            }

            // Find user by username (assuming unique usernames)
            var users = await _unitOfWork.Users.GetAll();
            var user = users.FirstOrDefault(u => u.username == User.Username && u.password == User.Password);
            if (user == null)
            {
                return null; // User with the given username does not exist
            }

            // Check if the provided password matches the stored password hash
            if (!VerifyPasswordHash(User.Password, user.password))
            {
                return null; // Password does not match
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                   new Claim(ClaimTypes.Name, User.Username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string userToken = tokenHandler.WriteToken(token);

            return new LoginResponceModel
            {
                Username = User.Username,
                token = userToken
            };
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            return password == storedHash;
        }

    }
}
