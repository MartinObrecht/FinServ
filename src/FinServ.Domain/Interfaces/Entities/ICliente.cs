using FinServ.Domain.Entities.Ativos;

namespace FinServ.Domain.Interfaces.Entities
{
    public interface ICliente : IEntidadeBase
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        ICollection<Ativo> Ativos { get; set; }
    }
}
