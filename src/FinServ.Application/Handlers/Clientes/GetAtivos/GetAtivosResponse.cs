namespace FinServ.Application.Handlers.Clientes.GetAtivos
{
    public class GetAtivosResponse
    {
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string DataVencimentoProduto { get; set; }
        public decimal TaxaJurosMes { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorAtual { get; set; }
        public int Quantidade { get; set; }
        public string DataCompra { get; set; }

    }
}
