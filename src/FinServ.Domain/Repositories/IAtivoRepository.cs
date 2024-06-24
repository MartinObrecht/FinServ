using FinServ.Domain.Entities.Ativos;

namespace FinServ.Domain.Repositories
{
    public interface IAtivoRepository : IRepository<Ativo>
    {
        Task<Ativo> GetByIdAsync(int id);
        Task<IEnumerable<Ativo>> GetAllAsync();
        Task<Ativo> CreateAtivoAsync(Ativo ativo);
        Task<Ativo> UpdateAsync(Ativo ativo);
        Task<Ativo> DeleteAsync(int id);
        Task<IEnumerable<ExtratoAtivos>> CreateAsync(int clienteId);
    }
}
