using FinServ.Domain.Repositories.Produtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.UseCases.Produtos.ConsultarProdutosDisponiveis
{
    public class ConsultaProdutosDisponiveisHandler : IRequestHandler<ConsultaProdutosDisponiveisRequest, IList<ConsultarProdutosDisponiveisResponse>>
    {
        private readonly IMediator _mediator;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger<ConsultaProdutosDisponiveisHandler> _logger;

        public ConsultaProdutosDisponiveisHandler(IMediator mediator, IProdutoRepository produtoRepository, ILogger<ConsultaProdutosDisponiveisHandler> logger)
        {
            _mediator = mediator;
            _produtoRepository = produtoRepository;
            _logger = logger;
        }

        public async Task<IList<ConsultarProdutosDisponiveisResponse>> Handle(ConsultaProdutosDisponiveisRequest request, CancellationToken cancellationToken)
        {
            var Produtos = await _produtoRepository.ObterProdutosDisponiveisAsync();

            var response = new List<ConsultarProdutosDisponiveisResponse>();

            foreach (var produto in Produtos)
            {
                response.Add(new ConsultarProdutosDisponiveisResponse
                {
                    IdProduto = produto.Id,
                    NomeProduto = produto.Nome,
                    TaxaJurosMensal = produto.TaxaJurosMensal,
                    DataVencimento = produto.DataVencimento.ToShortDateString(),
                    Quantidade = produto.Quantidade,
                    TipoProduto = produto.TipoProduto.Nome,
                    DescricaoProduto = produto.TipoProduto.Descricao,
                    CodigoTipoProduto = produto.TipoProduto.CodigoProduto
                });
            }
            return response;
        }
    }
}
