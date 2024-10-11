
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeZonesController : ControllerBase
    {
        private readonly ITimeZonesService _timeZonesService;
        public TimeZonesController(ITimeZonesService timeZonesService)
        {
            _timeZonesService = timeZonesService;
        }

        [HttpGet]
        [Route("TimeZones")]
        public async Task<IActionResult> GetTimeZones()
        {
            try
            {
                var timeZones = await _timeZonesService.GetAllTimeZones();
                return Ok(timeZones);
            }
            catch (Exception ex)
            {

                return BadRequest();    
            }
        }

        [HttpPost]
        [Route("AddTimeZones")]
        public async Task<IActionResult> CreateTimeZones([FromBody] TimeZones model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _timeZonesService.CreateTimeZones(model);
                    return Ok(new { message = "TimeZones created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }
        

        [HttpGet("TimeZones/{id}")]
        public async Task<IActionResult> GetTimeZonesById(int id)
        {
            // Call the service method to get the timeZones by id
            var timeZones = await _timeZonesService.GetTimeZonesById(id);

            // Check if the timeZones is null (i.e., timeZones not found or invalid id)
            if (timeZones == null)
            {
                return NotFound(new { message = "TimeZones not found" });
            }

            // Return the found timeZones
            return Ok(timeZones);
        }

        [HttpPut("UpdateTimeZones")]
        public async Task<IActionResult> UpdateTimeZones([FromBody] TimeZones timeZones)
        {
            // Validate the incoming timeZones object
            if (timeZones == null || timeZones.TimeZoneID <= 0)
            {
                return BadRequest(new { message = "Invalid timeZones data" });
            }

            // Call the service to update the timeZones
            var isUpdated = await _timeZonesService.UpdateTimeZones(timeZones);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "TimeZones not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "TimeZones updated successfully" });
        }

        [HttpDelete("DeleteTimeZones/{id}")]
        public async Task<IActionResult> DeleteTimeZones(int id)
        {
            // Call the service method to delete the timeZones
            var isDeleted = await _timeZonesService.DeleteTimeZones(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "TimeZones not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "TimeZones deleted successfully" });
        }


    }
}
