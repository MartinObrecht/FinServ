using FinServ.Domain.Entities.Clientes;
using FinServ.Domain.Entities.ProdutosFinanceiros;
using FinServ.Domain.Interfaces.Clientes;
using FinServ.Domain.Interfaces.ProdutosFinanceiros;

namespace FinServ.Domain.Interfaces.Contas
{
    public interface IContaInvestimento : IEntidadeBase
    {
        int InvestidorId { get; set; }
        Investidor Investidor { get; set; }
        int Numero { get; set; }
        decimal Saldo { get; set; }
        ICollection<ProdutoFinanceiro> ProdutosFinanceiros { get; set; }

        int AbreContaInvestimento(IInvestidor investidor);
        void AdicionaProdutoFinanceiro(IProdutoFinanceiro produtoFinanceiro);
        void RemoveProdutoFinanceiro(IProdutoFinanceiro produtoFinanceiro);
        decimal ConsultaSaldo();
        decimal CalculaValorTotalProdutosFinanceiros(ICollection<IProdutoFinanceiro> carteiraInvestimentos);
        ICollection<IProdutoFinanceiro> ConsultarInvestimentos();
        void Deposita(decimal valor);
        void Resgata(decimal valor);
    }
}
