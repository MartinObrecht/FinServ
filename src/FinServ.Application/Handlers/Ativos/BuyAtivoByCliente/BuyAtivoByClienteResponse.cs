using FinServ.Application.Models.Results;

namespace FinServ.Application.Handlers.Ativos.BuyAtivoByCliente
{
    public class BuyAtivoByClienteResponse : BaseResult
    {
        public int IdAtivo { get; set; }
        public string NomeCliente { get; set; }
        public string NomeProduto { get; set; }
        public double ValorCompra { get; set; }
        public int Quantidade { get; set; }
    }
}
