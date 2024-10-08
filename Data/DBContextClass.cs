
using Microsoft.EntityFrameworkCore;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Core.Models.Codes;

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
    }

}
