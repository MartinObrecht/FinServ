using FinServ.Application.Models.Responses;

namespace FinServ.Application.UseCases.Produtos.ObterProdutoFInanceiro
{
    public class ObterProdutoFinanceiroResponse : ResponseBase
    {
        public string NomeProduto { get; set; }
        public decimal TaxaJuros { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
