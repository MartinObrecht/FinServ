using FinServ.Domain.Entities.Clientes;
using FinServ.Domain.Entities.Contas;

namespace FinServ.Domain.Interfaces.Contas
{
    public interface IConta : IEntidadeBase
    {
        int InvestidorId { get; set; }
        Investidor Investidor { get; set; }
        int Numero { get; set; }
        double Saldo { get; set; }
        Carteira Carteira { get; set; }
    }
}
