using MediatR;

namespace FinServ.Application.UseCases.Produtos.ConsultarProdutosDisponiveis
{
    public class ConsultaProdutosDisponiveisRequest : IRequest<IList<ConsultarProdutosDisponiveisResponse>>
    {
    }
}
