using FluentValidation;

namespace FinServ.Application.UseCases.Investidores.CadastrarInvestidor
{
    public class CadastrarInvestidorValidator : AbstractValidator<CadastrarInvestidorRequest>
    {
        public CadastrarInvestidorValidator()
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
