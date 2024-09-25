using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories
{
    public class InvoiceDetailsRepository :GenericRepository<InvoiceDetail>, IInvoiceDetailsRepository
    {
        public InvoiceDetailsRepository(DBContextClass dbContext):base(dbContext) { }
    }
}