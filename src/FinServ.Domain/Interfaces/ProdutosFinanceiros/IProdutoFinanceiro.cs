using FinServ.Domain.Entities.ProdutosFinanceiros;

namespace FinServ.Domain.Interfaces.ProdutosFinanceiros
{
    public interface IProdutoFinanceiro : IEntidadeBase
    {
        TipoProdutoFinanceiro Tipo { get; set; }
        decimal ValorInvestido { get; set; }
        decimal TaxaJuros { get; set; }
        DateTime DataInvestimento { get; set; }
        DateTime DataVencimento { get; set; }

        decimal CalculaRendimento(ITipoProdutoFinanceiro tipoProdutoFinanceiro, decimal valorInvestido, decimal taxaJuros, DateTime dataInvestimento, DateTime dataVencimento);
    }
}
