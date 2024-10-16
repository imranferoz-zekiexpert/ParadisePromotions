
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]") , Authorize]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;
        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }
        [HttpGet]
        [Route("Customers")]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customers = await _customersService.GetAllCustomers();
                return Ok(customers);
            }
            catch (Exception ex)
            {

                return BadRequest();    
            }
        }

        [HttpPost]
        [Route("AddCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _customersService.CreateCustomer(model);
                    return Ok(new { message = "Customer created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }
        

        [HttpGet("Customer/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            // Call the service method to get the customer by id
            var customer = await _customersService.GetCustomerById(id);

            // Check if the customer is null (i.e., customer not found or invalid id)
            if (customer == null)
            {
                return NotFound(new { message = "Customer not found" });
            }

            // Return the found customer
            return Ok(customer);
        }

        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
        {
            // Validate the incoming customer object
            if (customer == null || customer.ID <= 0)
            {
                return BadRequest(new { message = "Invalid customer data" });
            }

            // Call the service to update the customer
            var isUpdated = await _customersService.UpdateCustomer(customer);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "Customer not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "Customer updated successfully" });
        }

        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            // Call the service method to delete the customer
            var isDeleted = await _customersService.DeleteCustomer(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "Customer not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "Customer deleted successfully" });
        }


    }
}
