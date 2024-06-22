﻿using FinServ.Domain.Repositories.Produtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.UseCases.Produtos.ConsultarProdutoPorCodigo
{
    public class ConsultarProdutoPorCodigoHandler : IRequestHandler<ConsultarProdutoPorCodigoRequest, IList<ConsultarProdutoPorCodigoResponse>>
    {
        private readonly IMediator _mediator;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger<ConsultarProdutoPorCodigoHandler> _logger;

        public ConsultarProdutoPorCodigoHandler(IMediator mediator, IProdutoRepository produtoRepository, ILogger<ConsultarProdutoPorCodigoHandler> logger)
        {
            _mediator = mediator;
            _produtoRepository = produtoRepository;
            _logger = logger;
        }

        public async Task<IList<ConsultarProdutoPorCodigoResponse>> Handle(ConsultarProdutoPorCodigoRequest request, CancellationToken cancellationToken)
        {
            var Produtos = await _produtoRepository.ObterPorCodigoAsync(request.CodigoProduto);

            var response = new List<ConsultarProdutoPorCodigoResponse>();


            foreach (var produto in Produtos)
            {
                response.Add(new ConsultarProdutoPorCodigoResponse
                {
                    IdProduto = produto.Id,
                    NomeProduto = produto.Nome,
                    TaxaJurosMensal = produto.TaxaJurosMensal,
                    DataVencimento = produto.DataVencimento,
                    Quantidade = produto.Quantidade,
                    TipoProduto = produto.TipoProduto.Nome,
                    DescricaoProduto = produto.TipoProduto.Descricao,
                    CodigoTipoProduto = produto.TipoProduto.CodigoProduto
                });
            }

            return response;

        }
    }
}
