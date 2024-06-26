using FinServ.Application.Handlers.Produtos.DeleteProduct;
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
    public class DeleteProdutoHandlerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
        private readonly Mock<ILogger<DeleteProdutoHandler>> _loggerMock;
        private readonly DeleteProdutoHandler _handler;

        public DeleteProdutoHandlerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _loggerMock = new Mock<ILogger<DeleteProdutoHandler>>();
            _handler = new DeleteProdutoHandler(_mediatorMock.Object, _produtoRepositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Handle_ProductNotFound_ReturnsNotFoundResponse()
        {
            // Arrange
            var request = new DeleteProdutoRequest { IdProduto = 1 };
            _produtoRepositoryMock.Setup(repo => repo.GetByIdAsync(request.IdProduto))
                .ReturnsAsync((Produto)null);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.CodigoRetorno.Should().Be(StatusCodes.Status404NotFound);
            result.Mensagem.Should().Be("Produto não encontrado.");
        }

        [Fact]
        public async Task Handle_ProductFound_DeletesProductAndReturnsSuccessResponse()
        {
            // Arrange
            var produto = new Produto { Id = 1, Nome = "Produto Teste" };
            var request = new DeleteProdutoRequest { IdProduto = 1 };
            _produtoRepositoryMock.Setup(repo => repo.GetByIdAsync(request.IdProduto))
                .ReturnsAsync(produto);
            _produtoRepositoryMock.Setup(repo => repo.DeleteAsync(produto))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.CodigoRetorno.Should().Be(StatusCodes.Status204NoContent);
            result.Mensagem.Should().Be("Produto removido com sucesso.");
            _produtoRepositoryMock.Verify(repo => repo.DeleteAsync(produto), Times.Once);
        }
    }
}
