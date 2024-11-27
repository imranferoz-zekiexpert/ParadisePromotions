using ParadisePromotions.Core.Interfaces.ICodes;
using ParadisePromotions.Core.Interfaces.IReportsRepositories;

namespace ParadisePromotions.Core.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository Users { get; }
        IProductsRepository Products { get; }
        ICustomersRepository Customers { get; }
        IInvoiceDetailsRepository InvoiceDetails { get; }
        IBlankSalesRepository BlankSales { get; }
        IInvoicesRepository Invoices { get; }
        IInventoryRepository Inventory { get; }
        IQryBlankSalePrintGreenSheetMainRepository QryBlankSalePrintGreenSheetMain { get; }
        IZipRepository Zip { get; }
        ISaleTypeRepository SaleType { get; }
        IProductColorRepository ProductColor { get; }
        IColorsRepository Colors { get; }
        IPrintLocationRepository PrintLocation { get; }
        IPaymentMethodRepository PaymentMethod { get; }
        ICyclesRepository Cycles { get; }
        IDispositionRepository Disposition { get; }
        IReturnTypeRepository ReturnType { get; }
        ILevelsRepository Levels { get; }
        INotesHistoryRepository NotesHistory { get; }
        IParsRepository Pars { get; }
        IBonusRepository Bonus { get; }
        ITimeZonesRepository TimeZones { get; }
        ITouchLogRepository TouchLog { get; }
        IChargeBackRepository ChargeBack { get; }

        // Reports 
        IBuyingHistoryRepository BuyingHistory { get; }
        ILastDispositionRepository LastDisposition { get; }
        INextCallBackRepository NextCallBack { get; }

        //Admin 
        IRoleManagementRepository RoleManagement { get; }
        IRoleModulesRepository RoleModules { get; }
        IAppModuleRepository AppModule { get; }
        int Save();
    }
}
