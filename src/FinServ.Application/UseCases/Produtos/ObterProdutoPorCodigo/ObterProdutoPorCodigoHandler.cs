using FinServ.Domain.Repositories.Produtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.UseCases.Produtos.ObterProdutoPorCodigo
{
    public class ObterProdutoPorCodigoHandler : IRequestHandler<ObterProdutoPorCodigoRequest, IList<ObterProdutoPorCodigoResponse>>
    {
        private readonly IMediator _mediator;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger<ObterProdutoPorCodigoHandler> _logger;

        public ObterProdutoPorCodigoHandler(IMediator mediator, IProdutoRepository produtoRepository, ILogger<ObterProdutoPorCodigoHandler> logger)
        {
            _mediator = mediator;
            _produtoRepository = produtoRepository;
            _logger = logger;
        }

        public async Task<IList<ObterProdutoPorCodigoResponse>> Handle(ObterProdutoPorCodigoRequest request, CancellationToken cancellationToken)
        {
            var Produtos = await _produtoRepository.ObterProdutoPorCodigoAsync(request.CodigoProduto);

            var response = new List<ObterProdutoPorCodigoResponse>();


            foreach (var produto in Produtos)
            {
                response.Add(new ObterProdutoPorCodigoResponse
                {
                    NomeAtivo = produto.Nome,
                    TaxaJurosMensal = produto.TaxaJurosMensal,
                    DataVencimento = produto.DataVencimento,
                    Quantidade = produto.Quantidade,
                    NomeProduto = produto.TipoProduto.Nome,
                    DescricaoProduto = produto.TipoProduto.Descricao,
                    CodigoProduto = produto.TipoProduto.CodigoProduto
                });
            }

            return response;

        }
    }
}
