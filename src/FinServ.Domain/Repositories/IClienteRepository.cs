using FinServ.Domain.Entities.Clientes;

namespace FinServ.Domain.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente?> GetByCpfAsync(string cpf);
    }
}
