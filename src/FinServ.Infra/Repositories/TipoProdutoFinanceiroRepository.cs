using FinServ.Domain.Interfaces.ProdutosFinanceiros;
using FinServ.Domain.Repositories.TiposProdutos;
using FinServ.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinServ.Infra.Repositories
{
    public class TipoProdutoFinanceiroRepository : ITipoProdutoRepository
    {
        private readonly FinServContext _context;
        private readonly ILogger<TipoProdutoFinanceiroRepository> _logger;

        public TipoProdutoFinanceiroRepository(FinServContext context, ILogger<TipoProdutoFinanceiroRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ITipoProdutoFinanceiro?> ObterPorCodigoProdutoAsync(int codigoProduto)
        {
            try
            {
                return await _context.TiposProdutoFinanceiro.FirstOrDefaultAsync(tpf => tpf.CodigoProdutoFinanceiro == codigoProduto);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter tipo de produto financeiro por código: {CodigoProduto}", codigoProduto);
                throw new InvalidOperationException("Erro ao obter tipo de produto financeiro por código.", ex);
            }
        }
    }
}
