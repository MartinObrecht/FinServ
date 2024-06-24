using MediatR;

namespace FinServ.Application.Handlers.Produtos.QueryAvailableProdutos
{
    public class QueryAvailableProdutosRequest : IRequest<IList<QueryAvailableProdutosResponse>>
    {
    }
}
