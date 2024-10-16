
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]") , Authorize]
    [ApiController]
    public class ParsController : ControllerBase
    {
        private readonly IParsService _parsService;
        public ParsController(IParsService parsService)
        {
            _parsService = parsService;
        }

        [HttpGet]
        [Route("Pars")]
        public async Task<IActionResult> GetPars()
        {
            try
            {
                var pars = await _parsService.GetAllPars();
                return Ok(pars);
            }
            catch (Exception ex)
            {

                return BadRequest();    
            }
        }

        [HttpPost]
        [Route("AddPars")]
        public async Task<IActionResult> CreatePars([FromBody] Pars model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _parsService.CreatePars(model);
                    return Ok(new { message = "Pars created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }
        

        [HttpGet("Pars/{id}")]
        public async Task<IActionResult> GetParsById(int id)
        {
            // Call the service method to get the pars by id
            var pars = await _parsService.GetParsById(id);

            // Check if the pars is null (i.e., pars not found or invalid id)
            if (pars == null)
            {
                return NotFound(new { message = "Pars not found" });
            }

            // Return the found pars
            return Ok(pars);
        }

        [HttpPut("UpdatePars")]
        public async Task<IActionResult> UpdatePars([FromBody] Pars pars)
        {
            // Validate the incoming pars object
            if (pars == null || pars.ID <= 0)
            {
                return BadRequest(new { message = "Invalid pars data" });
            }

            // Call the service to update the pars
            var isUpdated = await _parsService.UpdatePars(pars);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "Pars not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "Pars updated successfully" });
        }

        [HttpDelete("DeletePars/{id}")]
        public async Task<IActionResult> DeletePars(int id)
        {
            // Call the service method to delete the pars
            var isDeleted = await _parsService.DeletePars(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "Pars not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "Pars deleted successfully" });
        }


    }
}
