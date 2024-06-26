using FinServ.Application.Handlers.Produtos.QueryAvailableProdutos;
using FinServ.Domain.Entities.Produtos;
using FinServ.Domain.Repositories;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;

namespace FinServ.Tests.FinServ.Application.Handlers.Produtos
{
    public class QueryAvailableProdutosHandlerTest
    {
        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
        private readonly Mock<ILogger<QueryAvailableProdutosHandler>> _loggerMock;
        private readonly IRequestHandler<QueryAvailableProdutosRequest, IList<QueryAvailableProdutosResponse>> _handler;

        public QueryAvailableProdutosHandlerTest()
        {
            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _loggerMock = new Mock<ILogger<QueryAvailableProdutosHandler>>();
            _handler = new QueryAvailableProdutosHandler(_produtoRepositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Handle_WhenProdutosAreAvailable_ReturnsListOfAvailableProdutos()
        {
            // Arrange
            var produtos = new List<Produto>
            {
                new Produto { Id = 1, Nome = "Produto 1", TaxaJurosMensal = 0.05, DataVencimento = System.DateTime.Now.AddYears(1), Quantidade = 100, CodigoProduto = 1234, Descricao = "Descricao Produto 1" },
                new Produto { Id = 2, Nome = "Produto 2", TaxaJurosMensal = 0.03, DataVencimento = System.DateTime.Now.AddYears(2), Quantidade = 200, CodigoProduto = 123, Descricao = "Descricao Produto 2" }
            };

            _produtoRepositoryMock.Setup(repo => repo.GetAvailableAsync())
                .ReturnsAsync(produtos);

            var request = new QueryAvailableProdutosRequest();

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(produtos.Count);
            result[0].Nome.Should().Be(produtos[0].Nome);
            result[1].Nome.Should().Be(produtos[1].Nome);
        }

        [Fact]
        public async Task Handle_WhenNoProdutosAreAvailable_ReturnsEmptyList()
        {
            // Arrange
            _produtoRepositoryMock.Setup(repo => repo.GetAvailableAsync())
                .ReturnsAsync(new List<Produto>());

            var request = new QueryAvailableProdutosRequest();

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }
    }
}
