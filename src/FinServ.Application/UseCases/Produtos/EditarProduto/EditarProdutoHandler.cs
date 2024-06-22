using FinServ.Domain.Entities.Produtos;
using FinServ.Domain.Repositories.Produtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.UseCases.Produtos.EditarProduto
{
    public class EditarProdutoHandler : IRequestHandler<EditarProdutoRequest, EditarProdutoResponse>
    {
        private readonly IMediator _mediator;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger<EditarProdutoHandler> _logger;

        public EditarProdutoHandler(IMediator mediator, IProdutoRepository produtoRepository, ILogger<EditarProdutoHandler> logger)
        {
            _mediator = mediator;
            _produtoRepository = produtoRepository;
            _logger = logger;
        }

        public async Task<EditarProdutoResponse> Handle(EditarProdutoRequest request, CancellationToken cancellationToken)
        {
            Produto? produto = await _produtoRepository.ObterPorIdAsync(request.IdProduto);       

            if (produto == null)
            {
                return new EditarProdutoResponse
                {
                    CodigoRetorno = StatusCodes.Status404NotFound,
                    Mensagem = "Produto não encontrado."
                };
            }

            produto.Nome = request.NomeProduto;
            produto.TaxaJurosMensal = request.TaxaJurosMensal;
            produto.DataVencimento = Convert.ToDateTime(request.DataVencimento);
            produto.Quantidade = request.Quantidade;

            await _produtoRepository.AtualizarProdutoAsync(produto);            

            var response = new EditarProdutoResponse
            {
                IdProduto = produto.Id,
                Mensagem = "Produto atualizado com sucesso."
            };

            return response;

        }
    }
}
