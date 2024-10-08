﻿using ParadisePromotions.Core.Interfaces.ICodes;

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
        int Save();
    }
}
