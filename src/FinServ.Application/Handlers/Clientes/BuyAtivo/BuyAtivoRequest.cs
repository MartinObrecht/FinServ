using MediatR;

namespace FinServ.Application.Handlers.Clientes.BuyAtivo
{
    public class BuyAtivoRequest : IRequest<BuyAtivoResponse>
    {
        public int IdCliente { get; set; }
        public int CodigoProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
