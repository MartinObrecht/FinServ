using FinServ.Domain.Entities.Ativos;
using FinServ.Domain.Interfaces.Entities;

namespace FinServ.Domain.Entities.Clientes
{
    public class Cliente : ICliente
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public ICollection<Ativo> Ativos { get; set; } = new List<Ativo>();
        public Cliente(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }
        public Cliente()
        {
            
        }
    }
}
