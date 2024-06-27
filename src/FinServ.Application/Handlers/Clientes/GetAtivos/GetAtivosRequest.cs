using MediatR;

namespace FinServ.Application.Handlers.Clientes.GetAtivos
{
    public class GetAtivosRequest : IRequest<GetAtivosResponse>
    {
        public string Cpf { get; set; }
    }
}
