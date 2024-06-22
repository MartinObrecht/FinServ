using FinServ.Domain.Entities.Produtos;
namespace FinServ.Domain.Repositories.TiposProdutos
{
    public interface ITipoProdutoRepository
    {
        Task<TipoProduto?> ObterPorCodigoProdutoAsync(int codigoProduto);
    }
}
