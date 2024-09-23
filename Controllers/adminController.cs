
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class adminController : ControllerBase
    {
        private readonly IUserService _userService;
        public adminController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("/Users")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception)
            {

                return BadRequest();    
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.CreateUser(model);
                    return Ok(true); 
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }

    }
}
