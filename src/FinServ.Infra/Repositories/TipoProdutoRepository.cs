using FinServ.Domain.Entities.Produtos;
using FinServ.Domain.Repositories.TiposProdutos;
using FinServ.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinServ.Infra.Repositories
{
    public class TipoProdutoRepository : ITipoProdutoRepository
    {
        private readonly FinServContext _context;
        private readonly ILogger<TipoProdutoRepository> _logger;

        public TipoProdutoRepository(FinServContext context, ILogger<TipoProdutoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<TipoProduto?> ObterPorCodigoProdutoAsync(int codigoProduto)
        {
            try
            {
                return await _context.TiposProduto.FirstOrDefaultAsync(tpf => tpf.CodigoProduto == codigoProduto);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter tipo de produto financeiro por código: {CodigoProduto}", codigoProduto);
                throw new InvalidOperationException("Erro ao obter tipo de produto financeiro por código.", ex);
            }
        }
    }
}
