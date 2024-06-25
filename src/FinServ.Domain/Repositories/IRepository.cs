namespace FinServ.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);

        Task<T?> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        void Update(T entity);

        Task DeleteAsync(T entity);
    }
}
