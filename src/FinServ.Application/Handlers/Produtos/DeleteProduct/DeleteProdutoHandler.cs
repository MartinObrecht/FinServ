using FinServ.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.Handlers.Produtos.DeleteProduct
{
    public class DeleteProdutoHandler : IRequestHandler<DeleteProdutoRequest, DeleteProdutoResponse>
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteProdutoHandler> _logger;

        public DeleteProdutoHandler(IMediator mediator, IUnitOfWork unitOfWork, ILogger<DeleteProdutoHandler> logger)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<DeleteProdutoResponse> Handle(DeleteProdutoRequest request, CancellationToken cancellationToken)
        {
            var produto = await _unitOfWork.Produtos.GetByIdAsync(request.IdProduto);

            if (produto is null)
            {
                _logger.LogWarning("Produto não encontrado: {IdProduto}", request.IdProduto);
                return new DeleteProdutoResponse
                {
                    CodigoRetorno = StatusCodes.Status404NotFound,
                    Mensagem = "Produto não encontrado."
                };
            }

            _unitOfWork.Produtos.Delete(produto);
            _unitOfWork.Commit();

            return new DeleteProdutoResponse
            {
                CodigoRetorno = StatusCodes.Status204NoContent,
                Mensagem = "Produto removido com sucesso."
            };

        }
    }
}
