using FinServ.Domain.Interfaces.ProdutosFinanceiros;

namespace FinServ.Domain.Entities.ProdutosFinanceiros
{
    public class AtivoFinanceiro : IAtivoFinanceiro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorCompra { get; set; }
        public DateTime DataCompra { get; set; }
        public int ProdutoFinanceiroId { get; set; }
        public ProdutoFinanceiro ProdutoFinanceiro { get; set; }
    }
}
