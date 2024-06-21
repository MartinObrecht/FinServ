using FinServ.Domain.Interfaces.ProdutosFinanceiros;

namespace FinServ.Domain.Repositories.TiposProdutos
{
    public interface ITipoProdutoRepository
    {
        Task<ITipoProdutoFinanceiro?> ObterPorCodigoProdutoAsync(int codigoProduto);
    }
}
