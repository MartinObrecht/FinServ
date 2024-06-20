using FinServ.Domain.Entities.Enums;
using FinServ.Domain.Interfaces.ProdutosFinanceiros;

namespace FinServ.Domain.Entities.ProdutosFinanceiros
{
    public class Cdb : ICdb
    {
        public int Id { get; set; }
        public ETipoCdb TipoCdb { get; set; }
        public TipoProdutoFinanceiro Tipo { get; set; }
        public decimal ValorInvestido { get; set; }
        public decimal TaxaJuros { get; set; }
        public DateTime DataInvestimento { get; set; }
        public DateTime DataVencimento { get; set; }

        public decimal CalculaRendimento(ITipoProdutoFinanceiro tipoProdutoFinanceiro, decimal valorInvestido, decimal taxaJuros, DateTime dataInvestimento, DateTime dataVencimento)
        {
            throw new NotImplementedException();
        }
    }
}
