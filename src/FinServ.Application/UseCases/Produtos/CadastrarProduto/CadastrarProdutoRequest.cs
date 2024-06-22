using MediatR;

namespace FinServ.Application.UseCases.Produtos.CadastrarProduto
{
    public class CadastrarProdutoRequest : IRequest<CadastrarProdutoResponse>
    {
        public string Nome { get; set; }
        public double TaxaJurosMensal { get; set; }
        public DateTime DataVencimento { get; set; }
        public int Quantidade { get; set; }
        public int CodigoProduto { get; set; }
    }
}
