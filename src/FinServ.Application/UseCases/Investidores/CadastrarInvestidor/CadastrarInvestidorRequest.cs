using MediatR;

namespace FinServ.Application.UseCases.Investidores.CadastrarInvestidor
{
    public class CadastrarInvestidorRequest : IRequest<CadastrarInvestidorResponse>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}
