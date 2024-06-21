using FinServ.Application.UseCases.Produtos.ObterProdutoFInanceiro;
using FinServ.Domain.Repositories.ProdutosFinanceiros;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.UseCases.Produtos.ExtratoProdutosFinanceiros
{
    public class ExtratoProdutosFinanceirosHandler : IRequestHandler<ExtratoProdutosFinanceirosRequest, ExtratoProdutosFinanceirosResponse>
    {
        private readonly IMediator _mediator;
        private readonly IProdutoFinaceiroRepository _produtoFinaceiroRepository;
        private readonly ILogger<ExtratoProdutosFinanceirosHandler> _logger;

        public ExtratoProdutosFinanceirosHandler(IMediator mediator, IProdutoFinaceiroRepository produtoFinaceiroRepository, ILogger<ExtratoProdutosFinanceirosHandler> logger)
        {
            _mediator = mediator;
            _produtoFinaceiroRepository = produtoFinaceiroRepository;
            _logger = logger;
        }

        public async Task<ExtratoProdutosFinanceirosResponse> Handle(ExtratoProdutosFinanceirosRequest request, CancellationToken cancellationToken)
        {
            var produtosFinanceiros = await _produtoFinaceiroRepository.ObterTodosAsync();

            var response = new ExtratoProdutosFinanceirosResponse();
            

            foreach (var produto in produtosFinanceiros)
            {
                response.Produtos.Add(new ObterProdutoFinanceiroResponse
                {
                    NomeProduto = produto.Nome,
                    TaxaJuros = produto.TaxaJuros,
                    DataVencimento = produto.DataVencimento,

                });
            }

            return response;

        }
    }
}
