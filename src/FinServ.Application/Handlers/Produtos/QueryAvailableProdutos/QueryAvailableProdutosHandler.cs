using FinServ.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.Handlers.Produtos.QueryAvailableProdutos
{
    public class QueryAvailableProdutosHandler : IRequestHandler<QueryAvailableProdutosRequest, IList<QueryAvailableProdutosResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<QueryAvailableProdutosHandler> _logger;

        public QueryAvailableProdutosHandler(IUnitOfWork unitOfWork, ILogger<QueryAvailableProdutosHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IList<QueryAvailableProdutosResponse>> Handle(QueryAvailableProdutosRequest request, CancellationToken cancellationToken)
        {
            var Produtos = await _unitOfWork.Produtos.GetAvailableAsync();

            var response = new List<QueryAvailableProdutosResponse>();

            foreach (var produto in Produtos)
            {
                response.Add(new QueryAvailableProdutosResponse
                {
                    IdProduto = produto.Id,
                    Nome = produto.Nome,
                    Valor = produto.Valor,
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
