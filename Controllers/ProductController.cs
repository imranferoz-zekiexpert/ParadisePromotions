
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsService _productsService;
        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }
        [HttpGet]
        [Route("Products")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var users = await _productsService.GetAllProducts();
                return Ok(users);
            }
            catch (Exception ex)
            {

                return BadRequest();    
            }
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] Products model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _productsService.CreateProduct(model);
                    return Ok(new { message = "Product created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }
        

        [HttpGet("Product/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            // Call the service method to get the user by id
            var user = await _productsService.GetProductById(id);

            // Check if the user is null (i.e., user not found or invalid id)
            if (user == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            // Return the found user
            return Ok(user);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] Products user)
        {
            // Validate the incoming user object
            if (user == null || user.ID <= 0)
            {
                return BadRequest(new { message = "Invalid user data" });
            }

            // Call the service to update the user
            var isUpdated = await _productsService.UpdateProduct(user);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "Product not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "Product updated successfully" });
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            // Call the service method to delete the user
            var isDeleted = await _productsService.DeleteProduct(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "Product not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "Product deleted successfully" });
        }


    }
}
