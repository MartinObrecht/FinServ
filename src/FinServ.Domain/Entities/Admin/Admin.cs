using FinServ.Domain.Interfaces.Entities;

namespace FinServ.Domain.Entities.Admin
{
    public class Admin : IAdmin
    {
        public string Email { get; set; }
        public int CodigoAcesso { get; set; }
    }
}
