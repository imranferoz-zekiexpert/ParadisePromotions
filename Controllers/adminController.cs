
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        public AdminController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("Users")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {

                return BadRequest();    
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> CreateUser([FromBody] Staff model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.CreateUser(model);
                    return Ok(new { message = "User created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult>  Login(LoginRequestModel User)
        {
           var user = await _userService.Login(User);
            if (user == null)
            {
                return BadRequest(new { message = "UserName or Password is incorrect" });
            }
            return Ok(user);
        }

        [HttpGet("User/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            // Call the service method to get the user by id
            var user = await _userService.GetUserById(id);

            // Check if the user is null (i.e., user not found or invalid id)
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            // Return the found user
            return Ok(user);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] Staff user)
        {
            // Validate the incoming user object
            if (user == null || user.StaffID <= 0)
            {
                return BadRequest(new { message = "Invalid user data" });
            }

            // Call the service to update the user
            var isUpdated = await _userService.UpdateUser(user);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "User not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "User updated successfully" });
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            // Call the service method to delete the user
            var isDeleted = await _userService.DeleteUser(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "User not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "User deleted successfully" });
        }


    }
}
