using FinServ.Application.Models.Results;

namespace FinServ.Application.Handlers.Ativos.GetAtivoById
{
    public class GetAtivoByIdResponse : BaseResult
    {
        public int IdAtivo { get; set; }
        public decimal ValorCompra { get; set; }
        public string DataCompra { get; set; }
        public int Quantidade { get; set; }
        public int IdCliente { get; set; }
        public int IdProduto { get; set; }

    }
}
