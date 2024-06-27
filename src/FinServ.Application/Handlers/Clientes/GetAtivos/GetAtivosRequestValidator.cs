using FluentValidation;

namespace FinServ.Application.Handlers.Clientes.GetAtivos
{
    public class GetAtivosRequestValidator : AbstractValidator<GetAtivosRequest>
    {
        public GetAtivosRequestValidator()
        {
            RuleFor(x => x.Cpf)
                .NotEmpty()
                .WithMessage("CPF é obrigatório")
                .Matches(@"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$")
                .WithMessage("CPF deve conter apenas números");
        }
    }
}