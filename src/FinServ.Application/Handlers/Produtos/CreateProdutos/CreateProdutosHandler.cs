using FinServ.Domain.Entities.Enums;
using FinServ.Domain.Entities.Produtos;
using FinServ.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.Handlers.Produtos.CreateProdutos
{
    public class CreateProdutosHandler : IRequestHandler<CreateProdutosRequest, CreateProdutosResponse>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger<CreateProdutosHandler> _logger;

        public CreateProdutosHandler(IProdutoRepository produtoRepository, ILogger<CreateProdutosHandler> logger)
        {
            _produtoRepository = produtoRepository;
            _logger = logger;
        }

        public async Task<CreateProdutosResponse> Handle(CreateProdutosRequest request, CancellationToken cancellationToken)
        {
            var produtos = new List<Produto>();
            foreach (var item in request.Produtos)
            {
                produtos.Add(new Produto
                {
                    Nome = item.Nome,
                    Valor = item.Valor,
                    TaxaJurosMensal = item.TaxaJurosMensal,
                    DataVencimento = item.DataVencimento,
                    Quantidade = item.Quantidade,
                    CodigoProduto = item.CodigoProduto,
                    Descricao = item.Descricao
                });
            }

            await _produtoRepository.AddRangeAsync(produtos);

            return new CreateProdutosResponse
            {
                CodigoRetorno = StatusCodes.Status201Created,
                Mensagem = "Produtos financeiros cadastrados com sucesso."
            };
        }
    }
}
