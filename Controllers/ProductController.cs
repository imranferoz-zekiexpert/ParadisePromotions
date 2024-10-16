
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]") , Authorize]
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
                var products = await _productsService.GetAllProducts();
                return Ok(products);
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
            // Call the service method to get the product by id
            var product = await _productsService.GetProductById(id);

            // Check if the product is null (i.e., product not found or invalid id)
            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            // Return the found product
            return Ok(product);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] Products product)
        {
            // Validate the incoming product object
            if (product == null || product.ID <= 0)
            {
                return BadRequest(new { message = "Invalid product data" });
            }

            // Call the service to update the product
            var isUpdated = await _productsService.UpdateProduct(product);

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
            // Call the service method to delete the product
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
