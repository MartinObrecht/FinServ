using FluentValidation;

namespace FinServ.Application.Handlers.Clientes.SellAtivo
{
    public class SellAtivoRequestValidator : AbstractValidator<SellAtivoRequest>
    {
        public SellAtivoRequestValidator()
        {
            RuleFor(x => x.Cpf)
                .NotEmpty()
                .WithMessage("CPF é obrigatório")
                .Matches(@"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$")
                .WithMessage("CPF deve conter apenas números");

            RuleFor(x => x.AtivoId)
                .NotNull()
                .WithMessage("IdAtivo é obrigatório");
                
        }
    }
}
