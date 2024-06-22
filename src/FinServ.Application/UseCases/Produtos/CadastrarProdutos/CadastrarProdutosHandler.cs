using FinServ.Domain.Entities.Produtos;
using FinServ.Domain.Repositories.Produtos;
using FinServ.Domain.Repositories.TiposProdutos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.UseCases.Produtos.CadastrarProdutos
{
    public class CadastrarProdutosHandler : IRequestHandler<CadastrarProdutosRequest, CadastrarProdutosResponse>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ITipoProdutoRepository _tipoProdutoRepository;
        private readonly ILogger<CadastrarProdutosHandler> _logger;

        public CadastrarProdutosHandler(IProdutoRepository produtoRepository, ITipoProdutoRepository tipoProdutoRepository, ILogger<CadastrarProdutosHandler> logger)
        {
            _produtoRepository = produtoRepository;
            _tipoProdutoRepository = tipoProdutoRepository;
            _logger = logger;
        }

        public async Task<CadastrarProdutosResponse> Handle(CadastrarProdutosRequest request, CancellationToken cancellationToken)
        {
            var produtosFinanceiros = new List<Produto>();

            foreach (var produto in request.Produtos)
            {
                var TipoProduto = await _tipoProdutoRepository.ObterPorCodigoProdutoAsync(produto.CodigoProduto);

                produtosFinanceiros.Add(new Produto
                {
                    DataVencimento = produto.DataVencimento,
                    Nome = produto.Nome,
                    TaxaJurosMensal = produto.TaxaJurosMensal,
                    Quantidade = produto.Quantidade,
                    TipoProduto = TipoProduto as TipoProduto
                });
            }

            await _produtoRepository.CadastrarEmLoteAsync(produtosFinanceiros);

            return new CadastrarProdutosResponse
            {
                CodigoRetorno = StatusCodes.Status201Created,
                Mensagem = "Produtos financeiros cadastrados com sucesso."
            };
        }
    }
}
