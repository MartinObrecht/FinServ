using FinServ.Domain.Entities.Ativos;

namespace FinServ.Domain.Interfaces
{
    public interface IProduto : IEntidadeBase
    {
        string Nome { get; set; }
        string Descricao { get; set; }
        double Valor { get; set; }
        int CodigoProduto { get; set; }
        double TaxaJurosMensal { get; set; }
        DateTime DataVencimento { get; set; }
        int Quantidade { get; set; }
        ICollection<Ativo> Ativos { get; set; }
    }
}
