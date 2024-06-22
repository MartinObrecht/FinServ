namespace FinServ.Application.UseCases.Produtos.ConsultarProdutosDisponiveis
{
    public class ConsultarProdutosDisponiveisResponse
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public double TaxaJurosMensal { get; set; }
        public string DataVencimento { get; set; }
        public int Quantidade { get; set; }
        public string TipoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int CodigoTipoProduto { get; set; }
    }
}
