
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]") , Authorize]
    [ApiController]
    public class QryBlankSalePrintGreenSheetMainController : ControllerBase
    {
        private readonly IQryBlankSalePrintGreenSheetMainService _qryBlankSalePrintGreenSheetMainService;
        public QryBlankSalePrintGreenSheetMainController(IQryBlankSalePrintGreenSheetMainService qryBlankSalePrintGreenSheetMainService)
        {
            _qryBlankSalePrintGreenSheetMainService = qryBlankSalePrintGreenSheetMainService;
        }
        [HttpGet]
        [Route("SalePrintGreenSheet")]
        public async Task<IActionResult> GetSalePrintGreenSheet()
        {
            try
            {
                var qryBlankSalePrintGreenSheetMain = await _qryBlankSalePrintGreenSheetMainService.GetAllSalePrintGreenSheet();
                return Ok(qryBlankSalePrintGreenSheetMain);
            }
            catch (Exception ex)
            {

                return BadRequest();    
            }
        }

        [HttpPost]
        [Route("AddSalePrintGreenSheet")]
        public async Task<IActionResult> CreateSalePrintGreenSheet([FromBody] QryBlankSalePrintGreenSheetMain model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _qryBlankSalePrintGreenSheetMainService.CreateSalePrintGreenSheet(model);
                    return Ok(new { message = "SalePrintGreenSheet created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }
        

        [HttpGet("SalePrintGreenSheet/{id}")]
        public async Task<IActionResult> GetSalePrintGreenSheetById(int id)
        {
            // Call the service method to get the blankSale by id
            var sheet = await _qryBlankSalePrintGreenSheetMainService.GetSalePrintGreenSheetById(id);

            // Check if the blankSale is null (i.e., blankSale not found or invalid id)
            if (sheet == null)
            {
                return NotFound(new { message = "SalePrintGreenSheet not found" });
            }

            // Return the found blankSale
            return Ok(sheet);
        }

        [HttpPut("UpdateSalePrintGreenSheet")]
        public async Task<IActionResult> UpdateSalePrintGreenSheet([FromBody] QryBlankSalePrintGreenSheetMain sheet)
        {
            try
            {
                // Validate the incoming blankSale object
                if (sheet == null || sheet.ID < 0)
                {
                    return BadRequest(new { message = "Invalid SalePrintGreenSheet data" });
                }

                // Call the service to update the blankSale
                var isUpdated = await _qryBlankSalePrintGreenSheetMainService.UpdateSalePrintGreenSheet(sheet);

                // Check if the update was successful
                if (!isUpdated)
                {
                    return NotFound(new { message = "SalePrintGreenSheet not found or update failed" });
                }

                // Return a success response
                return Ok(new { message = "SalePrintGreenSheet updated successfully" });
            }catch(Exception ex)
            {
               return BadRequest(new { message = ex}); ;
            }
        }

        [HttpDelete("DeleteSalePrintGreenSheet/{id}")]
        public async Task<IActionResult> DeleteSalePrintGreenSheet(int id)
        {
            // Call the service method to delete the blankSale
            var isDeleted = await _qryBlankSalePrintGreenSheetMainService.DeleteSalePrintGreenSheet(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "SalePrintGreenSheet not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "SalePrintGreenSheet deleted successfully" });
        }


    }
}
