using FinServ.Application.Models.Results;
using FinServ.Domain.Entities.Ativos;

namespace FinServ.Application.Services.Interfaces
{
    public interface IClienteService
    {
        Task<BaseResult> ComprarAtivoAsync(string cpf, int codigoProduto, int quantidade);
        Task<BaseResult> VenderAtivoAsync(int IdAtivo, string cpf);

    }
}
