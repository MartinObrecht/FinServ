using FinServ.Domain.Entities.ProdutosFinanceiros;

namespace FinServ.Domain.Interfaces.ProdutosFinanceiros
{
    public interface IAtivoFinanceiro : IEntidadeBase
    {
        string Nome { get; set; }
        decimal ValorCompra { get; set; }
        DateTime DataCompra { get; set; }
        int ProdutoFinanceiroId { get; set; }
        ProdutoFinanceiro ProdutoFinanceiro { get; set; }
    }
}
