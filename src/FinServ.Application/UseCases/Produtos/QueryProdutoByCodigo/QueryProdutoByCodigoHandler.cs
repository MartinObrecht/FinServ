using FinServ.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.UseCases.Produtos.QueryProdutoByCodigo
{
    public class QueryProdutoByCodigoHandler : IRequestHandler<QueryProdutoByCodigoRequest, IList<QueryProdutoByCodigoResponse>>
    {
        private readonly IMediator _mediator;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger<QueryProdutoByCodigoHandler> _logger;

        public QueryProdutoByCodigoHandler(IMediator mediator, IProdutoRepository produtoRepository, ILogger<QueryProdutoByCodigoHandler> logger)
        {
            _mediator = mediator;
            _produtoRepository = produtoRepository;
            _logger = logger;
        }

        public async Task<IList<QueryProdutoByCodigoResponse>> Handle(QueryProdutoByCodigoRequest request, CancellationToken cancellationToken)
        {
            var Produtos = await _produtoRepository.GetByCodigoAsync(request.CodigoProduto);

            var response = new List<QueryProdutoByCodigoResponse>();


            foreach (var produto in Produtos)
            {
                response.Add(new QueryProdutoByCodigoResponse
                {
                    IdProduto = produto.Id,
                    Nome = produto.Nome,
                    TaxaJurosMensal = produto.TaxaJurosMensal,
                    DataVencimento = produto.DataVencimento,
                    Quantidade = produto.Quantidade,
                    CodigoProduto = produto.CodigoProduto,
                    Descricao = produto.Descricao
                });
            }

            return response;

        }
    }
}
