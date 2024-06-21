using FinServ.Domain.Entities.ProdutosFinanceiros;
using FinServ.Domain.Interfaces.ProdutosFinanceiros;
using FinServ.Domain.Repositories.ProdutosFinanceiros;
using FinServ.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinServ.Infra.Repositories
{
    public class ProdutoFinanceiroRepository : IProdutoFinaceiroRepository
    {
        private readonly FinServContext _context;
        private readonly ILogger<InvestidorRepository> _logger;

        public ProdutoFinanceiroRepository(FinServContext context, ILogger<InvestidorRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task CadastrarAsync(IProdutoFinanceiro produtoFinanceiro)
        {
            try
            {
                await _context.ProdutosFinanceiros.AddAsync((ProdutoFinanceiro)produtoFinanceiro);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cadastrar produto financeiro: {ProdutoFinanceiro}", produtoFinanceiro);
                throw new InvalidOperationException("Erro ao cadastrar produto financeiro.", ex);
            }
        }

        public async Task CadastrarEmLoteAsync(IEnumerable<IProdutoFinanceiro?> produtosFinanceiros)
        {
            try
            {
                await _context.ProdutosFinanceiros.AddRangeAsync(produtosFinanceiros.Select(pf => (ProdutoFinanceiro)pf));
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cadastrar produtos financeiros: {ProdutosFinanceiros}", produtosFinanceiros);
                throw new InvalidOperationException("Erro ao cadastrar produtos financeiros.", ex);
            }
        }

        public async Task<IProdutoFinanceiro?> ObterPorIdAsync(int id)
        {
            try
            {
                return await _context.ProdutosFinanceiros.AsNoTracking().FirstOrDefaultAsync(pf => pf.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter produto financeiro por ID: {Id}", id);
                throw new InvalidOperationException("Erro ao obter produto financeiro por ID.", ex);
            }
        }

        public async Task<IProdutoFinanceiro?> ObterPorNomeAsync(string nome)
        {
            try
            {
                return await _context.ProdutosFinanceiros.AsNoTracking().FirstOrDefaultAsync(pf => pf.Nome == nome);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter produto financeiro por nome: {Nome}", nome);
                throw new InvalidOperationException("Erro ao obter produto financeiro por nome.", ex);
            }
        }

        public async Task<IEnumerable<IProdutoFinanceiro>> ObterTodosAsync()
        {
            try
            {
                return await _context.ProdutosFinanceiros.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todos os produtos financeiros.");
                throw new InvalidOperationException("Erro ao obter todos os produtos financeiros.", ex);
            }
        }
    }
}
