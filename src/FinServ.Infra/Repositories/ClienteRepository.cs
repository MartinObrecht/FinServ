using FinServ.Domain.Entities.Clientes;
using FinServ.Domain.Repositories;
using FinServ.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinServ.Infra.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        private readonly FinServContext _context;
        private readonly ILogger<ClienteRepository> _logger;

        public ClienteRepository(FinServContext context, ILogger<ClienteRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Cliente?> GetByCpfAsync(string cpf)
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
    }
}
