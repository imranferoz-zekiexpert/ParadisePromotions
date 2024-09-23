using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Data;
using System.Threading.Tasks;

namespace ParadisePromotions.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContextClass _dbContext;
        public IUserRepository Users { get; }

        public UnitOfWork(
            DBContextClass dbContext,
            IUserRepository userRepository
            )
        {
            _dbContext = dbContext;
            Users = userRepository;
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
