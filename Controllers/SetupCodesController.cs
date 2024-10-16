
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Core.Models.Codes;
using ParadisePromotions.Core.Services;

namespace ParadisePromotions.Controllers
{
    [Route("api/[controller]") , Authorize]
    [ApiController]
    public class SetupCodesController : ControllerBase
    {
        private readonly ISetupCodesService _setupCodesService;
        public SetupCodesController(ISetupCodesService setupCodesService)
        {
            _setupCodesService = setupCodesService;
        }

        // Zip CRUD operations


        [HttpGet]
        [Route("Zip")]
        public async Task<IActionResult> GetZip()
        {
            try
            {
                var zip = await _setupCodesService.GetAllZip();
                return Ok(zip);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddZip")]
        public async Task<IActionResult> CreateZip([FromBody] Zips model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _setupCodesService.CreateZip(model);
                    return Ok(new { message = "Zip created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }


        [HttpGet("Zip/{id}")]
        public async Task<IActionResult> GetZipById(int id)
        {
            // Call the service method to get the saleType by id
            var zip = await _setupCodesService.GetZipById(id);

            // Check if the saleType is null (i.e., saleType not found or invalid id)
            if (zip == null)
            {
                return NotFound(new { message = "Zip not found" });
            }

            // Return the found saleType
            return Ok(zip);
        }

        [HttpPut("UpdateZip")]
        public async Task<IActionResult> UpdateZip([FromBody] Zips zip)
        {
            // Validate the incoming saleType object
            if (zip == null || zip.ID <= 0)
            {
                return BadRequest(new { message = "Invalid zip data" });
            }

            // Call the service to update the saleType
            var isUpdated = await _setupCodesService.UpdateZip(zip);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "Zip not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "Zip updated successfully" });
        }

        [HttpDelete("DeleteZip/{id}")]
        public async Task<IActionResult> DeleteZip(int id)
        {
            // Call the service method to delete the saleType
            var isDeleted = await _setupCodesService.DeleteZip(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "Zip not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "Zip deleted successfully" });
        }

        // SaleType CRUD operations
        [HttpGet]
        [Route("SaleType")]
        public async Task<IActionResult> GetSaleType()
        {
            try
            {
                var saleType = await _setupCodesService.GetAllSaleType();
                return Ok(saleType);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddSaleType")]
        public async Task<IActionResult> CreateSaleType([FromBody] SaleType model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _setupCodesService.CreateSaleType(model);
                    return Ok(new { message = "SaleType created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }

        [HttpGet("SaleType/{id}")]
        public async Task<IActionResult> GetSaleTypeById(int id)
        {
            // Call the service method to get the saleType by id
            var saleType = await _setupCodesService.GetSaleTypeById(id);

            // Check if the saleType is null (i.e., saleType not found or invalid id)
            if (saleType == null)
            {
                return NotFound(new { message = "SaleType not found" });
            }

            // Return the found saleType
            return Ok(saleType);
        }

        [HttpPut("UpdateSaleType")]
        public async Task<IActionResult> UpdateSaleType([FromBody] SaleType saleType)
        {
            // Validate the incoming saleType object
            if (saleType == null || saleType.ID <= 0)
            {
                return BadRequest(new { message = "Invalid saleType data" });
            }

            // Call the service to update the saleType
            var isUpdated = await _setupCodesService.UpdateSaleType(saleType);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "SaleType not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "SaleType updated successfully" });
        }

        [HttpDelete("DeleteSaleType/{id}")]
        public async Task<IActionResult> DeleteSaleType(int id)
        {
            // Call the service method to delete the saleType
            var isDeleted = await _setupCodesService.DeleteSaleType(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "SaleType not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "SaleType deleted successfully" });
        }

        // ReturnType CRUD operations

        [HttpGet]
        [Route("ReturnType")]
        public async Task<IActionResult> GetReturnType()
        {
            try
            {
                var returnType = await _setupCodesService.GetAllReturnType();
                return Ok(returnType);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddReturnType")]
        public async Task<IActionResult> CreateReturnType([FromBody] ReturnType model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _setupCodesService.CreateReturnType(model);
                    return Ok(new { message = "ReturnType created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }


        [HttpGet("ReturnType/{id}")]
        public async Task<IActionResult> GetReturnTypeById(int id)
        {
            // Call the service method to get the returnType by id
            var returnType = await _setupCodesService.GetReturnTypeById(id);

            // Check if the returnType is null (i.e., returnType not found or invalid id)
            if (returnType == null)
            {
                return NotFound(new { message = "ReturnType not found" });
            }

            // Return the found returnType
            return Ok(returnType);
        }

        [HttpPut("UpdateReturnType")]
        public async Task<IActionResult> UpdateReturnType([FromBody] ReturnType returnType)
        {
            // Validate the incoming returnType object
            if (returnType == null || returnType.ID <= 0)
            {
                return BadRequest(new { message = "Invalid returnType data" });
            }

            // Call the service to update the returnType
            var isUpdated = await _setupCodesService.UpdateReturnType(returnType);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "ReturnType not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "ReturnType updated successfully" });
        }

        [HttpDelete("DeleteReturnType/{id}")]
        public async Task<IActionResult> DeleteReturnType(int id)
        {
            // Call the service method to delete the returnType
            var isDeleted = await _setupCodesService.DeleteReturnType(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "ReturnType not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "ReturnType deleted successfully" });
        }

        // ProductColor CRUD operations

        [HttpGet]
        [Route("ProductColor")]
        public async Task<IActionResult> GetProductColor()
        {
            try
            {
                var productColor = await _setupCodesService.GetAllProductColor();
                return Ok(productColor);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddProductColor")]
        public async Task<IActionResult> CreateProductColor([FromBody] ProductColor model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _setupCodesService.CreateProductColor(model);
                    return Ok(new { message = "Product Color created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }


        [HttpGet("ProductColor/{id}")]
        public async Task<IActionResult> GetProductColorById(int id)
        {
            // Call the service method to get the productColor by id
            var productColor = await _setupCodesService.GetProductColorById(id);

            // Check if the productColor is null (i.e., productColor not found or invalid id)
            if (productColor == null)
            {
                return NotFound(new { message = "ProductColor not found" });
            }

            // Return the found productColor
            return Ok(productColor);
        }

        [HttpPut("UpdateProductColor")]
        public async Task<IActionResult> UpdateProductColor([FromBody] ProductColor productColor)
        {
            // Validate the incoming productColor object
            if (productColor == null || productColor.ID <= 0)
            {
                return BadRequest(new { message = "Invalid productColor data" });
            }

            // Call the service to update the productColor
            var isUpdated = await _setupCodesService.UpdateProductColor(productColor);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "ProductColor not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "ProductColor updated successfully" });
        }

        [HttpDelete("DeleteProductColor/{id}")]
        public async Task<IActionResult> DeleteProductColor(int id)
        {
            // Call the service method to delete the productColor
            var isDeleted = await _setupCodesService.DeleteProductColor(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "ProductColor not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "ProductColor deleted successfully" });
        }


        // Colors CRUD operations

        [HttpGet]
        [Route("Colors")]
        public async Task<IActionResult> GetColors()
        {
            try
            {
                var colors = await _setupCodesService.GetAllColors();
                return Ok(colors);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddColors")]
        public async Task<IActionResult> CreateColors([FromBody] Colors model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _setupCodesService.CreateColors(model);
                    return Ok(new { message = "Colors created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }


        [HttpGet("Colors/{id}")]
        public async Task<IActionResult> GetColorsById(int id)
        {
            // Call the service method to get the color by id
            var color = await _setupCodesService.GetColorsById(id);

            // Check if the color is null (i.e., color not found or invalid id)
            if (color == null)
            {
                return NotFound(new { message = "Colors not found" });
            }

            // Return the found color
            return Ok(color);
        }

        [HttpPut("UpdateColors")]
        public async Task<IActionResult> UpdateColors([FromBody] Colors color)
        {
            // Validate the incoming color object
            if (color == null || color.ID <= 0)
            {
                return BadRequest(new { message = "Invalid color data" });
            }

            // Call the service to update the color
            var isUpdated = await _setupCodesService.UpdateColors(color);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "Colors not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "Colors updated successfully" });
        }

        [HttpDelete("DeleteColors/{id}")]
        public async Task<IActionResult> DeleteColors(int id)
        {
            // Call the service method to delete the color
            var isDeleted = await _setupCodesService.DeleteColors(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "Colors not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "Colors deleted successfully" });
        }

        // PrintLocation CRUD operations

        [HttpGet]
        [Route("PrintLocation")]
        public async Task<IActionResult> GetPrintLocation()
        {
            try
            {
                var printLocation = await _setupCodesService.GetAllPrintLocation();
                return Ok(printLocation);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddPrintLocation")]
        public async Task<IActionResult> CreatePrintLocation([FromBody] PrintLocation model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _setupCodesService.CreatePrintLocation(model);
                    return Ok(new { message = "PrintLocation created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }


        [HttpGet("PrintLocation/{id}")]
        public async Task<IActionResult> GetPrintLocationById(int id)
        {
            // Call the service method to get the printLocation by id
            var printLocation = await _setupCodesService.GetPrintLocationById(id);

            // Check if the printLocation is null (i.e., printLocation not found or invalid id)
            if (printLocation == null)
            {
                return NotFound(new { message = "PrintLocation not found" });
            }

            // Return the found printLocation
            return Ok(printLocation);
        }

        [HttpPut("UpdatePrintLocation")]
        public async Task<IActionResult> UpdatePrintLocation([FromBody] PrintLocation printLocation)
        {
            // Validate the incoming printLocation object
            if (printLocation == null || printLocation.ID <= 0)
            {
                return BadRequest(new { message = "Invalid printLocation data" });
            }

            // Call the service to update the printLocation
            var isUpdated = await _setupCodesService.UpdatePrintLocation(printLocation);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "PrintLocation not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "PrintLocation updated successfully" });
        }

        [HttpDelete("DeletePrintLocation/{id}")]
        public async Task<IActionResult> DeletePrintLocation(int id)
        {
            // Call the service method to delete the printLocation
            var isDeleted = await _setupCodesService.DeletePrintLocation(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "PrintLocation not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "PrintLocation deleted successfully" });
        }

        // PaymentMethod CRUD operations

        [HttpGet]
        [Route("PaymentMethod")]
        public async Task<IActionResult> GetPaymentMethod()
        {
            try
            {
                var paymentMethod = await _setupCodesService.GetAllPaymentMethod();
                return Ok(paymentMethod);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddPaymentMethod")]
        public async Task<IActionResult> CreatePaymentMethod([FromBody] PaymentMethod model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _setupCodesService.CreatePaymentMethod(model);
                    return Ok(new { message = "PaymentMethod created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }


        [HttpGet("PaymentMethod/{id}")]
        public async Task<IActionResult> GetPaymentMethodById(int id)
        {
            // Call the service method to get the paymentMethod by id
            var paymentMethod = await _setupCodesService.GetPaymentMethodById(id);

            // Check if the paymentMethod is null (i.e., paymentMethod not found or invalid id)
            if (paymentMethod == null)
            {
                return NotFound(new { message = "PaymentMethod not found" });
            }

            // Return the found paymentMethod
            return Ok(paymentMethod);
        }

        [HttpPut("UpdatePaymentMethod")]
        public async Task<IActionResult> UpdatePaymentMethod([FromBody] PaymentMethod paymentMethod)
        {
            // Validate the incoming paymentMethod object
            if (paymentMethod == null || paymentMethod.ID <= 0)
            {
                return BadRequest(new { message = "Invalid paymentMethod data" });
            }

            // Call the service to update the paymentMethod
            var isUpdated = await _setupCodesService.UpdatePaymentMethod(paymentMethod);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "PaymentMethod not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "PaymentMethod updated successfully" });
        }

        [HttpDelete("DeletePaymentMethod/{id}")]
        public async Task<IActionResult> DeletePaymentMethod(int id)
        {
            // Call the service method to delete the paymentMethod
            var isDeleted = await _setupCodesService.DeletePaymentMethod(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "PaymentMethod not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "PaymentMethod deleted successfully" });
        }

        // Cycle CRUD operations

        [HttpGet]
        [Route("Cycles")]
        public async Task<IActionResult> GetCycles()
        {
            try
            {
                var cycle = await _setupCodesService.GetAllCycle();
                return Ok(cycle);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddCycles")]
        public async Task<IActionResult> CreateCycles([FromBody] Cycles model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _setupCodesService.CreateCycle(model);
                    return Ok(new { message = "Cycles created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }


        [HttpGet("Cycles/{id}")]
        public async Task<IActionResult> GetCyclesById(int id)
        {
            // Call the service method to get the cycle by id
            var cycle = await _setupCodesService.GetCycleById(id);

            // Check if the cycle is null (i.e., cycle not found or invalid id)
            if (cycle == null)
            {
                return NotFound(new { message = "Cycles not found" });
            }

            // Return the found cycle
            return Ok(cycle);
        }

        [HttpPut("UpdateCycles")]
        public async Task<IActionResult> UpdateCycles([FromBody] Cycles cycle)
        {
            // Validate the incoming cycle object
            if (cycle == null || cycle.ID <= 0)
            {
                return BadRequest(new { message = "Invalid cycle data" });
            }

            // Call the service to update the cycle
            var isUpdated = await _setupCodesService.UpdateCycle(cycle);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "Cycles not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "Cycles updated successfully" });
        }

        [HttpDelete("DeleteCycles/{id}")]
        public async Task<IActionResult> DeleteCycles(int id)
        {
            // Call the service method to delete the cycle
            var isDeleted = await _setupCodesService.DeleteCycle(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "Cycles not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "Cycles deleted successfully" });
        }


        // Disposition CRUD operations

        [HttpGet]
        [Route("Disposition")]
        public async Task<IActionResult> GetDisposition()
        {
            try
            {
                var disposition = await _setupCodesService.GetAllDisposition();
                return Ok(disposition);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddDisposition")]
        public async Task<IActionResult> CreateDisposition([FromBody] Disposition model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _setupCodesService.CreateDisposition(model);
                    return Ok(new { message = "Disposition created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }


        [HttpGet("Disposition/{id}")]
        public async Task<IActionResult> GetDispositionById(int id)
        {
            // Call the service method to get the disposition by id
            var disposition = await _setupCodesService.GetDispositionById(id);

            // Check if the disposition is null (i.e., disposition not found or invalid id)
            if (disposition == null)
            {
                return NotFound(new { message = "Disposition not found" });
            }

            // Return the found disposition
            return Ok(disposition);
        }

        [HttpPut("UpdateDisposition")]
        public async Task<IActionResult> UpdateDisposition([FromBody] Disposition disposition)
        {
            // Validate the incoming disposition object
            if (disposition == null || disposition.DispositionID <= 0)
            {
                return BadRequest(new { message = "Invalid disposition data" });
            }

            // Call the service to update the disposition
            var isUpdated = await _setupCodesService.UpdateDisposition(disposition);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "Disposition not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "Disposition updated successfully" });
        }

        [HttpDelete("DeleteDisposition/{id}")]
        public async Task<IActionResult> DeleteDisposition(int id)
        {
            // Call the service method to delete the disposition
            var isDeleted = await _setupCodesService.DeleteDisposition(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "Disposition not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "Disposition deleted successfully" });
        }

        // Levels CRUD operations

        [HttpGet]
        [Route("Levels")]
        public async Task<IActionResult> GetLevels()
        {
            try
            {
                var products = await _setupCodesService.GetAllLevels();
                return Ok(products);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddLevels")]
        public async Task<IActionResult> CreateLevels([FromBody] Levels model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _setupCodesService.CreateLevels(model);
                    return Ok(new { message = "Levels created successfully" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }

            return BadRequest(ModelState);
        }


        [HttpGet("Levels/{id}")]
        public async Task<IActionResult> GetLevelsById(int id)
        {
            // Call the service method to get the product by id
            var product = await _setupCodesService.GetLevelsById(id);

            // Check if the product is null (i.e., product not found or invalid id)
            if (product == null)
            {
                return NotFound(new { message = "Levels not found" });
            }

            // Return the found product
            return Ok(product);
        }

        [HttpPut("UpdateLevels")]
        public async Task<IActionResult> UpdateLevels([FromBody] Levels product)
        {
            // Validate the incoming product object
            if (product == null || product.ID <= 0)
            {
                return BadRequest(new { message = "Invalid product data" });
            }

            // Call the service to update the product
            var isUpdated = await _setupCodesService.UpdateLevels(product);

            // Check if the update was successful
            if (!isUpdated)
            {
                return NotFound(new { message = "Levels not found or update failed" });
            }

            // Return a success response
            return Ok(new { message = "Levels updated successfully" });
        }

        [HttpDelete("DeleteLevels/{id}")]
        public async Task<IActionResult> DeleteLevels(int id)
        {
            // Call the service method to delete the product
            var isDeleted = await _setupCodesService.DeleteLevels(id);

            // If deletion was unsuccessful, return a not found or bad request response
            if (!isDeleted)
            {
                return NotFound(new { message = "Levels not found or deletion failed." });
            }

            // If deletion was successful
            return Ok(new { message = "Levels deleted successfully" });
        }


    }
}
