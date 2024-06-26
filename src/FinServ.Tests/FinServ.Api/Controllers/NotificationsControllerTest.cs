using FinServ.Api.Controllers;
using FinServ.Application.Handlers.Notifications;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FinServ.Tests.FinServ.Api.Controllers
{
    public class NotificationsControllerTest
    {
        private readonly NotificationsController _notificationsController;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<NotificationsController>> _loggerMock;

        public NotificationsControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<NotificationsController>>();

            _notificationsController = new NotificationsController(_mediatorMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task ProdutoExpiryEmailNotification_WithSuccess_ReturnsOkResult()
        {
            // Arrange
            var request = new ProdutoExpiryEmailNotificationRequest();
            var expectedResponse = new ProdutoExpiryEmailNotificationResponse
            {
                CodigoRetorno = StatusCodes.Status200OK,
                Mensagem = "Notificação enviada com sucesso."
            };

            _mediatorMock.Setup(x => x.Send(request, default)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _notificationsController.ProdutoExpiryEmailNotification(request);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task ProdutoExpiryEmailNotification_WithFailure_ReturnsNotFoundResult()
        {
            // Arrange
            var request = new ProdutoExpiryEmailNotificationRequest();
            var expectedResponse = new ProdutoExpiryEmailNotificationResponse
            {
                CodigoRetorno = StatusCodes.Status404NotFound,
                Mensagem = "Notificação não pode ser enviada."
            };

            _mediatorMock.Setup(x => x.Send(request, default)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _notificationsController.ProdutoExpiryEmailNotification(request);

            // Assert
            result.Should().BeOfType<NotFoundObjectResult>();
            result.As<NotFoundObjectResult>().Value.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
