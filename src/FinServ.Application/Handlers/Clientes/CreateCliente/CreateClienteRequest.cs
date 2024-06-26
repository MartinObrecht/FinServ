using MediatR;

namespace FinServ.Application.Handlers.Clientes.CreateCliente
{
    public class CreateClienteRequest : IRequest<CreateClienteResponse>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public decimal Saldo { get; set; }
    }
}
