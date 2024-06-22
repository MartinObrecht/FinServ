using FinServ.Domain.Repositories.Produtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.UseCases.Produtos.DeletarProdutoAsync
{
    public class RemoverProdutoHandler : IRequestHandler<RemoverProdutoRequest, RemoverProdutoResponse>
    {
        private readonly IMediator _mediator;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger<RemoverProdutoHandler> _logger;

        public RemoverProdutoHandler(IMediator mediator, IProdutoRepository produtoRepository, ILogger<RemoverProdutoHandler> logger)
        {
            _mediator = mediator;
            _produtoRepository = produtoRepository;
            _logger = logger;
        }

        public async Task<RemoverProdutoResponse> Handle(RemoverProdutoRequest request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ObterPorIdAsync(request.IdProduto);

            if (produto is null)
            {
                _logger.LogWarning("Produto não encontrado: {IdProduto}", request.IdProduto);
                return new RemoverProdutoResponse
                {
                    CodigoRetorno = StatusCodes.Status404NotFound,
                    Mensagem = "Produto não encontrado."
                };
            }

            await _produtoRepository.DeletarProdutoAsync(produto);

            return new RemoverProdutoResponse
            {
                CodigoRetorno = StatusCodes.Status204NoContent,
                Mensagem = "Produto removido com sucesso."
            };

        }
    }
}
