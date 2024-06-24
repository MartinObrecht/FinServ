namespace FinServ.Application.Handlers.Produtos.QueryProdutoByCodigo
{
    public class QueryProdutoByCodigoResponse
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public double TaxaJurosMensal { get; set; }
        public DateTime DataVencimento { get; set; }
        public int Quantidade { get; set; }
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; }

    }
}
