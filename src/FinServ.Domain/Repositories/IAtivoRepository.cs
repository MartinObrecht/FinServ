using FinServ.Domain.Entities.Ativos;

namespace FinServ.Domain.Repositories
{
    public interface IAtivoRepository
    {
        Task<Ativo> GetAtivoByIdAsync(int id);
        Task<IEnumerable<Ativo>> GetAtivosAsync();
        Task<Ativo> CreateAtivoAsync(Ativo ativo);
        Task<Ativo> UpdateAtivoAsync(Ativo ativo);
        Task<Ativo> DeleteAtivoAsync(int id);

    }
}
