using FinServ.Application.Handlers.Ativos.GetAtivoById;
using FinServ.Domain.Entities;
using FinServ.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using FinServ.Domain.Entities.Ativos;

namespace FinServ.Tests.FinServ.Application.Handlers.Ativos
{
    public class GetAtivoByIdHandlerTest
    {
        private readonly Mock<IAtivoRepository> _ativoRepositoryMock;
        private readonly Mock<ILogger<GetAtivoByIdHandler>> _loggerMock;
        private readonly GetAtivoByIdHandler _handler;

        public GetAtivoByIdHandlerTest()
        {
            _ativoRepositoryMock = new Mock<IAtivoRepository>();
            _loggerMock = new Mock<ILogger<GetAtivoByIdHandler>>();
            _handler = new GetAtivoByIdHandler(_ativoRepositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Handle_WithValidId_ReturnsAtivoDetails()
        {
            // Arrange
            var ativo = new Ativo
            {
                Id = 1,
                ValorCompra = 1000,
                DataCompra = new DateTime(2021, 01, 01),
                Quantidade = 10,
                ClienteId = 1,
                ProdutoId = 1,
            };

            _ativoRepositoryMock.Setup(repo => repo.GetByIdAsync(1))
                .ReturnsAsync(ativo);

            var request = new GetAtivoByIdRequest { IdAtivo = 1 };

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.IdAtivo.Should().Be(ativo.Id);
            result.ValorCompra.Should().Be(ativo.ValorCompra);
            result.DataCompra.Should().Be(ativo.DataCompra.ToShortDateString());
            result.Quantidade.Should().Be(ativo.Quantidade);
            result.IdCliente.Should().Be(ativo.ClienteId);
            result.IdProduto.Should().Be(ativo.ProdutoId);
            result.CodigoRetorno.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task Handle_WithInvalidId_ReturnsNotFoundResponse()
        {
            // Arrange
            _ativoRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Ativo)null);

            var request = new GetAtivoByIdRequest { IdAtivo = 99 };

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.CodigoRetorno.Should().Be(StatusCodes.Status404NotFound);
            result.Mensagem.Should().Be("Ativo não encontrado.");
        }
    }
}
