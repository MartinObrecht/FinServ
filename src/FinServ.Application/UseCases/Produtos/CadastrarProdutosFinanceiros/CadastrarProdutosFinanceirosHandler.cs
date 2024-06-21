using FinServ.Application.UseCases.Produtos.CadastrarProdutoFinanceiro;
using FinServ.Domain.Entities.ProdutosFinanceiros;
using FinServ.Domain.Repositories.ProdutosFinanceiros;
using FinServ.Domain.Repositories.TiposProdutos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.UseCases.Produtos.CadastrarProdutosFinanceiros
{
    public class CadastrarProdutosFinanceirosHandler : IRequestHandler<CadastrarProdutosFinanceirosRequest, CadastrarProdutosFinanceirosResponse>
    {
        private readonly IProdutoFinaceiroRepository _produtoFinaceiroRepository;
        private readonly ITipoProdutoRepository _tipoProdutoRepository;
        private readonly ILogger<CadastrarProdutosFinanceirosHandler> _logger;

        public CadastrarProdutosFinanceirosHandler(IProdutoFinaceiroRepository produtoFinaceiroRepository, ITipoProdutoRepository tipoProdutoRepository, ILogger<CadastrarProdutosFinanceirosHandler> logger)
        {
            _produtoFinaceiroRepository = produtoFinaceiroRepository;
            _tipoProdutoRepository = tipoProdutoRepository;
            _logger = logger;
        }

        public async Task<CadastrarProdutosFinanceirosResponse> Handle(CadastrarProdutosFinanceirosRequest request, CancellationToken cancellationToken)
        {
            var produtosFinanceiros = new List<ProdutoFinanceiro>();

            foreach (var produto in request.ProdutosFinanceirosRequest)
            {
                var tipoProdutoFinanceiro = await _tipoProdutoRepository.ObterPorCodigoProdutoAsync(produto.CodigoTipoProduto);

                produtosFinanceiros.Add(new ProdutoFinanceiro
                {
                    DataVencimento = produto.DataVencimento,
                    Nome = produto.Nome,
                    TaxaJuros = produto.TaxaJuros,
                    TipoProdutoFinanceiro = tipoProdutoFinanceiro as TipoProdutoFinanceiro
                });
            }

            await _produtoFinaceiroRepository.CadastrarEmLoteAsync(produtosFinanceiros);

            return new CadastrarProdutosFinanceirosResponse
            {
                CodigoRetorno = StatusCodes.Status201Created,
                Mensagem = "Produtos financeiros cadastrados com sucesso."
            };
        }
    }
}
