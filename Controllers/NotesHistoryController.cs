
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]") , Authorize]
    [ApiController]
    public class NotesHistoryController : ControllerBase
    {
        private readonly INotesHistoryService _notesHistoryService;
        public NotesHistoryController(INotesHistoryService notesHistoryService)
        {
            _notesHistoryService = notesHistoryService;
        }
        [HttpGet]
        [Route("NotesHistory")]
        public async Task<IActionResult> GetNotesHistory()
        {
            try
            {
                var notesHistory = await _notesHistoryService.GetAllNotesHistory();
                return Ok(notesHistory);
            }
            catch (Exception ex)
            {

                return BadRequest();    
            }
        }

        [HttpPost]
        [Route("AddNotesHistory")]
        public async Task<IActionResult> CreateNotesHistory([FromBody] NotesHistory model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _notesHistoryService.CreateNotesHistory(model);
                    return Ok(new { message = "Notes History created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }
        

        [HttpGet("NotesHistory/{id}")]
        public async Task<IActionResult> GetNotesHistoryById(int id)
        {
            // Call the service method to get the noteHistory by id
            var noteHistory = await _notesHistoryService.GetNotesHistoryById(id);

            // Check if the noteHistory is null (i.e., noteHistory not found or invalid id)
            if (noteHistory == null)
            {
                return NotFound(new { message = "NotesHistory not found" });
            }

            // Return the found noteHistory
            return Ok(noteHistory);
        }

        [HttpPut("UpdateNotesHistory")]
        public async Task<IActionResult> UpdateNotesHistory([FromBody] NotesHistory noteHistory)
        {
            // Validate the incoming noteHistory object
            if (noteHistory == null || noteHistory.NoteHistoryID <= 0)
            {
                return BadRequest(new { message = "Invalid noteHistory data" });
            }

            // Call the service to update the noteHistory
            var isUpdated = await _notesHistoryService.UpdateNotesHistory(noteHistory);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "NotesHistory not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "NotesHistory updated successfully" });
        }

        [HttpDelete("DeleteNotesHistory/{id}")]
        public async Task<IActionResult> DeleteNotesHistory(int id)
        {
            // Call the service method to delete the noteHistory
            var isDeleted = await _notesHistoryService.DeleteNotesHistory(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "NotesHistory not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "NotesHistory deleted successfully" });
        }


    }
}
