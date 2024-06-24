using FinServ.Application.Handlers.Produtos.CreateProduto;
using MediatR;

namespace FinServ.Application.Handlers.Produtos.CreateProdutos
{
    public class CreateProdutosRequest : IRequest<CreateProdutosResponse>
    {
        public IEnumerable<CreateProdutoRequest> Produtos { get; set; }
    }
}
