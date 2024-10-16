
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]") , Authorize]
    [ApiController]
    public class BonusController : ControllerBase
    {
        private readonly IBonusService _bonusService;
        public BonusController(IBonusService bonusService)
        {
            _bonusService = bonusService;
        }

        [HttpGet]
        [Route("Bonus")]
        public async Task<IActionResult> GetBonus()
        {
            try
            {
                var bonus = await _bonusService.GetAllBonus();
                return Ok(bonus);
            }
            catch (Exception ex)
            {

                return BadRequest();    
            }
        }

        [HttpPost]
        [Route("AddBonus")]
        public async Task<IActionResult> CreateBonus([FromBody] Bonus model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _bonusService.CreateBonus(model);
                    return Ok(new { message = "Bonus created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }
        

        [HttpGet("Bonus/{id}")]
        public async Task<IActionResult> GetBonusById(int id)
        {
            // Call the service method to get the bonus by id
            var bonus = await _bonusService.GetBonusById(id);

            // Check if the bonus is null (i.e., bonus not found or invalid id)
            if (bonus == null)
            {
                return NotFound(new { message = "Bonus not found" });
            }

            // Return the found bonus
            return Ok(bonus);
        }

        [HttpPut("UpdateBonus")]
        public async Task<IActionResult> UpdateBonus([FromBody] Bonus bonus)
        {
            // Validate the incoming bonus object
            if (bonus == null || bonus.ID <= 0)
            {
                return BadRequest(new { message = "Invalid bonus data" });
            }

            // Call the service to update the bonus
            var isUpdated = await _bonusService.UpdateBonus(bonus);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "Bonus not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "Bonus updated successfully" });
        }

        [HttpDelete("DeleteBonus/{id}")]
        public async Task<IActionResult> DeleteBonus(int id)
        {
            // Call the service method to delete the bonus
            var isDeleted = await _bonusService.DeleteBonus(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "Bonus not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "Bonus deleted successfully" });
        }


    }
}
