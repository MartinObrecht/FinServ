using MediatR;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.Handlers.Notifications
{
    public class ProductExpiryEmailNotification : INotificationHandler<ProdutoExpiryNotification>
    {
        private readonly ILogger<ProductExpiryEmailNotification> _logger;
        private readonly IMediator _mediator;

        public ProductExpiryEmailNotification(ILogger<ProductExpiryEmailNotification> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Handle(ProdutoExpiryNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Sending email notification: {notification.DataVencimentoProduto}");

            //logica para enviar email

            await Task.CompletedTask;
        }
    }
}
