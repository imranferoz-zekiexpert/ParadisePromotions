using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories
{
    public class CustomersRepository :GenericRepository<Customer>, ICustomersRepository
    {
        public CustomersRepository(DBContextClass dbContext):base(dbContext) { }
    }
}