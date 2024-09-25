
using Microsoft.EntityFrameworkCore;
using ParadisePromotions.Core.Models;

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
    }

}
