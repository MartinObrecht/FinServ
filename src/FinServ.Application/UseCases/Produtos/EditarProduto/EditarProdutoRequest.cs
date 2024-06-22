using MediatR;

namespace FinServ.Application.UseCases.Produtos.EditarProduto
{
    public class EditarProdutoRequest : IRequest<EditarProdutoResponse>
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public double TaxaJurosMensal { get; set; }
        public string DataVencimento { get; set; }
        public int Quantidade { get; set; }
    }
}
