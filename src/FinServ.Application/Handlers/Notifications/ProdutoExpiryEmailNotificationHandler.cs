using FinServ.Domain.Repositories;
using MediatR;

namespace FinServ.Application.Handlers.Notifications
{
    public class ProdutoExpiryEmailNotificationHandler : IRequestHandler<ProdutoExpiryEmailNotificationRequest, ProdutoExpiryEmailNotificationResponse>
    {
        private IMediator _mediator;
        private IAtivoRepository _ativoRepository;

        public ProdutoExpiryEmailNotificationHandler(IMediator mediator, IAtivoRepository ativoRepository)
        {
            _mediator = mediator;
            _ativoRepository = ativoRepository;
        }

        public async Task<ProdutoExpiryEmailNotificationResponse> Handle(ProdutoExpiryEmailNotificationRequest request, CancellationToken cancellationToken)
        {
            var produtosComVencimentoHoje = await _ativoRepository.GetProdutosExpiry(request.DataVencimentoProduto);

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
