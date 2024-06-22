using FinServ.Domain.Entities.Produtos;

namespace FinServ.Domain.Interfaces.Produtos
{
    public interface ITipoProduto
    {
        int CodigoProduto { get; set; }
        string Nome { get; set; }
        string Descricao { get; set; }

        ICollection<Produto> Produtos { get; set; }

    }
}
