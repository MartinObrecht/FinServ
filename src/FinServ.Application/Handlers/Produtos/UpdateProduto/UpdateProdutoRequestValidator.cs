using FluentValidation;

namespace FinServ.Application.Handlers.Produtos.UpdateProduto
{
    public class UpdateProdutoRequestValidator : AbstractValidator<UpdateProdutoRequest>
    {
        public UpdateProdutoRequestValidator()
        {
            RuleFor(x => x.IdProduto).NotEmpty().WithMessage("IdProduto é obrigatório.");
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome é obrigatório.");
            RuleFor(x => x.Valor).NotEmpty().WithMessage("Valor é obrigatório.");
            RuleFor(x => x.CodigoProduto).NotEmpty().WithMessage("CodigoProduto é obrigatório.");
            RuleFor(x => x.TaxaJurosMensal).NotEmpty().WithMessage("TaxaJurosMensal é obrigatório.");
            RuleFor(x => x.DataVencimento).NotEmpty().WithMessage("DataVencimento é obrigatório.");
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("Descricao é obrigatório.");
            RuleFor(x => x.Quantidade).NotEmpty().WithMessage("Quantidade é obrigatório.");
        }
    }
}
