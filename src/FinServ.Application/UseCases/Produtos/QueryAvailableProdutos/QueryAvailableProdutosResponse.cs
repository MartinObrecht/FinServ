namespace FinServ.Application.UseCases.Produtos.QueryAvailableProdutos
{
    public class QueryAvailableProdutosResponse
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public double TaxaJurosMensal { get; set; }
        public string DataVencimento { get; set; }
        public int Quantidade { get; set; }
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; }
    }
}
