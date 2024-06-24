using FinServ.Domain.Entities.Produtos;
namespace FinServ.Domain.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task AddRangeAsync(IEnumerable<Produto?> Produtos);
        Task<Produto?> GetByCodigoAsync(int CodigoProduto);
        Task<IEnumerable<Produto>> GetAvailableAsync();
    }
}
