using FinServ.Application.UseCases.Produtos.CreateProduto;
using MediatR;

namespace FinServ.Application.UseCases.Produtos.CreateProdutos
{
    public class CreateProdutosRequest : IRequest<CreateProdutosResponse>
    {
        public IEnumerable<CreateProdutoRequest> Produtos { get; set; }
    }
}
