using FluentValidation;

namespace FinServ.Application.UseCases.Produtos.CreateProdutos
{
    public class CreateProdutosRequestValidator : AbstractValidator<CreateProdutosRequest>
    {
        public CreateProdutosRequestValidator()
        {

        }
    }
}