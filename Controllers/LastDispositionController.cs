
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices.IReportsServices;
using ParadisePromotions.Core.Models.ReportsModels;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]") , Authorize]
    [ApiController]
    public class LastDispositionController : ControllerBase
    {
        private readonly ILastDispositionService _lastDispositionService;
        public LastDispositionController(ILastDispositionService lastDispositionService)
        {
            _lastDispositionService = lastDispositionService;
        }

        [HttpGet]
        [Route("LastDisposition")]
        public async Task<IActionResult> GetLastDisposition()
        {
            try
            {
                var lastDisposition = await _lastDispositionService.GetAllLastDisposition();
                return Ok(lastDisposition);
            }
            catch (Exception ex)
            {

                return BadRequest();    
            }
        }

        [HttpPost]
        [Route("AddLastDisposition")]
        public async Task<IActionResult> CreateLastDisposition([FromBody] LastDisposition model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _lastDispositionService.CreateLastDisposition(model);
                    return Ok(new { message = "Last disposition created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }
        

        [HttpGet("LastDisposition/{id}")]
        public async Task<IActionResult> GetLastDispositionById(int id)
        {
            // Call the service method to get the lastDisposition by id
            var lastDisposition = await _lastDispositionService.GetLastDispositionById(id);

            // Check if the lastDisposition is null (i.e., lastDisposition not found or invalid id)
            if (lastDisposition == null)
            {
                return NotFound(new { message = "Last disposition not found" });
            }

            // Return the found lastDisposition
            return Ok(lastDisposition);
        }

        [HttpPut("UpdateLastDisposition")]
        public async Task<IActionResult> UpdateLastDisposition([FromBody] LastDisposition lastDisposition)
        {
            // Validate the incoming lastDisposition object
            if (lastDisposition == null || lastDisposition.Id <= 0)
            {
                return BadRequest(new { message = "Invalid last disposition data" });
            }

            // Call the service to update the lastDisposition
            var isUpdated = await _lastDispositionService.UpdateLastDisposition(lastDisposition);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "Last disposition not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "Last disposition updated successfully" });
        }

        [HttpDelete("DeleteLastDisposition/{id}")]
        public async Task<IActionResult> DeleteLastDisposition(int id)
        {
            // Call the service method to delete the lastDisposition
            var isDeleted = await _lastDispositionService.DeleteLastDisposition(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "Last disposition not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "Last disposition deleted successfully" });
        }


    }
}
