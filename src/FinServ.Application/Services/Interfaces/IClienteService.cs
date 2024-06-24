using FinServ.Application.Models.Results;
using FinServ.Domain.Entities.Ativos;

namespace FinServ.Application.Services.Interfaces
{
    public interface IClienteService
    {
        Task<BaseResult> ComprarAtivoAsync(int idCliente, int codigoProduto, int quantidade);
        Task<BaseResult> VenderAtivoAsync(int IdAtivo);

    }
}
