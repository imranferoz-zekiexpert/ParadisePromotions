﻿using Microsoft.AspNetCore.Mvc;
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

            var existingUser = await _unitOfWork.Users.GetById(user.ID);
            if (existingUser == null)
            {
                return false;
            }

            // Update the properties of the existing user
            // Update the properties of the existing user
            existingUser.Name = user.Name;
            existingUser.SSN = user.SSN;
            existingUser.Password = user.Password;
            existingUser.Hire_date = user.Hire_date;


            _unitOfWork.Users.Update(existingUser);

            var result =  _unitOfWork.Save();
            return result > 0;
        }

        public async Task<LoginResponceModel> Login([FromBody] LoginRequestModel User)
        {
            if (string.IsNullOrEmpty(User.Name) || string.IsNullOrEmpty(User.Password))
            {
                return null; // Username or password is empty
            }

            // Find user by username (assuming unique usernames)
            var users = await _unitOfWork.Users.GetAll();
            var user = users.FirstOrDefault(u => u.Name == User.Name && u.Password == User.Password);
            if (user == null)
            {
                return null; // User with the given username does not exist
            }

            // Check if the provided password matches the stored password hash
            if (!VerifyPasswordHash(User.Password, user.Password))
            {
                return null; // Password does not match
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                   new Claim(ClaimTypes.Name, User.Name)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string userToken = tokenHandler.WriteToken(token);

            return new LoginResponceModel
            {
                Name = User.Name,
                token = userToken
            };
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            return password == storedHash;
        }

    }
}
