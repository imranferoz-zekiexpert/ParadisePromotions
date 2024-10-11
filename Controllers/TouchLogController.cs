
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouchLogController : ControllerBase
    {
        private readonly ITouchLogService _touchLogService;
        public TouchLogController(ITouchLogService touchLogService)
        {
            _touchLogService = touchLogService;
        }

        [HttpGet]
        [Route("TouchLog")]
        public async Task<IActionResult> GetTouchLog()
        {
            try
            {
                var touchLog = await _touchLogService.GetAllTouchLog();
                return Ok(touchLog);
            }
            catch (Exception ex)
            {

                return BadRequest();    
            }
        }

        [HttpPost]
        [Route("AddTouchLog")]
        public async Task<IActionResult> CreateTouchLog([FromBody] TouchLog model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _touchLogService.CreateTouchLog(model);
                    return Ok(new { message = "TouchLog created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }
        

        [HttpGet("TouchLog/{id}")]
        public async Task<IActionResult> GetTouchLogById(int id)
        {
            // Call the service method to get the touchLog by id
            var touchLog = await _touchLogService.GetTouchLogById(id);

            // Check if the touchLog is null (i.e., touchLog not found or invalid id)
            if (touchLog == null)
            {
                return NotFound(new { message = "TouchLog not found" });
            }

            // Return the found touchLog
            return Ok(touchLog);
        }

        [HttpPut("UpdateTouchLog")]
        public async Task<IActionResult> UpdateTouchLog([FromBody] TouchLog touchLog)
        {
            // Validate the incoming touchLog object
            if (touchLog == null || touchLog.TouchLogID <= 0)
            {
                return BadRequest(new { message = "Invalid touchLog data" });
            }

            // Call the service to update the touchLog
            var isUpdated = await _touchLogService.UpdateTouchLog(touchLog);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "TouchLog not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "TouchLog updated successfully" });
        }

        [HttpDelete("DeleteTouchLog/{id}")]
        public async Task<IActionResult> DeleteTouchLog(int id)
        {
            // Call the service method to delete the touchLog
            var isDeleted = await _touchLogService.DeleteTouchLog(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "TouchLog not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "TouchLog deleted successfully" });
        }


    }
}
