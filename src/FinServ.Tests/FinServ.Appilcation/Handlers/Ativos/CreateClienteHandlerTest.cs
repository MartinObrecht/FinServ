using FinServ.Application.Handlers.Clientes.CreateCliente;
using FinServ.Domain.Entities.Clientes;
using FinServ.Domain.Entities.Helpers;
using FinServ.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace FinServ.Tests.FinServ.Application.Handlers.Clientes
{
    public class CreateClienteHandlerTest
    {
        private readonly Mock<IClienteRepository> _clienteRepositoryMock;
        private readonly Mock<ILogger<CreateClienteHandler>> _loggerMock;
        private readonly CreateClienteHandler _handler;

        public CreateClienteHandlerTest()
        {
            _clienteRepositoryMock = new Mock<IClienteRepository>();
            _loggerMock = new Mock<ILogger<CreateClienteHandler>>();
            _handler = new CreateClienteHandler(_clienteRepositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Handle_WithInvalidCpf_ReturnsBadRequestResponse()
        {
            // Arrange
            var request = new CreateClienteRequest { Nome = "Teste", Cpf = "123" };

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.CodigoRetorno.Should().Be(StatusCodes.Status400BadRequest);
            result.Mensagem.Should().Be("CPF inválido.");
        }

        [Fact]
        public async Task Handle_WithExistingCliente_ReturnsConflictResponse()
        {
            // Arrange
            var request = new CreateClienteRequest { Nome = "Teste", Cpf = "12345678909" };
            _clienteRepositoryMock.Setup(repo => repo.GetByCpfAsync(It.IsAny<string>()))
                .ReturnsAsync(new Cliente());

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.CodigoRetorno.Should().Be(StatusCodes.Status409Conflict);
            result.Mensagem.Should().Be("Cliente já cadastrado.");
        }

        [Fact]
        public async Task Handle_WithValidData_ReturnsCreatedResponse()
        {
            // Arrange
            var request = new CreateClienteRequest { Nome = "Teste", Cpf = "12345678909" };
            _clienteRepositoryMock.Setup(repo => repo.GetByCpfAsync(It.IsAny<string>()))
                .ReturnsAsync((Cliente)null);
            _clienteRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Cliente>()))
                .Returns(Task.FromResult(new Cliente()));

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.CodigoRetorno.Should().Be(StatusCodes.Status201Created);
            result.Mensagem.Should().Be("Cliente cadastrado com sucesso.");
        }

        [Fact]
        public async Task Handle_WithException_ReturnsInternalServerErrorResponse()
        {
            // Arrange
            var request = new CreateClienteRequest { Nome = "Teste", Cpf = "12345678909" };
            _clienteRepositoryMock.Setup(repo => repo.GetByCpfAsync(It.IsAny<string>()))
                .ReturnsAsync((Cliente)null);
            _clienteRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Cliente>()))
                .Throws(new Exception("Database error"));

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.CodigoRetorno.Should().Be(StatusCodes.Status500InternalServerError);
            result.Mensagem.Should().Be("Erro ao processar o cadastro do cliente. Por favor, tente novamente mais tarde.");
        }
    }
}
