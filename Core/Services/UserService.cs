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
        public async Task<bool> CreateUser(Staff user)
        {
            if (user != null)
            {
                user.Hire_date = DateTime.Now;
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

        public async Task<IEnumerable<Staff>> GetAllUsers()
        {
            var users = await _unitOfWork.Users.GetAll();
            return users; ;
        }

        public async Task<Staff> GetUserById(int id)
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

        public async Task<bool> UpdateUser(Staff user)
        {
            if (user == null)
            {
                return false;
            }

            var existingUser = await _unitOfWork.Users.GetById(user.StaffID);
            if (existingUser == null)
            {
                return false;
            }
            // Perform the update in the database
            // Update the properties of the existing user
            existingUser.StaffID = user.StaffID;
            existingUser.Name = user.Name;
            existingUser.SSN = user.SSN;
            existingUser.Password = user.Password;
            existingUser.Hire_date = user.Hire_date;
            existingUser.Class = user.Class;
            existingUser.isAdmin = user.isAdmin;
            existingUser.IsVerifier = user.IsVerifier;
            existingUser.IsActiveReloader = user.IsActiveReloader;
            existingUser.Active = user.Active;

            // Perform the update in the database
            _unitOfWork.Users.Update(existingUser);

            // Save the changes
            var result = _unitOfWork.Save();
            return result > 0;
        }


        public async Task<LoginResponceModel> Login([FromBody] LoginRequestModel loginRequest)
        {
            try
            {
                // Validate input
                if (loginRequest.StaffID < 0 || string.IsNullOrEmpty(loginRequest.Password))
                {
                    return null; // Invalid staff ID or password
                }

                // Retrieve all users (ideally, query the user directly rather than loading all users)
                var users = await _unitOfWork.Users.GetAll(); 
                var roles =await _unitOfWork.RoleManagement.GetAll();
                var user = users.FirstOrDefault(u => u.StaffID == loginRequest.StaffID);
                var role=roles.FirstOrDefault(r =>r.ID == user.RoleID);


                if (user == null || !VerifyPasswordHash(loginRequest.Password, user.Password))
                {
                    return null; // Invalid staff ID or password
                }

                // Create JWT token
                var jwtKey = _configuration["Jwt:JWT_KEY"];
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(jwtKey); // Ensure the key is set in your config
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
            new Claim(ClaimTypes.NameIdentifier, user.StaffID.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, role.Name),
            new Claim("RoleID", user.RoleID.ToString()),
        }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                string userToken = tokenHandler.WriteToken(token);

                // Return response with user name and token
                return new LoginResponceModel
                {
                    Name = user.Name,
                    Role = new UserRole
                    {
                        ID = role.ID,
                        Name = role.Name, // Include additional details if needed
                    },

                    token = userToken
                };
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            return password == storedHash;
        }

    }
}
