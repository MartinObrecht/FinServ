using FinServ.Application.Handlers.Clientes.SellAtivo;
using FinServ.Application.Models.Results;
using FinServ.Application.Services.Interfaces;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FinServ.Tests.FinServ.Application.Handlers.Clientes
{
    public class SellAtivoHandlersTest
    {
        private readonly Mock<IClienteService> _clienteServiceMock;
        private readonly Mock<ILogger<SellAtivoHandlers>> _loggerMock;
        private readonly IRequestHandler<SellAtivoRequest, SellAtivoResponse> _handler;

        public SellAtivoHandlersTest()
        {
            _clienteServiceMock = new Mock<IClienteService>();
            _loggerMock = new Mock<ILogger<SellAtivoHandlers>>();
            _handler = new SellAtivoHandlers(_clienteServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Handle_WithSuccessfulSale_ReturnsSuccessResponse()
        {
            // Arrange
            var request = new SellAtivoRequest { AtivoId = 1 };
            var serviceResponse = new BaseResult
            {
                CodigoRetorno = 200,
                Mensagem = "Venda realizada com sucesso."
            };

            _clienteServiceMock.Setup(s => s.VenderAtivoAsync(request.AtivoId))
                .ReturnsAsync(serviceResponse);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.CodigoRetorno.Should().Be(serviceResponse.CodigoRetorno);
            result.Mensagem.Should().Be(serviceResponse.Mensagem);
        }

        [Fact]
        public async Task Handle_WithFailedSale_ReturnsFailureResponse()
        {
            // Arrange
            var request = new SellAtivoRequest { AtivoId = 2 };
            var serviceResponse = new BaseResult
            {
                CodigoRetorno = 400,
                Mensagem = "Venda não realizada."
            };

            _clienteServiceMock.Setup(s => s.VenderAtivoAsync(request.AtivoId))
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
