namespace FinServ.Application.UseCases.Produtos.ObterProdutoPorCodigo
{
    public class ObterProdutoPorCodigoResponse
    {
        public string NomeAtivo { get; set; }
        public double TaxaJurosMensal { get; set; }
        public DateTime DataVencimento { get; set; }
        public int Quantidade { get; set; }
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int CodigoProduto { get; set; }

    }
}
    