﻿using FinServ.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.Handlers.Produtos.QueryProdutoByCodigo
{
    public class QueryProdutoByCodigoHandler : IRequestHandler<QueryProdutoByCodigoRequest, QueryProdutoByCodigoResponse>
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<QueryProdutoByCodigoHandler> _logger;

        public QueryProdutoByCodigoHandler(IMediator mediator, IUnitOfWork unitOfWork, ILogger<QueryProdutoByCodigoHandler> logger)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<QueryProdutoByCodigoResponse> Handle(QueryProdutoByCodigoRequest request, CancellationToken cancellationToken)
        {
            var produto = await _unitOfWork.Produtos.GetByCodigoAsync(request.CodigoProduto);

            if (produto == null) {
                return new QueryProdutoByCodigoResponse
                {
                    Mensagem = "Produto não encontrado",
                    CodigoRetorno = StatusCodes.Status404NotFound
                };
            }

            return new QueryProdutoByCodigoResponse
            {
                IdProduto = produto.Id,
                Nome = produto.Nome,
                TaxaJurosMensal = produto.TaxaJurosMensal,
                DataVencimento = produto.DataVencimento,
                Quantidade = produto.Quantidade,
                CodigoProduto = produto.CodigoProduto,
                Descricao = produto.Descricao,
                Mensagem = "Produto encontrado com sucesso",
                CodigoRetorno = StatusCodes.Status200OK
            };
        }
    }
}
