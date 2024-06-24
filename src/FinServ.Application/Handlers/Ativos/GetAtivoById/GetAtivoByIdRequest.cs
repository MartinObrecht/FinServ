using MediatR;

namespace FinServ.Application.Handlers.Ativos.GetAtivoById
{
    public class GetAtivoByIdRequest : IRequest<GetAtivoByIdResponse>
    {
        public int IdAtivo    { get; set; }
    }
}
