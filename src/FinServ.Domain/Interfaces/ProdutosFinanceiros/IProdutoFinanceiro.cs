using FinServ.Domain.Entities.ProdutosFinanceiros;

namespace FinServ.Domain.Interfaces.ProdutosFinanceiros
{
    public interface IProdutoFinanceiro : IEntidadeBase
    {
        string Nome { get; set; }
        int TipoProdutoFinanceiroId { get; set; }
        TipoProdutoFinanceiro TipoProdutoFinanceiro { get; set; }
        decimal TaxaJuros { get; set; }
        DateTime DataVencimento { get; set; }
    }
}
