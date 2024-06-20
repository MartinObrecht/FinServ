namespace FinServ.Domain.Interfaces.ProdutosFinanceiros
{
    public interface ITipoProdutoFinanceiro : IEntidadeBase
    {
        string Nome { get; set; }
        string Descricao { get; set; }

        bool ProdutoValido(ITipoProdutoFinanceiro tipoProdutoFinanceiro);
    }
}
