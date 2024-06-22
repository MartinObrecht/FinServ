using FinServ.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.UseCases.Produtos.QueryAvailableProdutos
{
    public class QueryAvailableProdutosHandler : IRequestHandler<QueryAvailableProdutosRequest, IList<QueryAvailableProdutosResponse>>
    {
        private readonly IMediator _mediator;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger<QueryAvailableProdutosHandler> _logger;

        public QueryAvailableProdutosHandler(IMediator mediator, IProdutoRepository produtoRepository, ILogger<QueryAvailableProdutosHandler> logger)
        {
            _mediator = mediator;
            _produtoRepository = produtoRepository;
            _logger = logger;
        }

        public async Task<IList<QueryAvailableProdutosResponse>> Handle(QueryAvailableProdutosRequest request, CancellationToken cancellationToken)
        {
            var Produtos = await _produtoRepository.GetAvailableAsync();

            var response = new List<QueryAvailableProdutosResponse>();

            foreach (var produto in Produtos)
            {
                response.Add(new QueryAvailableProdutosResponse
                {
                    IdProduto = produto.Id,
                    Nome = produto.Nome,
                    TaxaJurosMensal = produto.TaxaJurosMensal,
                    DataVencimento = produto.DataVencimento.ToShortDateString(),
                    Quantidade = produto.Quantidade,
                    CodigoProduto = produto.CodigoProduto,
                    Descricao = produto.Descricao
                });
            }
            return response;
        }
    }
}
