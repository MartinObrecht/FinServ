using FinServ.Domain.Entities.Contas;

namespace FinServ.Domain.Interfaces.Clientes
{
    public interface IInvestidor : IEntidadeBase
    {
        string Nome { get; set; }
        string Cpf { get; set; }

        void RegistraInvestidor(string nome, string cpf);
        bool CpfValido(string cpf);
        bool NomeValido(string nome);
    }
}
    