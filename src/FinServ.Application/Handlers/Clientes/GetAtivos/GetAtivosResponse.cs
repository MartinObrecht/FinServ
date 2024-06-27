using FinServ.Application.Handlers.Clientes.GetAtivos.Responses;
using FinServ.Application.Models.Results;

namespace FinServ.Application.Handlers.Clientes.GetAtivos
{
    public class GetAtivosResponse : BaseResult
    {
        public string Nome { get; set; }
        public decimal Saldo { get; set; }
        public decimal Patrimonio { get; set; }

        public IList<AtivoDto> Ativos { get; set; } = new List<AtivoDto>();

    }
}
