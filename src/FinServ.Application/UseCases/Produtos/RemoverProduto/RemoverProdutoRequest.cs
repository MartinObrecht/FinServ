using MediatR;

namespace FinServ.Application.UseCases.Produtos.DeletarProdutoAsync
{
    public class RemoverProdutoRequest : IRequest<RemoverProdutoResponse>
    {
        public int IdProduto { get; set; }
    }
}
