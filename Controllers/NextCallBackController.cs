
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices.IReportsServices;
using ParadisePromotions.Core.Models.ReportsModels;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]") , Authorize]
    [ApiController]
    public class NextCallBackController : ControllerBase
    {
        private readonly INextCallBackService _nextCallBackService;
        public NextCallBackController(INextCallBackService nextCallBackService)
        {
            _nextCallBackService = nextCallBackService;
        }

        [HttpGet]
        [Route("NextCallBack")]
        public async Task<IActionResult> GetNextCallBack()
        {
            try
            {
                var nextCallBack = await _nextCallBackService.GetAllNextCallBack();
                return Ok(nextCallBack);
            }
            catch (Exception ex)
            {

                return BadRequest();    
            }
        }

        [HttpPost]
        [Route("AddNextCallBack")]
        public async Task<IActionResult> CreateNextCallBack([FromBody] NextCallBack model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _nextCallBackService.CreateNextCallBack(model);
                    return Ok(new { message = "NextCallBack created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }
        

        [HttpGet("NextCallBack/{id}")]
        public async Task<IActionResult> GetNextCallBackById(int id)
        {
            // Call the service method to get the nextCallBack by id
            var nextCallBack = await _nextCallBackService.GetNextCallBackById(id);

            // Check if the nextCallBack is null (i.e., nextCallBack not found or invalid id)
            if (nextCallBack == null)
            {
                return NotFound(new { message = "NextCallBack not found" });
            }

            // Return the found nextCallBack
            return Ok(nextCallBack);
        }

        [HttpPut("UpdateNextCallBack")]
        public async Task<IActionResult> UpdateNextCallBack([FromBody] NextCallBack nextCallBack)
        {
            // Validate the incoming nextCallBack object
            if (nextCallBack == null || nextCallBack.Id <= 0)
            {
                return BadRequest(new { message = "Invalid nextCallBack data" });
            }

            // Call the service to update the nextCallBack
            var isUpdated = await _nextCallBackService.UpdateNextCallBack(nextCallBack);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "Buying history not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "Buying history updated successfully" });
        }

        [HttpDelete("DeleteNextCallBack/{id}")]
        public async Task<IActionResult> DeleteNextCallBack(int id)
        {
            // Call the service method to delete the nextCallBack
            var isDeleted = await _nextCallBackService.DeleteNextCallBack(id);

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
