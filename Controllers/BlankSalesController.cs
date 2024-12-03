
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]") , Authorize]
    [ApiController]
    public class BlankSalesController : ControllerBase
    {
        private readonly IBlankSalesService _blankSalesService;
        public BlankSalesController(IBlankSalesService blankSalesService)
        {
            _blankSalesService = blankSalesService;
        }
        [HttpGet]
        [Route("BlankSales")]
        public async Task<IActionResult> GetBlankSales()
        {
            try
            {
                var blankSales = await _blankSalesService.GetAllBlankSales();
                return Ok(blankSales);
            }
            catch (Exception ex)
            {

                return BadRequest();    
            }
        }

        [HttpPost]
        [Route("AddBlankSale")]
        public async Task<IActionResult> CreateBlankSale([FromBody] BlankSale model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _blankSalesService.CreateBlankSale(model);
                    return Ok(new { message = "BlankSale created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }
        

        [HttpGet("BlankSale/{id}")]
        public async Task<IActionResult> GetBlankSaleById(int id)
        {
            // Call the service method to get the blankSale by id
            var blankSale = await _blankSalesService.GetBlankSaleById(id);

            // Check if the blankSale is null (i.e., blankSale not found or invalid id)
            if (blankSale == null)
            {
                return NotFound(new { message = "BlankSale not found" });
            }

            // Return the found blankSale
            return Ok(blankSale);
        }

        [HttpPut("UpdateBlankSale")]
        public async Task<IActionResult> UpdateBlankSale([FromBody] BlankSale blankSale)
        {
            // Validate the incoming blankSale object
            if (blankSale == null || blankSale.ID <= 0)
            {
                return BadRequest(new { message = "Invalid blankSale data" });
            }

            // Call the service to update the blankSale
            var isUpdated = await _blankSalesService.UpdateBlankSale(blankSale);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "BlankSale not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "BlankSale updated successfully" });
        }

        [HttpDelete("DeleteBlankSale/{id}")]
        public async Task<IActionResult> DeleteBlankSale(int id)
        {
            // Call the service method to delete the blankSale
            var isDeleted = await _blankSalesService.DeleteBlankSale(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "BlankSale not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "BlankSale deleted successfully" });
        }


        [HttpPost]
        [Route("sales-count")]
        public async Task<IActionResult> GetSalesCount([FromBody] SalesFilter filter)
        {
            try
            {
                // Validate input parameters
                if (string.IsNullOrWhiteSpace(filter.UserID) || string.IsNullOrWhiteSpace(filter.StartDate) || string.IsNullOrWhiteSpace(filter.EndDate))
                {
                    return BadRequest("SalesPerson ID, startDate, and endDate are required.");
                }

                // Call the service method
                var salesCount = await _blankSalesService.GetSalesCount(filter);

                // Return the results
                return Ok(salesCount);
            }
            catch (ArgumentException ex)
            {
                // Handle invalid date formats
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other errors
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
