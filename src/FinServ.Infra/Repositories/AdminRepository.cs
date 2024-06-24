using FinServ.Domain.Entities.Admin;
using FinServ.Domain.Repositories;
using FinServ.Infra.Database.Context;

namespace FinServ.Infra.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly FinServContext _context;

        public AdminRepository(FinServContext context)
        {
            _context = context;
        }

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

        public Task UpdateAsync(Admin entity)
        {
            throw new NotImplementedException();
        }
    }
}
