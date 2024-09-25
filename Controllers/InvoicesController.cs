
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoicesService _invoicesService;
        public InvoicesController(IInvoicesService invoicesService)
        {
            _invoicesService = invoicesService;
        }
        [HttpGet]
        [Route("Invoices")]
        public async Task<IActionResult> GetInvoices()
        {
            try
            {
                var invoices = await _invoicesService.GetAllInvoices();
                return Ok(invoices);
            }
            catch (Exception ex)
            {

                return BadRequest();    
            }
        }

        [HttpPost]
        [Route("AddInvoice")]
        public async Task<IActionResult> CreateInvoice([FromBody] Invoice model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _invoicesService.CreateInvoice(model);
                    return Ok(new { message = "Invoice created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }
        

        [HttpGet("Invoice/{id}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            // Call the service method to get the invoice by id
            var invoice = await _invoicesService.GetInvoiceById(id);

            // Check if the invoice is null (i.e., invoice not found or invalid id)
            if (invoice == null)
            {
                return NotFound(new { message = "Invoice not found" });
            }

            // Return the found invoice
            return Ok(invoice);
        }

        [HttpPut("UpdateInvoice")]
        public async Task<IActionResult> UpdateInvoice([FromBody] Invoice invoice)
        {
            // Validate the incoming invoice object
            if (invoice == null || invoice.ID <= 0)
            {
                return BadRequest(new { message = "Invalid invoice data" });
            }

            // Call the service to update the invoice
            var isUpdated = await _invoicesService.UpdateInvoice(invoice);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "Invoice not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "Invoice updated successfully" });
        }

        [HttpDelete("DeleteInvoice/{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            // Call the service method to delete the invoice
            var isDeleted = await _invoicesService.DeleteInvoice(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "Invoice not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "Invoice deleted successfully" });
        }


    }
}
