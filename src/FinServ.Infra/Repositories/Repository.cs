using FinServ.Domain.Repositories;
using FinServ.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace FinServ.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly FinServContext _finServContext;

        public Repository(FinServContext finServContext)
        {
            _finServContext = finServContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _finServContext.Set<T>().AddAsync(entity);
            return await Task.FromResult(entity);
        }

        public void Delete(T entity)
        {
            _finServContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _finServContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _finServContext.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _finServContext.Set<T>().Update(entity);
        }
    }
}
    