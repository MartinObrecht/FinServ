using FinServ.Domain.Entities.ProdutosFinanceiros;
using FinServ.Domain.Interfaces.Contas;

namespace FinServ.Domain.Entities.Contas
{
    public class CarteiraInvestimento : ICarteiraInvestimento
    {
        public int Id { get; set; }
        public int ContaId { get; set; }
        public ContaInvestimento Conta { get; set; }
        public int AtivoFinanceiroId { get; set; }
        public ICollection<AtivoFinanceiro> AtivosFinanceiros { get; set; } = new List<AtivoFinanceiro>();
    }
}
