using MediatR;

namespace FinServ.Application.UseCases.Produtos.ConsultarProdutoPorCodigo
{
    public class ConsultarProdutoPorCodigoRequest : IRequest<IList<ConsultarProdutoPorCodigoResponse>>
    {
        public int CodigoProduto { get; set; }
    }
}
