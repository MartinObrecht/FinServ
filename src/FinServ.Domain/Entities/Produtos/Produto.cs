using FinServ.Domain.Entities.Ativos;
using FinServ.Domain.Interfaces.Entities;

namespace FinServ.Domain.Entities.Produtos
{
    public class Produto : IProduto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CodigoProduto { get; set; }
        public double TaxaJurosMensal { get; set; }
        public DateTime DataVencimento { get; set; }
        public int Quantidade { get; set; }
        public ICollection<Ativo> Ativos { get; set; }
        public double Valor { get; set; }
    }
}
