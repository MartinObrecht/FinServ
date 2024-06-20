using FinServ.Domain.Entities.Contas;
using FinServ.Domain.Interfaces.Clientes;

namespace FinServ.Domain.Entities.Clientes
{
    public class Investidor : IInvestidor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public bool CpfValido(string cpf)
        {
            throw new NotImplementedException();
        }

        public bool NomeValido(string nome)
        {
            throw new NotImplementedException();
        }

        public void RegistraInvestidor(string nome, string cpf)
        {
            throw new NotImplementedException();
        }
    }
}
