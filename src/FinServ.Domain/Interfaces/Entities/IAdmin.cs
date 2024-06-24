namespace FinServ.Domain.Interfaces.Entities
{
    public interface IAdmin
    {
        string Email { get; set; }
        int CodigoAcesso { get; set; }
    }
}
