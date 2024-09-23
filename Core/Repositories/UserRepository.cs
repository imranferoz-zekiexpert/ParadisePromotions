using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories
{
    public class UserRepository :GenericRepository<UserModel>, IUserRepository
    {
        public UserRepository(DBContextClass dbContext):base(dbContext) { }
    }
}