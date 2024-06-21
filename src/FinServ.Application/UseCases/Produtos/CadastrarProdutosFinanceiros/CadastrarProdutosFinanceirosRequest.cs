using FinServ.Application.UseCases.Produtos.CadastrarProdutoFinanceiro;
using MediatR;

namespace FinServ.Application.UseCases.Produtos.CadastrarProdutosFinanceiros
{
    public class CadastrarProdutosFinanceirosRequest : IRequest<CadastrarProdutosFinanceirosResponse>
    {
        public IEnumerable<CadastrarProdutoFinanceiroRequest> ProdutosFinanceirosRequest { get; set; }
    }
}
