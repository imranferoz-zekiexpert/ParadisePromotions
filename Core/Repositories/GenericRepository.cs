using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Data;
using Microsoft.EntityFrameworkCore;

namespace ParadisePromotions.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DBContextClass _dbContext;

        public GenericRepository(DBContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Update(T obj)
        {
            _dbContext.Set<T>().Update(obj);
        }
       }
    }
