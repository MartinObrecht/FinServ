using FinServ.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.UseCases.Produtos.DeleteProduto
{
    public class DeleteProdutoHandler : IRequestHandler<DeleteProdutoRequest, DeleteProdutoResponse>
    {
        private readonly IMediator _mediator;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger<DeleteProdutoHandler> _logger;

        public DeleteProdutoHandler(IMediator mediator, IProdutoRepository produtoRepository, ILogger<DeleteProdutoHandler> logger)
        {
            _mediator = mediator;
            _produtoRepository = produtoRepository;
            _logger = logger;
        }

        public async Task<DeleteProdutoResponse> Handle(DeleteProdutoRequest request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByIdAsync(request.IdProduto);

            if (produto is null)
            {
                _logger.LogWarning("Produto não encontrado: {IdProduto}", request.IdProduto);
                return new DeleteProdutoResponse
                {
                    CodigoRetorno = StatusCodes.Status404NotFound,
                    Mensagem = "Produto não encontrado."
                };
            }

            await _produtoRepository.DeleteAsync(produto);

            return new DeleteProdutoResponse
            {
                CodigoRetorno = StatusCodes.Status204NoContent,
                Mensagem = "Produto removido com sucesso."
            };

        }
    }
}
