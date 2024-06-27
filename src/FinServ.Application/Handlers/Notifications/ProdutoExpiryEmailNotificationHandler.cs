using FinServ.Domain.Repositories;
using MediatR;

namespace FinServ.Application.Handlers.Notifications
{
    public class ProdutoExpiryEmailNotificationHandler : IRequestHandler<ProdutoExpiryEmailNotificationRequest, ProdutoExpiryEmailNotificationResponse>
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoExpiryEmailNotificationHandler(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProdutoExpiryEmailNotificationResponse> Handle(ProdutoExpiryEmailNotificationRequest request, CancellationToken cancellationToken)
        {
            var produtosComVencimentoHoje = await _unitOfWork.Ativos.GetProdutosExpiry(request.DataVencimentoProduto);

            if (produtosComVencimentoHoje == null)
            {
                return new ProdutoExpiryEmailNotificationResponse
                {
                    Email = "teste",
                    Mensagem = "Nenhum produto encontrado."
                };
            }

            await _mediator.Publish(new ProdutoExpiryNotification(request.DataVencimentoProduto));

            return new ProdutoExpiryEmailNotificationResponse
            {
                Email = "teste",
                Mensagem = "Email enviado com sucesso."
            };
            
        }
    }
}
