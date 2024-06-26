using FinServ.Application.Handlers.Clientes.BuyAtivo;
using FinServ.Application.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using FluentAssertions;
using FinServ.Application.Models.Results;

namespace FinServ.Tests.FinServ.Application.Handlers.Clientes
{
    public class BuyAtivoHandlerTest
    {
        private readonly Mock<IClienteService> _clienteServiceMock;
        private readonly Mock<ILogger<BuyAtivoHandler>> _loggerMock;
        private readonly BuyAtivoHandler _handler;

        public BuyAtivoHandlerTest()
        {
            _clienteServiceMock = new Mock<IClienteService>();
            _loggerMock = new Mock<ILogger<BuyAtivoHandler>>();
            _handler = new BuyAtivoHandler(_clienteServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Handle_WithSuccessfulPurchase_ReturnsSuccessResponse()
        {
            // Arrange
            var request = new BuyAtivoRequest
            {
                IdCliente = 1,
                CodigoProduto = 123,
                Quantidade = 5
            };

            var serviceResponse = new BaseResult
            {
                CodigoRetorno = 200,
                Mensagem = "Compra realizada com sucesso."
            };

            _clienteServiceMock.Setup(s => s.ComprarAtivoAsync(request.IdCliente, request.CodigoProduto, request.Quantidade))
                .ReturnsAsync(serviceResponse);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.CodigoRetorno.Should().Be(serviceResponse.CodigoRetorno);
            result.Mensagem.Should().Be(serviceResponse.Mensagem);
        }

        [Fact]
        public async Task Handle_WithFailedPurchase_ReturnsFailureResponse()
        {
            // Arrange
            var request = new BuyAtivoRequest
            {
                IdCliente = 2,
                CodigoProduto = 400,
                Quantidade = 10
            };

            var serviceResponse = new BaseResult
            {
                CodigoRetorno = 400,
                Mensagem = "Compra não realizada."
            };

            _clienteServiceMock.Setup(s => s.ComprarAtivoAsync(request.IdCliente, request.CodigoProduto, request.Quantidade))
                .ReturnsAsync(serviceResponse);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.CodigoRetorno.Should().Be(serviceResponse.CodigoRetorno);
            result.Mensagem.Should().Be(serviceResponse.Mensagem);
        }
    }
}
