using FinServ.Domain.Entities.Ativos;

namespace FinServ.Domain.Interfaces.Entities
{
    public interface IProduto : IEntidadeBase
    {
        string Nome { get; set; }
        string Descricao { get; set; }
        decimal Valor { get; set; }
        int CodigoProduto { get; set; }
        decimal TaxaJurosMensal { get; set; }
        DateTime DataVencimento { get; set; }
        int Quantidade { get; set; }
        ICollection<Ativo> Ativos { get; set; }
    }
}
