using FinServ.Application.Handlers.Produtos.CreateProduto;
using FinServ.Application.Handlers.Produtos.CreateProdutos;
using FinServ.Domain.Entities.Produtos;
using FinServ.Domain.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FinServ.Tests.FinServ.Application.Handlers.Produtos
{
    public class CreateProdutosHandlerTest
    {
        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
        private readonly Mock<ILogger<CreateProdutosHandler>> _loggerMock;
        private readonly CreateProdutosHandler _handler;

        public CreateProdutosHandlerTest()
        {
            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _loggerMock = new Mock<ILogger<CreateProdutosHandler>>();
            _handler = new CreateProdutosHandler(_produtoRepositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Handle_WithValidProdutos_CreatesProdutosAndReturnsSuccessResponse()
        {
            // Arrange
            var request = new CreateProdutosRequest
            {
                Produtos = new List<CreateProdutoRequest>
                {
                    new CreateProdutoRequest
                    {
                        Nome = "Produto 1",
                        Valor = 100,
                        TaxaJurosMensal = 0.05m,
                        DataVencimento = System.DateTime.Now.AddYears(1),
                        Quantidade = 10,
                        CodigoProduto = 1234,
                        Descricao = "Descricao Produto 1"
                    }
                }
            };

            _produtoRepositoryMock.Setup(repo => repo.AddRangeAsync(It.IsAny<List<Produto>>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.CodigoRetorno.Should().Be(StatusCodes.Status201Created);
            result.Mensagem.Should().Be("Produtos financeiros cadastrados com sucesso.");
            _produtoRepositoryMock.Verify(repo => repo.AddRangeAsync(It.IsAny<List<Produto>>()), Times.Once);
        }
    }
}
