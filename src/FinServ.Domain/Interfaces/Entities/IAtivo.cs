using FinServ.Domain.Entities.Clientes;
using FinServ.Domain.Entities.Produtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinServ.Domain.Interfaces.Entities
{
    public interface IAtivo : IEntidadeBase
    {
        double ValorCompra { get; set; }
        DateTime DataCompra { get; set; }
        int Quantidade { get; set; }
        int ClienteId { get; set; }
        Cliente Cliente { get; set; }
        int ProdutoId { get; set; }
        Produto Produto { get; set; }

        [NotMapped]
        double ValorAtual { get; set; }
    }
}
