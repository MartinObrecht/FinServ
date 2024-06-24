
using System.ComponentModel.DataAnnotations.Schema;

namespace FinServ.Domain.Interfaces.Entities
{
    public interface IExtratoAtivos
    {
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public DateTime DataVencimentoProduto { get; set; }
        public double TaxaJurosMes { get; set; }
        public double ValorCompra { get; set; }
        public double ValorAtual { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCompra { get; set; }
        [NotMapped]
        public double Rentabilidade { get; set; }
        [NotMapped]
        public double ValorPatrimonio { get; set; }
    }
}
