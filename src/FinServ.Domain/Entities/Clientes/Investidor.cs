using FinServ.Domain.Interfaces.Clientes;
using System.Text.RegularExpressions;

namespace FinServ.Domain.Entities.Clientes
{
    public class Investidor : IInvestidor
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Investidor(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }
    }
}
