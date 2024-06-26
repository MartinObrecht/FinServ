using FluentValidation;

namespace FinServ.Application.Handlers.Clientes.CreateCliente
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

            RuleFor(x => x.Saldo)
                .NotEmpty()
                .WithMessage("Saldo é obrigatório")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Saldo deve ser maior ou igual a zero")
                .ScalePrecision(2, 10)
                .WithMessage("Saldo deve ter no máximo 2 casas decimais e 10 dígitos");
        }
    }
}
