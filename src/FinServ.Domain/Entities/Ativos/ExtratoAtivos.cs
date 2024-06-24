using FinServ.Domain.Interfaces.Entities;
using System;

namespace FinServ.Domain.Entities.Ativos
{
    public class ExtratoAtivos : IExtratoAtivos
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
        public double Rentabilidade { get; set; }
        public double ValorPatrimonio { get; set; }
    }
}
