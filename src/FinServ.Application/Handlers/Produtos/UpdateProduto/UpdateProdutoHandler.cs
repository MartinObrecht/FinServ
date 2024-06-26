using FinServ.Domain.Entities.Produtos;
using FinServ.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.Handlers.Produtos.UpdateProduto
{
    public class UpdateProdutoHandler : IRequestHandler<UpdateProdutoRequest, UpdateProdutoResponse>
    {
        private readonly IMediator _mediator;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger<UpdateProdutoHandler> _logger;

        public UpdateProdutoHandler(IMediator mediator, IProdutoRepository produtoRepository, ILogger<UpdateProdutoHandler> logger)
        {
            _mediator = mediator;
            _produtoRepository = produtoRepository;
            _logger = logger;
        }

        public async Task<UpdateProdutoResponse> Handle(UpdateProdutoRequest request, CancellationToken cancellationToken)
        {
            Produto? produto = await _produtoRepository.GetByIdAsync(request.IdProduto);

            if (produto == null)
            {
                return new UpdateProdutoResponse
                {
                    CodigoRetorno = StatusCodes.Status404NotFound,
                    Mensagem = "Produto não encontrado."
                };
            }

            produto.Nome = request.Nome;
            produto.TaxaJurosMensal = request.TaxaJurosMensal;
            produto.DataVencimento = Convert.ToDateTime(request.DataVencimento);
            produto.Quantidade = request.Quantidade;
            produto.CodigoProduto = request.CodigoProduto;
            produto.Descricao = request.Descricao;
            produto.Valor = request.Valor;

            _produtoRepository.Update(produto);

            var response = new UpdateProdutoResponse
            {
                IdProduto = produto.Id,
                Mensagem = "Produto atualizado com sucesso.",
                CodigoRetorno = StatusCodes.Status200OK
            };

            return response;

        }
    }
}
