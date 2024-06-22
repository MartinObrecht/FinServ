using FinServ.Domain.Interfaces.Produtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinServ.Domain.Entities.Produtos
{
    public class Ativo : IAtivo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double ValorCompra { get; set; }
        public DateTime DataCompra { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        [NotMapped]
        public double ValorAtual { get; set; }
        [NotMapped]
        public double Rentabilidade { get; set; }

        public double CalcularRentabilidade(double TaxaJurosMesMes, double valorCompra, DateTime dataVencimento)
        {
            int mesesAteVencimento = ((dataVencimento.Year - DateTime.Now.Year) * 12) + dataVencimento.Month - DateTime.Now.Month;
            double valorFuturo = valorCompra * Math.Pow(1 + TaxaJurosMesMes, mesesAteVencimento);
            double rentabilidade = ((valorFuturo - valorCompra) / valorCompra) * 100;

            return rentabilidade;
        }

        public double CalcularValorAtual(double rentabilidade, double valorCompra)
        {
            double valorAtual = valorCompra * (1 + rentabilidade / 100);

            return valorAtual;
        }
    }
}
