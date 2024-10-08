using ParadisePromotions.Core.Models;
using ParadisePromotions.Core.Models.Codes;

namespace ParadisePromotions.Core.Interfaces.IServices
{
    public interface ISetupCodesService
    {
        // Zip CRUD operations
        Task<IEnumerable<Zips>> GetAllZip();
        Task<Zips> GetZipById(int id);
         Task<bool> CreateZip(Zips zip);
         Task<bool> UpdateZip(Zips zip);
         Task<bool> DeleteZip(int id);

        // SaleType CRUD operations
        Task<IEnumerable<SaleType>> GetAllSaleType();
        Task<SaleType> GetSaleTypeById(int id);
         Task<bool> CreateSaleType(SaleType saleType);
         Task<bool> UpdateSaleType(SaleType saleType);
         Task<bool> DeleteSaleType(int id);

        // ReturnType CRUD operations
        Task<IEnumerable<ReturnType>> GetAllReturnType();
        Task<ReturnType> GetReturnTypeById(int id);
         Task<bool> CreateReturnType(ReturnType returnType);
         Task<bool> UpdateReturnType(ReturnType returnType);
         Task<bool> DeleteReturnType(int id);

        // ProductColor CRUD operations
        Task<IEnumerable<ProductColor>> GetAllProductColor();
        Task<ProductColor> GetProductColorById(int id);
         Task<bool> CreateProductColor(ProductColor productColor);
         Task<bool> UpdateProductColor(ProductColor productColor);
         Task<bool> DeleteProductColor(int id);

        // Colors CRUD operations
        Task<IEnumerable<Colors>> GetAllColors();
        Task<Colors> GetColorsById(int id);
        Task<bool> CreateColors(Colors colors);
        Task<bool> UpdateColors(Colors colors);
        Task<bool> DeleteColors(int id);

        // PrintLocation CRUD operations
        Task<IEnumerable<PrintLocation>> GetAllPrintLocation();
        Task<PrintLocation> GetPrintLocationById(int id);
         Task<bool> CreatePrintLocation(PrintLocation printLocation);
         Task<bool> UpdatePrintLocation(PrintLocation printLocation);
         Task<bool> DeletePrintLocation(int id);

        // PaymentMethod CRUD operations
        Task<IEnumerable<PaymentMethod>> GetAllPaymentMethod();
        Task<PaymentMethod> GetPaymentMethodById(int id);
         Task<bool> CreatePaymentMethod(PaymentMethod paymentMethod);
         Task<bool> UpdatePaymentMethod(PaymentMethod paymentMethod);
         Task<bool> DeletePaymentMethod(int id);

        // Cycle CRUD operations
        Task<IEnumerable<Cycles>> GetAllCycle();
        Task<Cycles> GetCycleById(int id);
         Task<bool> CreateCycle(Cycles cycle);
         Task<bool> UpdateCycle(Cycles cycle);
         Task<bool> DeleteCycle(int id);

        // Disposition CRUD operations
        Task<IEnumerable<Disposition>> GetAllDisposition();
        Task<Disposition> GetDispositionById(int id);
         Task<bool> CreateDisposition(Disposition disposition);
         Task<bool> UpdateDisposition(Disposition disposition);
         Task<bool> DeleteDisposition(int id);


        // Levels CRUD operations
        Task<IEnumerable<Levels>> GetAllLevels();
        Task<Levels> GetLevelsById(int id);
        Task<bool> CreateLevels(Levels disposition);
        Task<bool> UpdateLevels(Levels disposition);
        Task<bool> DeleteLevels(int id);
    }
}
