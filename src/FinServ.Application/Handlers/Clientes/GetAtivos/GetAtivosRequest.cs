using MediatR;

namespace FinServ.Application.Handlers.Clientes.GetAtivos
{
    public class GetAtivosRequest : IRequest<IList<GetAtivosResponse>>
    {
        public int ClienteId { get; set; }
    }
}
