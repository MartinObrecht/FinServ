using FinServ.Domain.Interfaces.ProdutosFinanceiros;

namespace FinServ.Domain.Entities.ProdutosFinanceiros
{
    public class ProdutoFinanceiro : IProdutoFinanceiro
    {

        public int Id { get; set; }
        public TipoProdutoFinanceiro Tipo { get; set; }
        public decimal ValorInvestido { get; set; }
        public decimal TaxaJuros { get; set; }
        public DateTime DataInvestimento { get; set; }
        public DateTime DataVencimento { get; set; }

        public ProdutoFinanceiro() { }       
       
        public ProdutoFinanceiro(int id, TipoProdutoFinanceiro tipo, decimal valorInvestido, decimal taxaJuros, DateTime dataInvestimento, DateTime dataVencimento)
        {
            Id = id;
            Tipo = tipo;
            ValorInvestido = valorInvestido;
            TaxaJuros = taxaJuros;
            DataInvestimento = dataInvestimento;
            DataVencimento = dataVencimento;
        }

        public decimal CalculaRendimento(ITipoProdutoFinanceiro tipoProdutoFinanceiro, decimal valorInvestido, decimal taxaJuros, DateTime dataInvestimento, DateTime dataVencimento)
        {
            throw new NotImplementedException();
        }
    }
}
