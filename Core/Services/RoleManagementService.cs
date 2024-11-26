﻿
using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;
using System.Data;

namespace ParadisePromotions.Core.Services
{
    public class RoleManagementService : IRoleManagementService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public RoleManagementService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<bool> CreateRole(UserRole role)
        {
            if (role != null)
            {
               
                await _unitOfWork.RoleManagement.Insert(role);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public async Task<bool> AddRoleModule(RoleModule module)
        {
            if (module != null)
            {

                await _unitOfWork.RoleModules.Insert(module);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public async Task<bool> DeleteRole(int id)
        {
            if (id > 0)
            {
                var role = await _unitOfWork.RoleManagement.GetById(id);
                if (role != null)
                {
                    _unitOfWork.RoleManagement.Delete(role);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
        public async Task<bool> DeleteRoleModule(int id)
        {
            if (id > 0)
            {
                var module = await _unitOfWork.RoleModules.GetById(id);
                if (module != null)
                {
                    _unitOfWork.RoleModules.Delete(module);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
        public async Task<IEnumerable<UserRole>> GetAllRoles()
        {
            var roles = await _unitOfWork.RoleManagement.GetAll();
            return roles;
        }
        public async Task<IEnumerable<RoleModule>> GetAllRoleModeules()
        {
            var modules = await _unitOfWork.RoleModules.GetAll();
            return modules;
        }
        public async Task<bool> UpdateRole(UserRole role)
        {
            if (role == null)
            {
                return false;
            }

            // Fetch the existing role by ID
            var existingRole = await _unitOfWork.RoleManagement.GetById(role.ID);
            if (existingRole == null)
            {
                return false;
            }

            // Update the properties of the existing role with the new values
            existingRole.Name = role.Name;
            existingRole.Active = role.Active;
            existingRole.UpdatedDate = DateTime.UtcNow;

            // Perform the update in the database
            _unitOfWork.RoleManagement.Update(existingRole);

            // Save the changes
            var result =  _unitOfWork.Save(); // Using async save method
            return result > 0;
        }


    }
}