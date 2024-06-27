
using System.ComponentModel.DataAnnotations.Schema;

namespace FinServ.Domain.Interfaces.Entities
{
    public interface IExtratoAtivos
    {
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public decimal SaldoCliente { get; set; }
        public int IdAtivo { get; set; }
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public DateTime DataVencimentoProduto { get; set; }
        public decimal TaxaJurosMes { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorAtual { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCompra { get; set; }
        [NotMapped]
        public decimal Rentabilidade { get; set; }
        [NotMapped]
        public decimal ValorPatrimonio { get; set; }
    }
}
