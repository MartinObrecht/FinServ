using FinServ.Domain.Interfaces.ProdutosFinanceiros;

namespace FinServ.Domain.Entities.ProdutosFinanceiros
{
    public class ProdutoFinanceiro : IProdutoFinanceiro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TipoProdutoFinanceiroId { get; set; }
        public TipoProdutoFinanceiro TipoProdutoFinanceiro { get; set; }
        public decimal TaxaJuros { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
