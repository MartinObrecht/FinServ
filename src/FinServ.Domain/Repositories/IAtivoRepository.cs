using FinServ.Domain.Entities.Ativos;

namespace FinServ.Domain.Repositories
{
    public interface IAtivoRepository : IRepository<Ativo>
    {
        Task<IEnumerable<Ativo>> GetAtivosByClienteAsync(int clienteId);
        Task<IEnumerable<Ativo>> GetAtivosByCpfAsync(string cpf);
        Task<IEnumerable<Ativo>> GetProdutosExpiry(DateTime dataVencimentoProduto);
        Task<IEnumerable<ExtratoAtivos>> ExtratoAtivos(string cpf);
    }
}
