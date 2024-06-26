using FinServ.Application.Handlers.Clientes.GetAtivos;
using FinServ.Domain.Entities;
using FinServ.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using FinServ.Domain.Entities.Ativos;

namespace FinServ.Tests.FinServ.Application.Handlers.Clientes
{
    public class GetAtivosHandlerTest
    {
        private readonly Mock<IAtivoRepository> _ativoRepositoryMock;
        private readonly Mock<ILogger<GetAtivosHandler>> _loggerMock;
        private readonly GetAtivosHandler _handler;

        public GetAtivosHandlerTest()
        {
            _ativoRepositoryMock = new Mock<IAtivoRepository>();
            _loggerMock = new Mock<ILogger<GetAtivosHandler>>();
            _handler = new GetAtivosHandler(_ativoRepositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Handle_WithValidClienteId_ReturnsAtivosList()
        {
            // Arrange
            var ativos = new List<ExtratoAtivos>
            {
                new ExtratoAtivos
                {
                    IdCliente = 1,
                    NomeProduto = "Produto 1",
                    DescricaoProduto = "Descrição do Produto 1",
                    DataVencimentoProduto = DateTime.Now.AddDays(30),
                    ValorCompra = 1000,
                    DataCompra = DateTime.Now.AddDays(-10),
                    ValorAtual = 1050,
                    Quantidade = 1
                }
            };

            var response = new List<GetAtivosResponse>
            {
                new GetAtivosResponse
                {
                    NomeProduto = "Produto 1",
                    DescricaoProduto = "Descrição do Produto 1",
                    DataVencimentoProduto = DateTime.Now.AddDays(30).ToShortDateString(),
                    TaxaJurosMes = 0.01m,
                    ValorCompra = 1000,
                    DataCompra = DateTime.Now.AddDays(-10).ToShortDateString(),
                    ValorAtual = 1050,
                    Quantidade = 1
                }
            };

            _ativoRepositoryMock.Setup(repo => repo.GetAtivos(It.IsAny<int>()))
                .ReturnsAsync(ativos);

            var request = new GetAtivosRequest { ClienteId = 1 };

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(ativos.Count);
            result[0].NomeProduto.Should().Be(ativos[0].NomeProduto);
            result[0].DescricaoProduto.Should().Be(ativos[0].DescricaoProduto);
            result[0].DataVencimentoProduto.Should().Be(ativos[0].DataVencimentoProduto.ToShortDateString());
            result[0].TaxaJurosMes.Should().Be(ativos[0].TaxaJurosMes);
            result[0].ValorCompra.Should().Be(ativos[0].ValorCompra);
            result[0].DataCompra.Should().Be(ativos[0].DataCompra.ToShortDateString());
            result[0].ValorAtual.Should().Be(ativos[0].ValorAtual);
            result[0].Quantidade.Should().Be(ativos[0].Quantidade);
        }

        [Fact]
        public async Task Handle_WithNoAtivos_ReturnsEmptyList()
        {
            // Arrange
            _ativoRepositoryMock.Setup(repo => repo.GetAtivos(It.IsAny<int>()))
                .ReturnsAsync(new List<ExtratoAtivos>());

            var request = new GetAtivosRequest { ClienteId = 1 };

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }
    }
}
