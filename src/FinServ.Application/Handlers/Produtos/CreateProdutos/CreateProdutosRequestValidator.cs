using FinServ.Application.Handlers.Produtos.CreateProdutos;
using FluentValidation;
using System;

namespace FinServ.Application.Handlers.Produtos.CreateProduto
{
    public class CreateProdutosRequestValidator : AbstractValidator<CreateProdutosRequest>
    {
        public CreateProdutosRequestValidator()
        {
            RuleForEach(x => x.Produtos).ChildRules(produto =>
            {
                produto.RuleFor(p => p.Nome)
                    .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                    .Length(2, 100).WithMessage("O nome do produto deve ter entre 2 e 100 caracteres.");

                produto.RuleFor(p => p.Valor)
                    .GreaterThan(0).WithMessage("O valor do produto deve ser maior que 0.");

                produto.RuleFor(p => p.TaxaJurosMensal)
                    .InclusiveBetween(0, 100).WithMessage("A taxa de juros mensal deve estar entre 0 e 100.");

                produto.RuleFor(p => p.DataVencimento)
                    .NotNull().WithMessage("A data de vencimento é obrigatória.");

                produto.RuleFor(p => p.Quantidade)
                    .GreaterThan(0).WithMessage("A quantidade deve ser maior que 0.");

                produto.RuleFor(p => p.CodigoProduto)
                    .GreaterThan(0).WithMessage("O código do produto deve ser maior que 0.");

                produto.RuleFor(p => p.Descricao)
                    .NotEmpty().WithMessage("A descrição é obrigatória.")
                    .MaximumLength(500).WithMessage("A descrição não pode exceder 500 caracteres.");
            });
        }
    }
}