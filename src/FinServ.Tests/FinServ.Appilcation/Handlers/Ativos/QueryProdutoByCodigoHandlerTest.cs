using FinServ.Application.Handlers.Produtos.QueryProdutoByCodigo;
using FinServ.Domain.Entities.Produtos;
using FinServ.Domain.Repositories;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FinServ.Tests.FinServ.Application.Handlers.Produtos
{
    public class QueryProdutoByCodigoHandlerTest
    {
        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
        private readonly Mock<ILogger<QueryProdutoByCodigoHandler>> _loggerMock;
        private readonly IRequestHandler<QueryProdutoByCodigoRequest, QueryProdutoByCodigoResponse> _handler;

        public QueryProdutoByCodigoHandlerTest()
        {
            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _loggerMock = new Mock<ILogger<QueryProdutoByCodigoHandler>>();
            _handler = new QueryProdutoByCodigoHandler(null, _produtoRepositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Handle_ProductNotFound_ReturnsNotFoundResponse()
        {
            // Arrange
            var request = new QueryProdutoByCodigoRequest { CodigoProduto = 1234 };
            _produtoRepositoryMock.Setup(repo => repo.GetByCodigoAsync(request.CodigoProduto))
                .ReturnsAsync((Produto)null);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.CodigoRetorno.Should().Be(StatusCodes.Status404NotFound);
            result.Mensagem.Should().Be("Produto não encontrado");
        }

        [Fact]
        public async Task Handle_ProductFound_ReturnsProductDetails()
        {
            // Arrange
            var produto = new Produto
            {
                Id = 1,
                Nome = "Produto Teste",
                TaxaJurosMensal = 0.05m,
                DataVencimento = System.DateTime.Now.AddYears(1),
                Quantidade = 100,
                CodigoProduto = 1234,
                Descricao = "Descricao Produto Teste"
            };

            var request = new QueryProdutoByCodigoRequest { CodigoProduto = 1234 };
            _produtoRepositoryMock.Setup(repo => repo.GetByCodigoAsync(request.CodigoProduto))
                .ReturnsAsync(produto);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.CodigoRetorno.Should().Be(StatusCodes.Status200OK);
            result.Mensagem.Should().Be("Produto encontrado com sucesso");
            result.Nome.Should().Be(produto.Nome);
            result.Descricao.Should().Be(produto.Descricao);
        }
    }
}
