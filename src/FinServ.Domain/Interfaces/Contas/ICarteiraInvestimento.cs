using FinServ.Domain.Entities.Contas;
using FinServ.Domain.Entities.Produtos;

namespace FinServ.Domain.Interfaces.Contas
{
    public interface ICarteira : IEntidadeBase
    {
        int ContaId { get; set; }
        Conta Conta { get; set; }
        double ValorPatrimonio { get; set; }
        int AtivoId { get; set; }
        ICollection<Ativo> Ativos { get; set; }

    }
}
