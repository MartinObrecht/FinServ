using FinServ.Application.UseCases.Produtos.CadastrarProduto;
using MediatR;

namespace FinServ.Application.UseCases.Produtos.CadastrarProdutos
{
    public class CadastrarProdutosRequest : IRequest<CadastrarProdutosResponse>
    {
        public IEnumerable<CadastrarProdutoRequest> Produtos { get; set; }
    }
}
