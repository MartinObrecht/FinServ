using MediatR;

namespace FinServ.Application.Handlers.Produtos.QueryProdutoByCodigo
{
    public class QueryProdutoByCodigoRequest : IRequest<QueryProdutoByCodigoResponse>
    {
        public int CodigoProduto { get; set; }
    }
}
