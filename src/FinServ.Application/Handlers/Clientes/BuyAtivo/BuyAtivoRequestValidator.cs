using FluentValidation;

namespace FinServ.Application.Handlers.Clientes.BuyAtivo
{
    public class BuyAtivoRequestValidator : AbstractValidator<BuyAtivoRequest>
    {
        public BuyAtivoRequestValidator()
        {
            RuleFor(x => x.IdCliente)
                .NotEmpty()
                .WithMessage("IdCliente é obrigatório");

            RuleFor(x => x.CodigoProduto)
                .NotEmpty()
                .WithMessage("CodigoProduto é obrigatório");

            RuleFor(x => x.Quantidade)
                .NotEmpty()
                .WithMessage("Quantidade é obrigatório");
        }
    }
}
