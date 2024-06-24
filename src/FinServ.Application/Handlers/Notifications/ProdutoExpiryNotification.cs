using MediatR;

namespace FinServ.Application.Handlers.Notifications
{
    public class ProdutoExpiryNotification : INotification
    {
        public ProdutoExpiryNotification(DateTime dataVencimentoProduto)
        {
            DataVencimentoProduto = dataVencimentoProduto;
        }

        public DateTime DataVencimentoProduto { get; }

    }
}
