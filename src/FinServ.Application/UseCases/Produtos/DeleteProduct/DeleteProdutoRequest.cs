using MediatR;

namespace FinServ.Application.UseCases.Produtos.DeleteProduto
{
    public class DeleteProdutoRequest : IRequest<DeleteProdutoResponse>
    {
        public int IdProduto { get; set; }
    }
}
