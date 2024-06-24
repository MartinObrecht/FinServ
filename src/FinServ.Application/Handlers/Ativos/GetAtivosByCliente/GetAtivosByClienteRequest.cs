using MediatR;

namespace FinServ.Application.Handlers.Ativos.GetAtivosByCliente
{
    public class GetAtivosByClienteRequest : IRequest<IList<GetAtivosByClienteResponse>>
    {
        public int ClienteId { get; set; }
    }
}
