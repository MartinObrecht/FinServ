using FinServ.Domain.Entities.Clientes;

namespace FinServ.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<Cliente> GetClienteByCpfAsync(string cpf);
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task AddClienteAsync(Cliente cliente);
        Task<Cliente> UpdateClienteAsync(Cliente cliente);
        Task<Cliente> DeleteClienteAsync(int id);
    }
}
