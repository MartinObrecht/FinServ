using MediatR;

namespace FinServ.Application.Handlers.Ativos.BuyAtivoByCliente
{
    public class BuyAtivoByClienteRequest : IRequest<BuyAtivoByClienteResponse>
    {
        public int IdCliente { get; set; }
        public int CodigoProduto { get; set; }
        public double ValorCompra { get; set; }
        public int Quantidade { get; set; }
    }
}
