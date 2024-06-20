using FinServ.Domain.Entities.Enums;

namespace FinServ.Domain.Interfaces.ProdutosFinanceiros
{
    public interface ICdb : IProdutoFinanceiro
    {
        ETipoCdb TipoCdb { get; set; }

    }
}
