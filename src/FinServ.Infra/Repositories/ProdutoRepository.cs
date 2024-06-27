using FinServ.Domain.Entities.Produtos;
using FinServ.Domain.Repositories;
using FinServ.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinServ.Infra.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        private readonly FinServContext _context;
        private readonly ILogger<IClienteRepository> _logger;

        public ProdutoRepository(FinServContext context, ILogger<IClienteRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddRangeAsync(IEnumerable<Produto?> produtos)
        {
            try
            {
                await _context.Produtos.AddRangeAsync(produtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cadastrar produtos financeiros: {Produtos}", produtos);
                throw new InvalidOperationException("Erro ao cadastrar produtos financeiros.", ex);
            }
        }

        public async Task<Produto?> GetByCodigoAsync(int codigoProduto)
        {
            try
            {
                var produto = await _context.Produtos
                    .AsNoTracking().FirstOrDefaultAsync(x => x.CodigoProduto == codigoProduto);

                return produto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter produtos financeiros pelo código do tipo financeiro: {CodigoTipoFinanceiro}", codigoProduto);
                throw new InvalidOperationException($"Erro ao obter produtos financeiros pelo código do tipo financeiro: {codigoProduto}.", ex);
            }
        }
        public async Task<IEnumerable<Produto>> GetAvailableAsync()
        {
            try
            {
                return await _context.Produtos
                    .Where(pf => pf.Quantidade > 0)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter produtos financeiros disponíveis.");
                throw new InvalidOperationException("Erro ao obter produtos financeiros disponíveis.", ex);
            }
        }
    }
}
