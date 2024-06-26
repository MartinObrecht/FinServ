using FinServ.Application.Handlers.Notifications;
using FinServ.Domain.Entities.Produtos;
using FinServ.Domain.Repositories;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;


namespace FinServ.Tests.FinServ.Application.Handlers.Notifications
{
    public class ProdutoExpiryEmailNotificationHandlerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IAtivoRepository> _ativoRepositoryMock;
        private readonly Mock<ILogger<ProdutoExpiryEmailNotificationHandler>> _loggerMock;
        private readonly ProdutoExpiryEmailNotificationHandler _handler;

        public ProdutoExpiryEmailNotificationHandlerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _ativoRepositoryMock = new Mock<IAtivoRepository>();
            _loggerMock = new Mock<ILogger<ProdutoExpiryEmailNotificationHandler>>();
            _handler = new ProdutoExpiryEmailNotificationHandler(_mediatorMock.Object, _ativoRepositoryMock.Object);
        }

        //[Fact]
        //public async Task Handle_WithNoProdutosFound_ReturnsNoProductFoundMessage()
        //{
        //    // Arrange
        //    var request = new ProdutoExpiryEmailNotificationRequest { DataVencimentoProduto = System.DateTime.Now };
        //    _ativoRepositoryMock.Setup(repo => repo.GetProdutosExpiry(request.DataVencimentoProduto))
        //        .ReturnsAsync((List<Produto>)null);

        //    // Act
        //    var result = await _handler.Handle(request, CancellationToken.None);

        //    // Assert
        //    result.Should().NotBeNull();
        //    result.Email.Should().Be("teste");
        //    result.Mensagem.Should().Be("Nenhum produto encontrado.");
        //}

        //[Fact]
        //public async Task Handle_WithProdutosFound_ReturnsSuccessMessage()
        //{
        //    // Arrange
        //    var request = new ProdutoExpiryEmailNotificationRequest { DataVencimentoProduto = System.DateTime.Now };
        //    var produtos = new List<Produto> { new Produto() };
        //    _ativoRepositoryMock.Setup(repo => repo.GetProdutosExpiry(request.DataVencimentoProduto))
        //        .ReturnsAsync(produtos);

        //    // Act
        //    var result = await _handler.Handle(request, CancellationToken.None);

        //    // Assert
        //    result.Should().NotBeNull();
        //    result.Email.Should().Be("teste");
        //    result.Mensagem.Should().Be("Email enviado com sucesso.");
        //}
    }
}
