using MediatR;

namespace FinServ.Application.UseCases.Produtos.QueryProdutoByCodigo
{
    public class QueryProdutoByCodigoRequest : IRequest<IList<QueryProdutoByCodigoResponse>>
    {
        public int CodigoProduto { get; set; }
    }
}
