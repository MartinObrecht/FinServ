using MediatR;

namespace FinServ.Application.UseCases.Produtos.QueryAvailableProdutos
{
    public class QueryAvailableProdutosRequest : IRequest<IList<QueryAvailableProdutosResponse>>
    {
    }
}
