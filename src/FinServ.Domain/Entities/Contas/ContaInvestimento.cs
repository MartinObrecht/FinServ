using FinServ.Domain.Entities.Clientes;
using FinServ.Domain.Interfaces.Clientes;
using FinServ.Domain.Interfaces.Contas;
using FinServ.Domain.Interfaces.ProdutosFinanceiros;

namespace FinServ.Domain.Entities.Contas
{
    public class ContaInvestimento : IContaInvestimento
    {
        public int Id { get; set; }
        public int InvestidorId { get; set; }
        public Investidor Investidor { get; set; }
        public int Numero { get; set; }
        public decimal Saldo { get; set; }
        public CarteiraInvestimento CarteiraInvestimento { get; set; }

        public int AbreContaInvestimento(IInvestidor investidor)
        {
            throw new NotImplementedException();
        }

        public void AdicionaProdutoFinanceiro(IProdutoFinanceiro produtoFinanceiro)
        {
            throw new NotImplementedException();
        }

        public decimal CalculaValorTotalProdutosFinanceiros(ICollection<IProdutoFinanceiro> carteiraInvestimentos)
        {
            throw new NotImplementedException();
        }

        public ICollection<IProdutoFinanceiro> ConsultarInvestimentos()
        {
            throw new NotImplementedException();
        }

        public decimal ConsultaSaldo()
        {
            throw new NotImplementedException();
        }

        public void Deposita(decimal valor)
        {
            throw new NotImplementedException();
        }

        public void RemoveProdutoFinanceiro(IProdutoFinanceiro produtoFinanceiro)
        {
            throw new NotImplementedException();
        }

        public void Resgata(decimal valor)
        {
            throw new NotImplementedException();
        }
    }
}
