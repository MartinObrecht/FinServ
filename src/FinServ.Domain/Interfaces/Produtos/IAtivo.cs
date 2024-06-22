using FinServ.Domain.Entities.Produtos;

namespace FinServ.Domain.Interfaces.Produtos
{
    public interface IAtivo : IEntidadeBase
    {
        string Nome { get; set; }
        double ValorCompra { get; set; }
        DateTime DataCompra { get; set; }
        int ProdutoId { get; set; }
        Produto Produto { get; set; }
    }
}
