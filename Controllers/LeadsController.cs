
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]") , Authorize]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly ILeadsService _leadsService;
        public LeadsController(ILeadsService leadsService)
        {
            _leadsService = leadsService;
        }

        [HttpGet]
        [Route("Leads")]
        public async Task<IActionResult> GetLeads()
        {
            try
            {
                var leads = await _leadsService.GetAllLeads();
                return Ok(leads);
            }
            catch (Exception ex)
            {

                return BadRequest();    
            }
        }

        [HttpPost]
        [Route("AddLeads")]
        public async Task<IActionResult> CreateLeads([FromBody] Lead model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _leadsService.CreateLeads(model);
                    return Ok(new { message = "Leads created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }
        

        [HttpGet("Leads/{id}")]
        public async Task<IActionResult> GetLeadsById(int id)
        {
            // Call the service method to get the leads by id
            var leads = await _leadsService.GetLeadsById(id);

            // Check if the leads is null (i.e., leads not found or invalid id)
            if (leads == null)
            {
                return NotFound(new { message = "Leads not found" });
            }

            // Return the found leads
            return Ok(leads);
        }

        [HttpPut("UpdateLeads")]
        public async Task<IActionResult> UpdateLeads([FromBody] Lead leads)
        {
            // Validate the incoming leads object
            if (leads == null || leads.Id <= 0)
            {
                return BadRequest(new { message = "Invalid leads data" });
            }

            // Call the service to update the leads
            var isUpdated = await _leadsService.UpdateLeads(leads);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "Leads not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "Leads updated successfully" });
        }

        [HttpDelete("DeleteLeads/{id}")]
        public async Task<IActionResult> DeleteLeads(int id)
        {
            // Call the service method to delete the leads
            var isDeleted = await _leadsService.DeleteLeads(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "Leads not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "Leads deleted successfully" });
        }


    }
}
