using FinServ.Domain.Entities.Produtos;

namespace FinServ.Domain.Interfaces.Produtos
{
    public interface IProduto : IEntidadeBase
    {
        string Nome { get; set; }
        double TaxaJurosMensal { get; set; }
        DateTime DataVencimento { get; set; }
        public int Quantidade { get; set; }

        int TipoProdutoId { get; set; }
        TipoProduto TipoProduto { get; set; }
    }
}
