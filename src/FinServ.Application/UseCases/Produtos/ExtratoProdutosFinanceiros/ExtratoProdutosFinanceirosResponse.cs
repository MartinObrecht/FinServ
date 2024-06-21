using FinServ.Application.Models.Responses;
using FinServ.Application.UseCases.Produtos.ObterProdutoFInanceiro;

namespace FinServ.Application.UseCases.Produtos.ExtratoProdutosFinanceiros
{
    public class ExtratoProdutosFinanceirosResponse : ResponseBase
    {
        public List<ObterProdutoFinanceiroResponse> Produtos { get; set; } = new List<ObterProdutoFinanceiroResponse>();

    }
}
    