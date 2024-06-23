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

        public bool Autorization(string email, int codigoAcesso)
        {
            try
            {
                var adminExiste = _context.Administradores.Any(a => a.Email == email && a.CodigoAcesso == codigoAcesso);
                return adminExiste;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao autenticar administrador: {ex.Message}");
                return false;
            }
        }
    }
}
