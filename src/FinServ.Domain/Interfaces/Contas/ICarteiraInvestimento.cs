using FinServ.Domain.Entities.Contas;
using FinServ.Domain.Entities.ProdutosFinanceiros;

namespace FinServ.Domain.Interfaces.Contas
{
    public interface ICarteiraInvestimento : IEntidadeBase
    {
        int ContaId { get; set; }
        ContaInvestimento Conta { get; set; }
        int AtivoFinanceiroId { get; set; }
        ICollection<AtivoFinanceiro> AtivosFinanceiros { get; set; }

    }
}
