using FinServ.Api.Controllers;
using FinServ.Application.Handlers.Ativos.GetAtivoById;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace FinServ.Tests
{
    public class AtivosControllerTest
    {
        private readonly AtivosController _ativosController;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<AtivosController>> _loggerMock;

        public AtivosControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<AtivosController>>();

            _ativosController = new AtivosController(_mediatorMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetByIdAsync_WithValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new GetAtivoByIdRequest{ IdAtivo = 1 };
            var expectedResponse = new GetAtivoByIdResponse
            { 
                IdAtivo = 1 , 
                ValorCompra = 1000, 
                DataCompra = "2021-01-01", 
                Quantidade = 10, 
                IdCliente = 1, 
                IdProduto = 1,
                CodigoRetorno = StatusCodes.Status200OK,
                Mensagem = "Ativo encontrado."};

            _mediatorMock.Setup(x => x.Send(request, default)).ReturnsAsync(expectedResponse);
            
            // Act
            var result = await _ativosController.GetByIdAsync(request);

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();
            result.Result.As<OkObjectResult>().Value.Should().Be(expectedResponse);
        }

        [Fact]
        public async Task GetByIdAsync_WithNullResponse_ReturnsNotFoundResult()
        {
            // Arrange
            var request = new GetAtivoByIdRequest{ IdAtivo = 2 };
            var expectedResponse = new GetAtivoByIdResponse
            { 
                CodigoRetorno = StatusCodes.Status404NotFound,
                Mensagem = "Ativo não encontrado."
            };

            _mediatorMock.Setup(x => x.Send(request, default)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _ativosController.GetByIdAsync(request);

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();
            result.Result.As<OkObjectResult>().Value.Should().Be(expectedResponse);
        }
    }
}