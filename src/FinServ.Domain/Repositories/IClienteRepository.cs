using FinServ.Domain.Entities.Clientes;

namespace FinServ.Domain.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente?> GetByIdAsync(int id);
        Task<Cliente?> GetByCpfAsync(string cpf);
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente> AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(Cliente cliente);
    }
}
