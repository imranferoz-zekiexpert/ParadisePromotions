using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Core.Models.Codes;

namespace ParadisePromotions.Core.Services
{
    public class SetupCodesService : ISetupCodesService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public SetupCodesService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        // Zip CRUD operations

        public async Task<bool> CreateZip(Zips zip)
        {
            if (zip != null)
            {

                await _unitOfWork.Zip.Insert(zip);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteZip(int id)
        {
            if (id > 0)
            {
                var zip = await _unitOfWork.Zip.GetById(id);
                if (zip != null)
                {
                    _unitOfWork.Zip.Delete(zip);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Zips>> GetAllZip()
        {
            var zips = await _unitOfWork.Zip.GetAll();
            return zips; ;
        }

        public async Task<Zips> GetZipById(int id)
        {
            if (id > 0)
            {
                var zip = await _unitOfWork.Zip.GetById(id);
                if (zip != null)
                {
                    return zip;
                }
            }
            return null;
        }

        public async Task<bool> UpdateZip(Zips zip)
        {
            if (zip == null)
            {
                return false;
            }

            // Fetch the existing Zip record from the database
            var existingZip = await _unitOfWork.Zip.GetById(zip.ID);
            if (existingZip == null)
            {
                return false;
            }

            // Update the properties of the existing zip record
            existingZip.Zip = zip.Zip;
            existingZip.State = zip.State;
            existingZip.City = zip.City;

            // Perform the update in the database
            _unitOfWork.Zip.Update(existingZip);

            // Save the changes
            var result = _unitOfWork.Save();
            return result > 0;
        }



        // SaleType CRUD operations
        public async Task<bool> CreateSaleType(SaleType saleType)
        {
            if (saleType != null)
            {

                await _unitOfWork.SaleType.Insert(saleType);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteSaleType(int id)
        {
            if (id > 0)
            {
                var saleType = await _unitOfWork.SaleType.GetById(id);
                if (saleType != null)
                {
                    _unitOfWork.SaleType.Delete(saleType);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<SaleType>> GetAllSaleType()
        {
            var saleTypes = await _unitOfWork.SaleType.GetAll();
            return saleTypes; ;
        }

        public async Task<SaleType> GetSaleTypeById(int id)
        {
            if (id > 0)
            {
                var saleType = await _unitOfWork.SaleType.GetById(id);
                if (saleType != null)
                {
                    return saleType;
                }
            }
            return null;
        }

        public async Task<bool> UpdateSaleType(SaleType saleType)
        {
            if (saleType == null)
            {
                return false;
            }

            var existingSaleType = await _unitOfWork.SaleType.GetById(saleType.ID);
            if (existingSaleType == null)
            {
                return false;
            }

            // Update only the necessary properties of the existing SaleType
            existingSaleType.Sale_Type = saleType.Sale_Type;
            _unitOfWork.SaleType.Update(existingSaleType);

            // Save the changes
            var result = _unitOfWork.Save();
            return result > 0;
        }

        // ReturnType CRUD operations
        public async Task<bool> CreateReturnType(ReturnType returnType)
        {
            if (returnType != null)
            {

                await _unitOfWork.ReturnType.Insert(returnType);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteReturnType(int id)
        {
            if (id > 0)
            {
                var returnType = await _unitOfWork.ReturnType.GetById(id);
                if (returnType != null)
                {
                    _unitOfWork.ReturnType.Delete(returnType);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<ReturnType>> GetAllReturnType()
        {
            var returnTypes = await _unitOfWork.ReturnType.GetAll();
            return returnTypes; ;
        }

        public async Task<ReturnType> GetReturnTypeById(int id)
        {
            if (id > 0)
            {
                var returnType = await _unitOfWork.ReturnType.GetById(id);
                if (returnType != null)
                {
                    return returnType;
                }
            }
            return null;
        }

        public async Task<bool> UpdateReturnType(ReturnType returnType)
        {
            if (returnType == null)
            {
                return false;
            }

            var existingReturnType = await _unitOfWork.ReturnType.GetById(returnType.ID);
            if (existingReturnType == null)
            {
                return false;
            }

            // Update only the necessary property of the existing ReturnType
            existingReturnType.Return_Type = returnType.Return_Type;
            _unitOfWork.ReturnType.Update(existingReturnType);

            // Save the changes
            var result = _unitOfWork.Save(); // Assuming SaveAsync is an async method
            return result > 0;
        }

        // ProductColor CRUD operations
        public async Task<bool> CreateProductColor(ProductColor productColor)
        {
            if (productColor != null)
            {

                await _unitOfWork.ProductColor.Insert(productColor);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteProductColor(int id)
        {
            if (id > 0)
            {
                var productColor = await _unitOfWork.ProductColor.GetById(id);
                if (productColor != null)
                {
                    _unitOfWork.ProductColor.Delete(productColor);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<ProductColor>> GetAllProductColor()
        {
            var productColors = await _unitOfWork.ProductColor.GetAll();
            return productColors; ;
        }

        public async Task<ProductColor> GetProductColorById(int id)
        {
            if (id > 0)
            {
                var productColor = await _unitOfWork.ProductColor.GetById(id);
                if (productColor != null)
                {
                    return productColor;
                }
            }
            return null;
        }

        public async Task<bool> UpdateProductColor(ProductColor productColor)
        {
            if (productColor == null)
            {
                return false;
            }

            var existingProductColor = await _unitOfWork.ProductColor.GetById(productColor.ID);
            if (existingProductColor == null)
            {
                return false;
            }

            // Update only the necessary property of the existing ProductColor
            existingProductColor.Color = productColor.Color;
            _unitOfWork.ProductColor.Update(existingProductColor);

            // Save the changes
            var result = _unitOfWork.Save(); // Assuming SaveAsync is an async method
            return result > 0;
        }

        // PrintLocation CRUD operations
        public async Task<bool> CreatePrintLocation(PrintLocation printLocation)
        {
            if (printLocation != null)
            {

                await _unitOfWork.PrintLocation.Insert(printLocation);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeletePrintLocation(int id)
        {
            if (id > 0)
            {
                var printLocation = await _unitOfWork.PrintLocation.GetById(id);
                if (printLocation != null)
                {
                    _unitOfWork.PrintLocation.Delete(printLocation);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<PrintLocation>> GetAllPrintLocation()
        {
            var printLocations = await _unitOfWork.PrintLocation.GetAll();
            return printLocations; ;
        }

        public async Task<PrintLocation> GetPrintLocationById(int id)
        {
            if (id > 0)
            {
                var printLocation = await _unitOfWork.PrintLocation.GetById(id);
                if (printLocation != null)
                {
                    return printLocation;
                }
            }
            return null;
        }

        public async Task<bool> UpdatePrintLocation(PrintLocation printLocation)
        {
            if (printLocation == null)
            {
                return false;
            }

            var existingPrintLocation = await _unitOfWork.PrintLocation.GetById(printLocation.ID);
            if (existingPrintLocation == null)
            {
                return false;
            }

            // Update only the necessary property of the existing PrintLocation
            existingPrintLocation.Print_Location = printLocation.Print_Location;
            _unitOfWork.PrintLocation.Update(existingPrintLocation);

            // Save the changes
            var result = _unitOfWork.Save(); // Assuming SaveAsync is an async method
            return result > 0;
        }

        // PaymentMethod CRUD operations
        public async Task<bool> CreatePaymentMethod(PaymentMethod paymentMethod)
        {
            if (paymentMethod != null)
            {

                await _unitOfWork.PaymentMethod.Insert(paymentMethod);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeletePaymentMethod(int id)
        {
            if (id > 0)
            {
                var paymentMethod = await _unitOfWork.PaymentMethod.GetById(id);
                if (paymentMethod != null)
                {
                    _unitOfWork.PaymentMethod.Delete(paymentMethod);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<PaymentMethod>> GetAllPaymentMethod()
        {
            var paymentMethods = await _unitOfWork.PaymentMethod.GetAll();
            return paymentMethods; ;
        }

        public async Task<PaymentMethod> GetPaymentMethodById(int id)
        {
            if (id > 0)
            {
                var paymentMethod = await _unitOfWork.PaymentMethod.GetById(id);
                if (paymentMethod != null)
                {
                    return paymentMethod;
                }
            }
            return null;
        }

        public async Task<bool> UpdatePaymentMethod(PaymentMethod paymentMethod)
        {
            if (paymentMethod == null)
            {
                return false;
            }

            var existingPaymentMethod = await _unitOfWork.PaymentMethod.GetById(paymentMethod.ID);
            if (existingPaymentMethod == null)
            {
                return false;
            }

            // Update only the necessary property of the existing PaymentMethod
            existingPaymentMethod.Method = paymentMethod.Method;
            _unitOfWork.PaymentMethod.Update(existingPaymentMethod);

            // Save the changes
            var result = _unitOfWork.Save(); // Assuming SaveAsync is an async method
            return result > 0;
        }

        // Cycle CRUD operations
        public async Task<bool> CreateCycle(Cycles cycle)
        {
            if (cycle != null)
            {

                await _unitOfWork.Cycles.Insert(cycle);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteCycle(int id)
        {
            if (id > 0)
            {
                var cycle = await _unitOfWork.Cycles.GetById(id);
                if (cycle != null)
                {
                    _unitOfWork.Cycles.Delete(cycle);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Cycles>> GetAllCycle()
        {
            var cycles = await _unitOfWork.Cycles.GetAll();
            return cycles; ;
        }

        public async Task<Cycles> GetCycleById(int id)
        {
            if (id > 0)
            {
                var cycle = await _unitOfWork.Cycles.GetById(id);
                if (cycle != null)
                {
                    return cycle;
                }
            }
            return null;
        }

        public async Task<bool> UpdateCycle(Cycles cycle)
        {
            if (cycle == null)
            {
                return false;
            }

            var existingCycles = await _unitOfWork.Cycles.GetById(cycle.ID);
            if (existingCycles == null)
            {
                return false;
            }

            // Update only the necessary property of the existing Cycles
            existingCycles.Cycle = cycle.Cycle;
            _unitOfWork.Cycles.Update(existingCycles);

            // Save the changes
            var result = _unitOfWork.Save(); // Assuming SaveAsync is an async method
            return result > 0;
        }

        // Disposition CRUD operations
        public async Task<bool> CreateDisposition(Disposition disposition)
        {
            if (disposition != null)
            {

                await _unitOfWork.Disposition.Insert(disposition);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteDisposition(int id)
        {
            if (id > 0)
            {
                var disposition = await _unitOfWork.Disposition.GetById(id);
                if (disposition != null)
                {
                    _unitOfWork.Disposition.Delete(disposition);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Disposition>> GetAllDisposition()
        {
            var dispositions = await _unitOfWork.Disposition.GetAll();
            return dispositions; ;
        }

        public async Task<Disposition> GetDispositionById(int id)
        {
            if (id > 0)
            {
                var disposition = await _unitOfWork.Disposition.GetById(id);
                if (disposition != null)
                {
                    return disposition;
                }
            }
            return null;
        }

        public async Task<bool> UpdateDisposition(Disposition disposition)
        {
            if (disposition == null)
            {
                return false;
            }

            var existingDisposition = await _unitOfWork.Disposition.GetById(disposition.DispositionID);
            if (existingDisposition == null)
            {
                return false;
            }

            // Update only the necessary properties of the existing disposition
            existingDisposition.DispositionCode = disposition.DispositionCode;
            existingDisposition.DispositionDesc = disposition.DispositionDesc;
            existingDisposition.Active = disposition.Active;
            existingDisposition.SortOrder = disposition.SortOrder;

            // Perform the update in the database
            _unitOfWork.Disposition.Update(existingDisposition);

            // Save the changes
            var result =  _unitOfWork.Save(); // Assuming SaveAsync is an async method
            return result > 0;
        }



    }
}
