using FinServ.Domain.Interfaces.Clientes;

namespace FinServ.Domain.Repositories.Investidores
{
    public interface IInvestidorRepository
    {
        Task<IInvestidor?> ObterPorCpfAsync(string cpf);
        Task<IInvestidor?> ObterPorIdAsync(int id);
        Task Cadastrar(IInvestidor investidor);
    }
}
