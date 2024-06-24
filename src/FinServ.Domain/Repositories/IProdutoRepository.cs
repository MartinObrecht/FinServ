using FinServ.Domain.Entities.Produtos;
namespace FinServ.Domain.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Produto?> GetByIdAsync(int id);
        Task<IEnumerable<Produto>> GetAllAsync();
        Task<Produto> AddAsync(Produto Produto);
        Task AddRangeAsync(IEnumerable<Produto?> Produtos);
        Task<IEnumerable<Produto?>> GetByCodigoAsync(int CodigoProduto);
        Task<IEnumerable<Produto>> GetAvailableAsync();
        Task UpdateAsync(Produto Produto);
        Task DeleteAsync(Produto Produto);
    }
}
