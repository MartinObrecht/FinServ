using FinServ.Application.Models.Results;

namespace FinServ.Application.Handlers.Produtos.QueryProdutoByCodigo
{
    public class QueryProdutoByCodigoResponse : BaseResult
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal TaxaJurosMensal { get; set; }
        public DateTime DataVencimento { get; set; }
        public int Quantidade { get; set; }
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; }

    }
}
