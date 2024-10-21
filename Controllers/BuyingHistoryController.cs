
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices.IReportsServices;
using ParadisePromotions.Core.Models.ReportsModels;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]") , Authorize]
    [ApiController]
    public class BuyingHistoryController : ControllerBase
    {
        private readonly IBuyingHistoryService _buyingHistoryService;
        public BuyingHistoryController(IBuyingHistoryService buyingHistoryService)
        {
            _buyingHistoryService = buyingHistoryService;
        }

        [HttpGet]
        [Route("BuyingHistory")]
        public async Task<IActionResult> GetBuyingHistory()
        {
            try
            {
                var buyingHistory = await _buyingHistoryService.GetAllBuyingHistory();
                return Ok(buyingHistory);
            }
            catch (Exception ex)
            {

                return BadRequest();    
            }
        }

        [HttpPost]
        [Route("AddBuyingHistory")]
        public async Task<IActionResult> CreateBuyingHistory([FromBody] BuyingHistory model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _buyingHistoryService.CreateBuyingHistory(model);
                    return Ok(new { message = "BuyingHistory created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }
        

        [HttpGet("BuyingHistory/{id}")]
        public async Task<IActionResult> GetBuyingHistoryById(int id)
        {
            // Call the service method to get the buyingHistory by id
            var buyingHistory = await _buyingHistoryService.GetBuyingHistoryById(id);

            // Check if the buyingHistory is null (i.e., buyingHistory not found or invalid id)
            if (buyingHistory == null)
            {
                return NotFound(new { message = "BuyingHistory not found" });
            }

            // Return the found buyingHistory
            return Ok(buyingHistory);
        }

        [HttpPut("UpdateBuyingHistory")]
        public async Task<IActionResult> UpdateBuyingHistory([FromBody] BuyingHistory buyingHistory)
        {
            // Validate the incoming buyingHistory object
            if (buyingHistory == null || buyingHistory.id <= 0)
            {
                return BadRequest(new { message = "Invalid buyingHistory data" });
            }

            // Call the service to update the buyingHistory
            var isUpdated = await _buyingHistoryService.UpdateBuyingHistory(buyingHistory);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "Buying history not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "Buying history updated successfully" });
        }

        [HttpDelete("DeleteBuyingHistory/{id}")]
        public async Task<IActionResult> DeleteBuyingHistory(int id)
        {
            // Call the service method to delete the buyingHistory
            var isDeleted = await _buyingHistoryService.DeleteBuyingHistory(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "Buying history not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "Buying history deleted successfully" });
        }


    }
}
