namespace FinServ.Application.Handlers.Clientes.GetAtivos
{
    public class GetAtivosResponse
    {
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string DataVencimentoProduto { get; set; }
        public double TaxaJurosMes { get; set; }
        public double ValorCompra { get; set; }
        public double ValorAtual { get; set; }
        public int Quantidade { get; set; }
        public string DataCompra { get; set; }

    }
}
