using MediatR;

namespace FinServ.Application.UseCases.Produtos.ObterProdutoPorCodigo
{
    public class ObterProdutoPorCodigoRequest : IRequest<IList<ObterProdutoPorCodigoResponse>>
    {
        public int CodigoProduto { get; set; }
    }
}
