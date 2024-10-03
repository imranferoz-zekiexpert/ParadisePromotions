using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Data;
using System.Threading.Tasks;

namespace ParadisePromotions.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContextClass _dbContext;
        public IUserRepository Users { get; }
        public IProductsRepository Products { get; }
        public ICustomersRepository Customers { get; }
        public IInvoiceDetailsRepository InvoiceDetails { get; }
        public IBlankSalesRepository BlankSales { get; }
        public IInvoicesRepository Invoices { get; }
        public IInventoryRepository Inventory { get; }
        public IQryBlankSalePrintGreenSheetMainRepository QryBlankSalePrintGreenSheetMain { get; }

        public UnitOfWork(
            DBContextClass dbContext,
            IUserRepository userRepository,
            IProductsRepository productsRepository,
            ICustomersRepository customersRepository,
            IInvoiceDetailsRepository invoiceDetailsRepository,
            IBlankSalesRepository blankSalesRepository,
            IInvoicesRepository invoicesRepository,
            IInventoryRepository inventoryRepository,
            IQryBlankSalePrintGreenSheetMainRepository qryBlankSalePrintGreenSheetMain
            )
        {
            _dbContext = dbContext;
            Users = userRepository;
            Products = productsRepository;
            Customers = customersRepository;
            InvoiceDetails = invoiceDetailsRepository;
            BlankSales = blankSalesRepository;
            Invoices = invoicesRepository;
            Inventory = inventoryRepository;
            QryBlankSalePrintGreenSheetMain = qryBlankSalePrintGreenSheetMain;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
