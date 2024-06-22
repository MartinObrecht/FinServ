using MediatR;

namespace FinServ.Application.UseCases.Produtos.CreateProduto
{
    public class CreateProdutoRequest : IRequest<CreateProdutoResponse>
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public double TaxaJurosMensal { get; set; }
        public DateTime DataVencimento { get; set; }
        public int Quantidade { get; set; }
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; }
    }
}
