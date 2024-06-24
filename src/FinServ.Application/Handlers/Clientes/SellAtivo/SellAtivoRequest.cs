using MediatR;

namespace FinServ.Application.Handlers.Clientes.SellAtivo
{
    public class SellAtivoRequest : IRequest<SellAtivoResponse>
    {
        public int AtivoId { get; set; }
    }
}
