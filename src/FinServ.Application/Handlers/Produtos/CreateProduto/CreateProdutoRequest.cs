using MediatR;

namespace FinServ.Application.Handlers.Produtos.CreateProduto
{
    public class CreateProdutoRequest : IRequest<CreateProdutoResponse>
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public decimal TaxaJurosMensal { get; set; }
        public DateTime DataVencimento { get; set; }
        public int Quantidade { get; set; }
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; }
    }
}
