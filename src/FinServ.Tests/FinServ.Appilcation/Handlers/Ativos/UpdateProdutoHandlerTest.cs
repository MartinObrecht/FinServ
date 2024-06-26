using FinServ.Application.Handlers.Produtos.UpdateProduto;
using FinServ.Domain.Entities.Produtos;
using FinServ.Domain.Repositories;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FinServ.Tests.FinServ.Application.Handlers.Produtos
{
    public class UpdateProdutoHandlerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
        private readonly Mock<ILogger<UpdateProdutoHandler>> _loggerMock;
        private readonly UpdateProdutoHandler _handler;

        public UpdateProdutoHandlerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _loggerMock = new Mock<ILogger<UpdateProdutoHandler>>();
            _handler = new UpdateProdutoHandler(_mediatorMock.Object, _produtoRepositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Handle_ProductNotFound_ReturnsNotFoundResponse()
        {
            // Arrange
            var request = new UpdateProdutoRequest { IdProduto = 1 };
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
        public async Task Handle_ValidRequest_UpdatesProductAndReturnsSuccessResponse()
        {
            // Arrange
            var produto = new Produto { Id = 1, Nome = "Produto Original" };
            var request = new UpdateProdutoRequest
            {
                IdProduto = 1,
                Nome = "Produto Atualizado",
                TaxaJurosMensal = 0.05,
                DataVencimento = DateTime.Now.AddYears(1).ToString(),
                Quantidade = 100,
                CodigoProduto = 1234,
                Descricao = "Descricao Atualizada",
                Valor = 200
            };
            var response = new UpdateProdutoResponse { IdProduto = 1, CodigoRetorno = 200, Mensagem = "Produto atualizado com sucesso." };

            _produtoRepositoryMock.Setup(repo => repo.GetByIdAsync(request.IdProduto))
                .ReturnsAsync(produto);
            _produtoRepositoryMock.Setup(repo => repo.Update(It.IsAny<Produto>()))
                .Verifiable();

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.CodigoRetorno.Should().Be(StatusCodes.Status200OK);
            result.Mensagem.Should().Be("Produto atualizado com sucesso.");
            _produtoRepositoryMock.Verify(repo => repo.Update(It.IsAny<Produto>()), Times.Once);
        }
    }
}
