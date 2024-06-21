using FinServ.Domain.Entities.Clientes;
using FinServ.Domain.Interfaces.Clientes;
using FinServ.Domain.Repositories.Investidores;
using FinServ.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinServ.Infra.Repositories
{
    public class InvestidorRepository : IInvestidorRepository
    {
        private readonly FinServContext _context;
        private readonly ILogger<InvestidorRepository> _logger;

        public InvestidorRepository(FinServContext context, ILogger<InvestidorRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Cadastrar(IInvestidor investidor)
        {
            try
            {
                await _context.Investidores.AddAsync((Investidor)investidor);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cadastrar investidor: {Investidor}", investidor);
                throw new InvalidOperationException("Erro ao cadastrar investidor.", ex);
            }
        }

        public async Task<IInvestidor?> ObterPorCpfAsync(string cpf)
        {
            try
            {
                return await _context.Investidores.FirstOrDefaultAsync(i => i.Cpf == cpf);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter investidor por CPF: {Cpf}", cpf);
                throw new InvalidOperationException("Erro ao obter investidor por CPF.", ex);
            }
        }

        public async Task<IInvestidor?> ObterPorIdAsync(int id)
        {
            try
            {
                return await _context.Investidores.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter investidor por ID: {Id}", id);
                throw new InvalidOperationException("Erro ao obter investidor por ID.", ex);
            }
        }


    }
}
