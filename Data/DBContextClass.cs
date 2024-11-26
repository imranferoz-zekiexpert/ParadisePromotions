
using Microsoft.EntityFrameworkCore;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Core.Models.Codes;
using ParadisePromotions.Core.Models.ReportsModels;

namespace ParadisePromotions.Data
{
    public class DBContextClass : DbContext
    {
        public DBContextClass(DbContextOptions<DBContextClass> options) : base(options) { }

    DbSet<Staff> Staff { get; set; } = null!;
    DbSet<Products> Products { get; set; } = null!;
    DbSet<Customer> Customers { get; set; } = null!;
    DbSet<InvoiceDetail> InvoiceDetails { get; set; } = null!;
    DbSet<BlankSale> BlankSales { get; set; } = null!;
    DbSet<Invoice> Invoices { get; set; } = null!;
    DbSet<Inventory> Inventory { get; set; } = null!;
    DbSet<NotesHistory> NotesHistory { get; set; } = null!;
    DbSet<Pars> Pars { get; set; } = null!;
    DbSet<Bonus> Bonus { get; set; } = null!;
    DbSet<TimeZones> TimeZones { get; set; } = null!;
    DbSet<TouchLog> TouchLog { get; set; } = null!;
    DbSet<QryBlankSalePrintGreenSheetMain> QryBlankSalePrintGreenSheetMain { get; set; } = null!;
    // Setup Codes
    DbSet<Zips> Zip { get; set; } = null!;
    DbSet<SaleType> SaleType { get; set; } = null!;
    DbSet<ReturnType> ReturnType { get; set; } = null!;
    DbSet<ProductColor> ProductColor { get; set; } = null!;
    DbSet<Colors> Colors { get; set; } = null!;
    DbSet<PrintLocation> PrintLocation { get; set; } = null!;
    DbSet<PaymentMethod> PaymentMethod { get; set; } = null!;
    DbSet<Cycles> Cycles { get; set; } = null!;
    DbSet<Disposition> Disposition { get; set; } = null!;
    DbSet<Levels> Levels { get; set; } = null!;
    DbSet<ChargeBack> ChargeBack { get; set; } = null!;

    // Reports
    DbSet<BuyingHistory> BuyingHistory { get; set; } = null!;
    DbSet<LastDisposition> LastDisposition { get; set; } = null!;
    DbSet<NextCallBack> NextCallBack { get; set; } = null!;


        // Admin
        DbSet<UserRole> UserRoles { get; set; } = null!;
        DbSet<AppModule> AppModules { get; set; } = null!;
        DbSet<RoleModule> RoleModules { get; set; } = null!;

    }

}
