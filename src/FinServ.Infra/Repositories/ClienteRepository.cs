using FinServ.Domain.Entities.Clientes;
using FinServ.Domain.Repositories;
using FinServ.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinServ.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly FinServContext _context;
        private readonly ILogger<ClienteRepository> _logger;

        public ClienteRepository(FinServContext context, ILogger<ClienteRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
            try
            {
                await _context.Clientes.AddAsync(cliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cadastrar cliente: {cliente}", cliente);
                throw new InvalidOperationException("Erro ao cadastrar cliente.", ex);
            }
        }

        public Task<Cliente> DeleteClienteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente?> GetClienteByCpfAsync(string cpf)
        {
            try
            {
                return await _context.Clientes.FirstOrDefaultAsync(i => i.Cpf == cpf);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter cliente por CPF: {Cpf}", cpf);
                throw new InvalidOperationException("Erro ao obter cliente por CPF.", ex);
            }
        }

        public async Task<Cliente?> GetClienteByIdAsync(int id)
        {
            try
            {
                return await _context.Clientes.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter cliente por ID: {Id}", id);
                throw new InvalidOperationException("Erro ao obter cliente por ID.", ex);
            }
        }

        public Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
