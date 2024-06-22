using FinServ.Domain.Entities.Produtos;
namespace FinServ.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto?> GetByIdAsync(int id);
        Task<IEnumerable<Produto>> GetAllAsync();
        Task RegisterAsync(Produto Produto);
        Task RegisterInBatchAsync(IEnumerable<Produto?> Produtos);
        Task<IEnumerable<Produto?>> GetByCodigoAsync(int CodigoProduto);
        Task<IEnumerable<Produto>> GetAvailableAsync();
        Task UpdateAsync(Produto Produto);
        Task DeleteAsync(Produto Produto);
    }
}
