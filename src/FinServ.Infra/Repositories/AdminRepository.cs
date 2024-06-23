using FinServ.Domain.Repositories;
using FinServ.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace FinServ.Infra.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly FinServContext _context;

        public AdminRepository(FinServContext context)
        {
            _context = context;
        }

        public async Task<bool> UserAutorizedAsync(string email, int codigoAcesso)
        {
            try
            {
                var adminExiste = await _context.Administradores.AnyAsync(a => a.Email == email && a.CodigoAcesso == codigoAcesso);
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
