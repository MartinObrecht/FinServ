using FinServ.Domain.Entities.Ativos;
using FinServ.Domain.Repositories;

namespace FinServ.Infra.Repositories
{
    public class AtivoRepository : IAtivoRepository
    {
        public Task<Ativo> CreateAtivoAsync(Ativo ativo)
        {
            throw new NotImplementedException();
        }

        public Task<Ativo> DeleteAtivoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Ativo> GetAtivoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ativo>> GetAtivosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Ativo> UpdateAtivoAsync(Ativo ativo)
        {
            throw new NotImplementedException();
        }
    }
}
