
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]") , Authorize]
    [ApiController]
    public class RoleManagementController : ControllerBase
    {
        private readonly IRoleManagementService _roleManagementService;
        public RoleManagementController(IRoleManagementService roleManagementService)
        {
            _roleManagementService = roleManagementService;
        }

        [HttpGet]
        [Route("Roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var roles = await _roleManagementService.GetAllRoles();
                return Ok(roles);
            }
            catch (Exception ex)
            {

                return BadRequest();    
            }
        } 
        
        [HttpGet]
        [Route("RoleModules/{id}")]
        public async Task<IActionResult> GetAllRoleModeules(int id)
        {
            try
            {
                var modules = await _roleManagementService.GetAllRoleModeules(id);
                return Ok(modules);
            }
            catch (Exception ex)
            {

                return BadRequest();    
            }
        } 
        
        [HttpGet]
        [Route("AppModules")]
        public async Task<IActionResult> GetAllAppModules()
        {
            try
            {
                var appModules = await _roleManagementService.GetAllAppModule();
                return Ok(appModules);
            }
            catch (Exception ex)
            {

                return BadRequest();    
            }
        }

        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> CreateRole([FromBody] UserRole role)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _roleManagementService.CreateRole(role);
                    return Ok(new { message = "Role created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }   
        
        [HttpPost]
        [Route("AddRoleModule")]
        public async Task<IActionResult> AddRoleModule([FromBody] RoleModule module)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _roleManagementService.AddRoleModule(module);
                    return Ok(new { message = "Role module created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }        

        

        [HttpPut("UpdateRole")]
        public async Task<IActionResult> UpdateRole([FromBody] UserRole role)
        {
            // Validate the incoming pars object
            if (role == null || role.ID <= 0)
            {
                return BadRequest(new { message = "Invalid role data" });
            }

            // Call the service to update the pars
            var isUpdated = await _roleManagementService.UpdateRole(role);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "role not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "Role updated successfully" });
        }

        [HttpDelete("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            // Call the service method to delete the pars
            var isDeleted = await _roleManagementService.DeleteRole(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "Role not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "Role deleted successfully" });
        }
        
        [HttpDelete("DeleteRoleModule/{id}")]
        public async Task<IActionResult> DeleteRoleModule(int id)
        {
            // Call the service method to delete the pars
            var isDeleted = await _roleManagementService.DeleteRoleModule(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "Role module not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "Role module deleted successfully" });
        }


    }
}
