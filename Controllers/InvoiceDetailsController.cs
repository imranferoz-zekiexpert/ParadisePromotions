
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]") , Authorize]
    [ApiController]
    public class InvoiceDetailsController : ControllerBase
    {
        private readonly IInvoiceDetailsService _invoiceDetailsService;
        public InvoiceDetailsController(IInvoiceDetailsService invoiceDetailsService)
        {
            _invoiceDetailsService = invoiceDetailsService;
        }
        [HttpGet]
        [Route("InvoiceDetails")]
        public async Task<IActionResult> GetInvoiceDetails()
        {
            try
            {
                var invoiceDetails = await _invoiceDetailsService.GetAllInvoiceDetails();
                return Ok(invoiceDetails);
            }
            catch (Exception ex)
            {

                return BadRequest();    
            }
        }

        [HttpPost]
        [Route("AddInvoiceDetail")]
        public async Task<IActionResult> CreateInvoiceDetail([FromBody] InvoiceDetail model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _invoiceDetailsService.CreateInvoiceDetail(model);
                    return Ok(new { message = "InvoiceDetail created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }
        

        [HttpGet("InvoiceDetail/{id}")]
        public async Task<IActionResult> GetInvoiceDetailById(int id)
        {
            // Call the service method to get the invoiceDetail by id
            var invoiceDetail = await _invoiceDetailsService.GetInvoiceDetailById(id);

            // Check if the invoiceDetail is null (i.e., invoiceDetail not found or invalid id)
            if (invoiceDetail == null)
            {
                return NotFound(new { message = "InvoiceDetail not found" });
            }

            // Return the found invoiceDetail
            return Ok(invoiceDetail);
        }

        [HttpPut("UpdateInvoiceDetail")]
        public async Task<IActionResult> UpdateInvoiceDetail([FromBody] InvoiceDetail invoiceDetail)
        {
            // Validate the incoming invoiceDetail object
            if (invoiceDetail == null || invoiceDetail.ID <= 0)
            {
                return BadRequest(new { message = "Invalid invoiceDetail data" });
            }

            // Call the service to update the invoiceDetail
            var isUpdated = await _invoiceDetailsService.UpdateInvoiceDetail(invoiceDetail);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "InvoiceDetail not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "InvoiceDetail updated successfully" });
        }

        [HttpDelete("DeleteInvoiceDetail/{id}")]
        public async Task<IActionResult> DeleteInvoiceDetail(int id)
        {
            // Call the service method to delete the invoiceDetail
            var isDeleted = await _invoiceDetailsService.DeleteInvoiceDetail(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "InvoiceDetail not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "InvoiceDetail deleted successfully" });
        }


    }
}
