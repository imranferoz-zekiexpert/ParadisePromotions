using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Interfaces.ICodes;
using ParadisePromotions.Core.Interfaces.IReportsRepositories;
using ParadisePromotions.Core.Repositories.Codes;
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
        public IZipRepository Zip { get; }
        public ISaleTypeRepository SaleType { get; }
        public IProductColorRepository ProductColor { get; }
        public IColorsRepository Colors { get; }
        public IPrintLocationRepository PrintLocation { get; }
        public IPaymentMethodRepository PaymentMethod { get; }
        public ICyclesRepository Cycles { get; }
        public IDispositionRepository Disposition { get; }
        public IReturnTypeRepository ReturnType { get; }
        public ILevelsRepository Levels { get; }
        public INotesHistoryRepository NotesHistory { get; }
        public IParsRepository Pars { get; }
        public IBonusRepository Bonus { get; }
        public ITimeZonesRepository TimeZones { get; }
        public ITouchLogRepository TouchLog { get; }
        public IChargeBackRepository ChargeBack { get; }
        public IBuyingHistoryRepository BuyingHistory { get; }


        public UnitOfWork(
            DBContextClass dbContext,
            IUserRepository userRepository,
            IProductsRepository productsRepository,
            ICustomersRepository customersRepository,
            IInvoiceDetailsRepository invoiceDetailsRepository,
            IBlankSalesRepository blankSalesRepository,
            IInvoicesRepository invoicesRepository,
            IInventoryRepository inventoryRepository,
            IQryBlankSalePrintGreenSheetMainRepository qryBlankSalePrintGreenSheetMainRepository,
            IZipRepository zipRepository,
            ISaleTypeRepository saleTypeRepository,
            IProductColorRepository productColorRepository,
            IColorsRepository colorsRepository,
            IPrintLocationRepository printLocationRepository,
            IPaymentMethodRepository paymentMethodRepository,
            ICyclesRepository cyclesRepository,
            IDispositionRepository dispositionRepository,
            IReturnTypeRepository returnTypeRepository,
            ILevelsRepository levelsRepository,
            INotesHistoryRepository notesHistoryRepository,
            IParsRepository parsRepository,
            IBonusRepository bonusRepository,
            ITimeZonesRepository timeZonesRepository,
            ITouchLogRepository touchLogRepository,
            IChargeBackRepository chargeBackRepository,
            IBuyingHistoryRepository buyingHistoryRepository
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
            QryBlankSalePrintGreenSheetMain = qryBlankSalePrintGreenSheetMainRepository;
            Zip = zipRepository;
            SaleType = saleTypeRepository;
            ProductColor = productColorRepository;
            Colors = colorsRepository;
            PrintLocation = printLocationRepository;
            PaymentMethod = paymentMethodRepository;
            Cycles = cyclesRepository;
            Disposition = dispositionRepository;
            ReturnType = returnTypeRepository;
            Levels = levelsRepository;
            NotesHistory = notesHistoryRepository;
            Pars = parsRepository;
            Bonus = bonusRepository;
            TimeZones = timeZonesRepository;
            TouchLog = touchLogRepository;
            ChargeBack = chargeBackRepository;
            BuyingHistory = buyingHistoryRepository;
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
