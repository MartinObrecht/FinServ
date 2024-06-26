using FinServ.Api.Controllers;
using FinServ.Application.Handlers.Produtos.CreateProdutos;
using FinServ.Application.Handlers.Produtos.DeleteProduct;
using FinServ.Application.Handlers.Produtos.QueryProdutoByCodigo;
using FinServ.Application.Handlers.Produtos.UpdateProduto;
using FinServ.Application.Handlers.Produtos.QueryAvailableProdutos;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using FluentValidation;

namespace FinServ.Tests.FinServ.Api.Controllers
{
    public class ProdutosControllerTest
    {
        private readonly ProdutosController _produtosController;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<ProdutosController>> _loggerMock;
        private readonly Mock<IValidator<CreateProdutosRequest>> _createProdutoRequestValidatorMock;

        public ProdutosControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<ProdutosController>>();
            _createProdutoRequestValidatorMock = new Mock<IValidator<CreateProdutosRequest>>();

            _produtosController = new ProdutosController(_mediatorMock.Object, _loggerMock.Object, _createProdutoRequestValidatorMock.Object);
        }

        [Fact]
        public async Task AddAsync_WithValidRequest_ReturnsCreatedResult()
        {
            // Arrange
            var request = new CreateProdutosRequest();
            var expectedResponse = new CreateProdutosResponse
            {
                CodigoRetorno = StatusCodes.Status201Created,
                Mensagem = "Produto criado com sucesso."
            };

            _mediatorMock.Setup(x => x.Send(request, default)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _produtosController.AddAsync(request);

            // Assert
            result.Should().BeOfType<CreatedResult>();
            result.As<CreatedResult>().Value.Should().Be(expectedResponse);
        }

        [Fact]
        public async Task GetByCodigoAsync_WithValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new QueryProdutoByCodigoRequest { CodigoProduto = 123 };
            var expectedResponse = new QueryProdutoByCodigoResponse
            {
                CodigoRetorno = StatusCodes.Status200OK,
                Mensagem = "Produto encontrado."
            };

            _mediatorMock.Setup(x => x.Send(request, default)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _produtosController.GetByCodigoAsync(request);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().Be(expectedResponse);
        }

        [Fact]
        public async Task GetAvailableAsync_WithValidRequest_ReturnsOkResult()
        {
            // Arrange
            var expectedResponse = new List<QueryAvailableProdutosResponse>
            {
                new QueryAvailableProdutosResponse { CodigoProduto = 123, Nome = "Produto Teste" }
            };

            _mediatorMock.Setup(x => x.Send(It.IsAny<QueryAvailableProdutosRequest>(), default)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _produtosController.GetAvailableAsync();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task UpdateAsync_WithValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new UpdateProdutoRequest();
            var expectedResponse = new UpdateProdutoResponse
            {
                CodigoRetorno = StatusCodes.Status200OK,
                Mensagem = "Produto atualizado com sucesso."
            };

            _mediatorMock.Setup(x => x.Send(request, default)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _produtosController.UpdateAsync(request);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().Be(expectedResponse);
        }

        [Fact]
        public async Task DeleteAsync_WithValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new DeleteProdutoRequest { IdProduto = 1};
            var expectedResponse = new DeleteProdutoResponse
            {
                CodigoRetorno = StatusCodes.Status204NoContent,
                Mensagem = "Produto removido com sucesso."
            };

            _mediatorMock.Setup(x => x.Send(request, default)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _produtosController.DeleteAsync(request);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().Be(expectedResponse);
        }
    }
}
