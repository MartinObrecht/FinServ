using FluentValidation;

namespace FinServ.Application.Handlers.Clientes.BuyAtivo
{
    public class BuyAtivoRequestValidator : AbstractValidator<BuyAtivoRequest>
    {
        public BuyAtivoRequestValidator()
        {
            RuleFor(x => x.Cpf)
                .NotEmpty()
                .WithMessage("CPF é obrigatório")
                .Matches(@"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$")
                .WithMessage("CPF deve conter apenas números");

            RuleFor(x => x.IdProduto)
                .NotEmpty()
                .WithMessage("IProduto é obrigatório");

            RuleFor(x => x.Quantidade)
                .NotEmpty()
                .WithMessage("Quantidade é obrigatório");
        }
    }
}
