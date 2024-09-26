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
        IQryBlankSalePrintGreenSheetMainRepository QryBlankSalePrintGreenSheetMain { get; }
        int Save();
    }
}
