
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        [HttpGet]
        [Route("Inventory")]
        public async Task<IActionResult> GetInventory()
        {
            try
            {
                var inventory = await _inventoryService.GetAllInventory();
                return Ok(inventory);
            }
            catch (Exception ex)
            {

                return BadRequest();    
            }
        }

        [HttpPost]
        [Route("AddInventory")]
        public async Task<IActionResult> CreateInventory([FromBody] Inventory model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _inventoryService.CreateInventory(model);
                    return Ok(new { message = "Inventory created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }
        

        [HttpGet("Inventory/{id}")]
        public async Task<IActionResult> GetInventoryById(int id)
        {
            // Call the service method to get the inventory by id
            var inventory = await _inventoryService.GetInventoryById(id);

            // Check if the inventory is null (i.e., inventory not found or invalid id)
            if (inventory == null)
            {
                return NotFound(new { message = "Inventory not found" });
            }

            // Return the found inventory
            return Ok(inventory);
        }

        [HttpPut("UpdateInventory")]
        public async Task<IActionResult> UpdateInventory([FromBody] Inventory inventory)
        {
            // Validate the incoming inventory object
            if (inventory == null || inventory.ID <= 0)
            {
                return BadRequest(new { message = "Invalid inventory data" });
            }

            // Call the service to update the inventory
            var isUpdated = await _inventoryService.UpdateInventory(inventory);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "Inventory not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "Inventory updated successfully" });
        }

        [HttpDelete("DeleteInventory/{id}")]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            // Call the service method to delete the inventory
            var isDeleted = await _inventoryService.DeleteInventory(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "Inventory not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "Inventory deleted successfully" });
        }


    }
}
