using FinServ.Api.Controllers;
using FinServ.Application.Handlers.Clientes.BuyAtivo;
using FinServ.Application.Handlers.Clientes.CreateCliente;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace FinServ.Tests.FinServ.Api.Controllers
{
    public class ClientesControllerTest
    {
        private readonly ClientesController _clientesController;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<ClientesController>> _loggerMock;
        private readonly Mock<IValidator<CreateClienteRequest>> _createClienteValidatorMock;
        private readonly Mock<IValidator<BuyAtivoRequest>> _buyAtivoRequestValidatorMock;

        public ClientesControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<ClientesController>>();
            _createClienteValidatorMock = new Mock<IValidator<CreateClienteRequest>>();
            _buyAtivoRequestValidatorMock = new Mock<IValidator<BuyAtivoRequest>>();

            _clientesController = new ClientesController(_mediatorMock.Object, _loggerMock.Object, _createClienteValidatorMock.Object, _buyAtivoRequestValidatorMock.Object);
        }

        [Fact]
        public async Task CreateAsync_WithValidRequest_ReturnsCreatedResult()
        {
            // Arrange
            var request = new CreateClienteRequest { Cpf = "12345678901", Nome = "Fulano" };
            var validationResult = new ValidationResult { };
            _createClienteValidatorMock.Setup(x => x.ValidateAsync(request, default)).ReturnsAsync(validationResult);

            var expectedResponse = new CreateClienteResponse
            {
                CodigoRetorno = StatusCodes.Status201Created,
                Mensagem = "Cliente criado com sucesso."
            };
            _mediatorMock.Setup(x => x.Send(request, default)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _clientesController.CreateAsync(request);

            // Assert
            result.Should().BeOfType<CreatedResult>();
            result.As<CreatedResult>().Value.Should().Be(expectedResponse);
        }

        [Fact]
        public async Task BuyAtivoAsync_WithValidRequest_ReturnsCreatedResult()
        {
            // Arrange
            var request = new BuyAtivoRequest();
            var validationResult = new ValidationResult();
            _buyAtivoRequestValidatorMock.Setup(x => x.ValidateAsync(request, default)).ReturnsAsync(validationResult);

            var expectedResponse = new BuyAtivoResponse
            {
                CodigoRetorno = StatusCodes.Status201Created,
                Mensagem = "Ativo comprado com sucesso."
            };
            _mediatorMock.Setup(x => x.Send(request, default)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _clientesController.BuyAtivoAsync(request);

            // Assert
            result.Should().BeOfType<CreatedResult>();
            result.As<CreatedResult>().Value.Should().Be(expectedResponse);
        }
    }
}
