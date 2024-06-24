using FinServ.Domain.Entities.Ativos;

namespace FinServ.Domain.Repositories
{
    public interface IAtivoRepository : IRepository<Ativo>
    {
        Task<IEnumerable<ExtratoAtivos>> GetAtivos(int clienteId);
        Task<IEnumerable<Ativo>> GetProdutosExpiry(DateTime dataVencimentoProduto);
    }
}
