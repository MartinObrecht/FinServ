using FinServ.Domain.Entities.Clientes;
using FinServ.Domain.Entities.Produtos;
using FinServ.Domain.Interfaces.Entities;

namespace FinServ.Domain.Entities.Ativos
{
    public class Ativo : IAtivo
    {
        public int Id { get; set; }
        public double ValorCompra { get; set; }
        public DateTime DataCompra { get; set; }
        public int Quantidade { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public double ValorAtual { get; set; }
    }
}
