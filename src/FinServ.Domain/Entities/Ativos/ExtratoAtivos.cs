using FinServ.Domain.Interfaces.Entities;
using System;

namespace FinServ.Domain.Entities.Ativos
{
    public class ExtratoAtivos : IExtratoAtivos
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
        public decimal Rentabilidade { get; set; }
        public decimal ValorPatrimonio { get; set; }
    }
}
