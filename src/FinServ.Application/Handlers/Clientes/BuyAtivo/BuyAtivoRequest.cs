using MediatR;

namespace FinServ.Application.Handlers.Clientes.BuyAtivo
{
    public class BuyAtivoRequest : IRequest<BuyAtivoResponse>
    {
        public string Cpf { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
