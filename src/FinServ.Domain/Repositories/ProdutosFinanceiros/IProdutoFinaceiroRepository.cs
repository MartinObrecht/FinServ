using FinServ.Domain.Interfaces.ProdutosFinanceiros;

namespace FinServ.Domain.Repositories.ProdutosFinanceiros
{
    public interface IProdutoFinaceiroRepository
    {
        Task<IProdutoFinanceiro?> ObterPorIdAsync(int id);
        Task<IProdutoFinanceiro?> ObterPorNomeAsync(string nome);
        Task<IEnumerable<IProdutoFinanceiro>> ObterTodosAsync();
        Task CadastrarAsync(IProdutoFinanceiro produtoFinanceiro);
        Task CadastrarEmLoteAsync(IEnumerable<IProdutoFinanceiro?> produtosFinanceiros);
    }
}
