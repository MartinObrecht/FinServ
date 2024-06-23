namespace FinServ.Domain.Repositories
{
    public interface IAdminRepository
    {
        Task<bool> UserAutorizedAsync(string email, int codigoAcesso);
    }
}
