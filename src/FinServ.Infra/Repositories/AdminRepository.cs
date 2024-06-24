using FinServ.Domain.Entities.Admin;
using FinServ.Domain.Repositories;
using FinServ.Infra.Database.Context;

namespace FinServ.Infra.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        public Task<Admin> AddAsync(Admin entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Admin entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Admin>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Admin> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Admin entity)
        {
            throw new NotImplementedException();
        }
    }
}
