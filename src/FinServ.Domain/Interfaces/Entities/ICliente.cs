using FinServ.Domain.Entities.Ativos;

namespace FinServ.Domain.Interfaces.Entities
{
    public interface ICliente : IEntidadeBase
    {
        string Nome { get; set; }
        string Cpf { get; set; }
        decimal Saldo { get; set; }
        ICollection<Ativo> Ativos { get; set; }
    }
}
