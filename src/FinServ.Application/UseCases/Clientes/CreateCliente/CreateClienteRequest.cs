using MediatR;

namespace FinServ.Application.UseCases.Clientes.CreateCliente
{
    public class CreateClienteRequest : IRequest<CreateClienteResponse>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}
