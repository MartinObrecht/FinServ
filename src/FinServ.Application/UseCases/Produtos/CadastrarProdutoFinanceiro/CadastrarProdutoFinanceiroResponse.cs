using FinServ.Application.Models.Responses;

namespace FinServ.Application.UseCases.Produtos.CadastrarProdutoFinanceiro
{
    public class CadastrarProdutoFinanceiroResponse : ResponseBase
    {
        public string Nome { get; set; }
        public int CodigoTipoProduto { get; set; }
        public decimal TaxaJuros { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
