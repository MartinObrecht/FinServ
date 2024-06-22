using FluentValidation;

namespace FinServ.Application.UseCases.Clientes.CreateCliente
{
    public class CreateClienteRequestValidator : AbstractValidator<CreateClienteRequest>
    {
        public CreateClienteRequestValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório");

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .WithMessage("CPF é obrigatório")
                .Matches(@"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$")
                .WithMessage("CPF inválido");
        }
    }
}
