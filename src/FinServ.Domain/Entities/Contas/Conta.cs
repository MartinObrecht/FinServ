using FinServ.Domain.Entities.Clientes;
using FinServ.Domain.Interfaces.Clientes;
using FinServ.Domain.Interfaces.Contas;
using FinServ.Domain.Interfaces.Produtos;

namespace FinServ.Domain.Entities.Contas
{
    public class Conta : IConta
    {
        public int Id { get; set; }
        public int InvestidorId { get; set; }
        public Investidor Investidor { get; set; }
        public int Numero { get; set; }
        public double Saldo { get; set; }
        public Carteira Carteira { get; set; }

        public int AbreContaInvestimento(IInvestidor investidor)
        {
            throw new NotImplementedException();
        }

        public void AdicionaProdutoFinanceiro(IProduto Produto)
        {
            throw new NotImplementedException();
        }

        public double CalculaValorTotalProdutosFinanceiros(ICollection<IProduto> carteiraInvestimentos)
        {
            throw new NotImplementedException();
        }

        public ICollection<IProduto> ConsultarInvestimentos()
        {
            throw new NotImplementedException();
        }

        public double ConsultaSaldo()
        {
            throw new NotImplementedException();
        }

        public void Deposita(double valor)
        {
            throw new NotImplementedException();
        }

        public void RemoveProdutoFinanceiro(IProduto Produto)
        {
            throw new NotImplementedException();
        }

        public void Resgata(double valor)
        {
            throw new NotImplementedException();
        }
    }
}
