using MediatR;

namespace FinServ.Application.Handlers.Notifications
{
    public class ProdutoExpiryEmailNotificationRequest : IRequest<ProdutoExpiryEmailNotificationResponse>
    {
        public DateTime DataVencimentoProduto { get; set; }
    }
}
