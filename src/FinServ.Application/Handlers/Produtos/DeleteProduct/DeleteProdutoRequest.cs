using MediatR;

namespace FinServ.Application.Handlers.Produtos.DeleteProduct
{
    public class DeleteProdutoRequest : IRequest<DeleteProdutoResponse>
    {
        public int IdProduto { get; set; }
    }
}
