using FinServ.Domain.Entities.Produtos;

namespace FinServ.Application.UseCases.Ativos.ConsultaAtivo
{
    public class QueryrAtivoResponse
    {
        string Nome { get; set; }
        double ValorCompra { get; set; }
        DateTime DataCompra { get; set; }
        int ProdutoId { get; set; }
        Produto Produto { get; set; }
    }
}
