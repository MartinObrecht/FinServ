using MediatR;

namespace FinServ.Application.Handlers.Ativos.BuyAtivoByCliente
{
    public class BuyAtivoByClienteHandler : IRequestHandler<BuyAtivoByClienteRequest, BuyAtivoByClienteResponse>
    {
        public Task<BuyAtivoByClienteResponse> Handle(BuyAtivoByClienteRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
