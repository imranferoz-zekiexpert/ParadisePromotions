using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories
{
    public class InvoicesRepository :GenericRepository<Invoice>, IInvoicesRepository
    {
        public InvoicesRepository(DBContextClass dbContext):base(dbContext) { }
    }
}