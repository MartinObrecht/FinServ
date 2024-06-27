using FinServ.Domain.Entities.Ativos;
using FinServ.Domain.Entities.Clientes;
using FinServ.Domain.Entities.Produtos;

namespace FinServ.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IClienteRepository Clientes { get; }
        IAtivoRepository Ativos { get; }
        IProdutoRepository Produtos { get; }

        void Commit();
    }
}
