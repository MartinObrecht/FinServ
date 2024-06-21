namespace FinServ.Domain.Interfaces.Clientes
{
    public interface IInvestidor : IEntidadeBase
    {
        string Nome { get; set; }
        string Cpf { get; set; }

    }
}
    