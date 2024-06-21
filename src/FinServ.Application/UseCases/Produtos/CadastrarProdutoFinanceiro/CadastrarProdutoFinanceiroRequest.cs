using MediatR;

namespace FinServ.Application.UseCases.Produtos.CadastrarProdutoFinanceiro
{
    public class CadastrarProdutoFinanceiroRequest : IRequest<CadastrarProdutoFinanceiroResponse>
    {
        public string Nome { get; set; }
        public int CodigoTipoProduto { get; set; }
        public decimal TaxaJuros { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}