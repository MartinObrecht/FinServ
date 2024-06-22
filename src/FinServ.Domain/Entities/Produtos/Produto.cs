using FinServ.Domain.Interfaces.Produtos;

namespace FinServ.Domain.Entities.Produtos
{
    public class Produto : IProduto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double TaxaJurosMensal { get; set; }
        public DateTime DataVencimento { get; set; }
        public int Quantidade { get; set; }

        public int TipoProdutoId { get; set; }
        public TipoProduto TipoProduto { get; set; }
    }
}
