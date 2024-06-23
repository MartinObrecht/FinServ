using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinServ.Domain.Repositories
{
    public interface IAdminRepository
    {
        bool Autorization(string email, int codigoAcesso);
    }
}
