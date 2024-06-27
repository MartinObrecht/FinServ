using FinServ.Domain.Entities.Ativos;
using FinServ.Domain.Entities.Clientes;
using FinServ.Domain.Entities.Produtos;
using FinServ.Domain.Repositories;
using FinServ.Infra.Database.Context;

namespace FinServ.Infra;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly FinServContext _context;

    public IClienteRepository Clientes { get; }

    public IAtivoRepository Ativos { get; }

    public IProdutoRepository Produtos { get; }
    public UnitOfWork(FinServContext context, IClienteRepository clientes, IAtivoRepository ativos, IProdutoRepository produtos)
    {
        _context = context;
        Clientes = clientes;
        Ativos = ativos;
        Produtos = produtos;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
