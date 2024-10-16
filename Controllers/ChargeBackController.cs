
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]") , Authorize]
    [ApiController]
    public class ChargeBackController : ControllerBase
    {
        private readonly IChargeBackService _chargeBackService;
        public ChargeBackController(IChargeBackService chargeBackService)
        {
            _chargeBackService = chargeBackService;
        }

        [HttpGet]
        [Route("ChargeBack")]
        public async Task<IActionResult> GetChargeBack()
        {
            try
            {
                var chargeBack = await _chargeBackService.GetAllChargeBack();
                return Ok(chargeBack);
            }
            catch (Exception ex)
            {

                return BadRequest();    
            }
        }

        [HttpPost]
        [Route("AddChargeBack")]
        public async Task<IActionResult> CreateChargeBack([FromBody] ChargeBack model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _chargeBackService.CreateChargeBack(model);
                    return Ok(new { message = "Charge Back created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }
        

        [HttpGet("ChargeBack/{id}")]
        public async Task<IActionResult> GetChargeBackById(int id)
        {
            // Call the service method to get the chargeBack by id
            var chargeBack = await _chargeBackService.GetChargeBackById(id);

            // Check if the chargeBack is null (i.e., chargeBack not found or invalid id)
            if (chargeBack == null)
            {
                return NotFound(new { message = "Charge Back not found" });
            }

            // Return the found chargeBack
            return Ok(chargeBack);
        }

        [HttpPut("UpdateChargeBack")]
        public async Task<IActionResult> UpdateChargeBack([FromBody] ChargeBack chargeBack)
        {
            // Validate the incoming chargeBack object
            if (chargeBack == null || chargeBack.ID <= 0)
            {
                return BadRequest(new { message = "Invalid charge back data" });
            }

            // Call the service to update the chargeBack
            var isUpdated = await _chargeBackService.UpdateChargeBack(chargeBack);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "Charge back not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "Charge back updated successfully" });
        }

        [HttpDelete("DeleteChargeBack/{id}")]
        public async Task<IActionResult> DeleteChargeBack(int id)
        {
            // Call the service method to delete the chargeBack
            var isDeleted = await _chargeBackService.DeleteChargeBack(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "Charge back not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "Charge back deleted successfully" });
        }


    }
}
