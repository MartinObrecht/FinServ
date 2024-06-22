using FinServ.Domain.Entities.Produtos;
using FinServ.Domain.Repositories;
using FinServ.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinServ.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly FinServContext _context;
        private readonly ILogger<IClienteRepository> _logger;

        public ProdutoRepository(FinServContext context, ILogger<IClienteRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task RegisterAsync(Produto produto)
        {
            try
            {
                await _context.Produtos.AddAsync(produto);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cadastrar produto financeiro: {Produto}", produto);
                throw new InvalidOperationException("Erro ao cadastrar produto financeiro.", ex);
            }
        }

        public async Task RegisterInBatchAsync(IEnumerable<Produto?> produtos)
        {
            try
            {
                await _context.Produtos.AddRangeAsync(produtos);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cadastrar produtos financeiros: {Produtos}", produtos);
                throw new InvalidOperationException("Erro ao cadastrar produtos financeiros.", ex);
            }
        }

        public async Task<IEnumerable<Produto>> GetByCodigoAsync(int codigoProduto)
        {
            try
            {
                var Produtos = await _context.Produtos
                    .Where(pf => pf.CodigoProduto == codigoProduto)
                    .AsNoTracking()
                    .ToListAsync();

                return Produtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter produtos financeiros pelo código do tipo financeiro: {CodigoTipoFinanceiro}", codigoProduto);
                throw new InvalidOperationException($"Erro ao obter produtos financeiros pelo código do tipo financeiro: {codigoProduto}.", ex);
            }
        }


        public async Task<Produto?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Produtos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(pf => pf.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter produto financeiro por ID: {Id}", id);
                throw new InvalidOperationException("Erro ao obter produto financeiro por ID.", ex);
            }
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            try
            {
                return await _context.Produtos.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todos os produtos financeiros.");
                throw new InvalidOperationException("Erro ao obter todos os produtos financeiros.", ex);
            }
        }

        public async Task<IEnumerable<Produto>> GetAvailableAsync()
        {
            try
            {
                return await _context.Produtos
                    .Where(pf => pf.Quantidade > 0)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter produtos financeiros disponíveis.");
                throw new InvalidOperationException("Erro ao obter produtos financeiros disponíveis.", ex);
            }
        }

        public async Task UpdateAsync(Produto produto)
        {
            try
            {
                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar produto financeiro: {Produto}", produto);
                throw new InvalidOperationException("Erro ao atualizar produto financeiro.", ex);
            }
        }

        public async Task DeleteAsync(Produto produto)
        {
            try
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao remover produto financeiro: {Produto}", produto);
                throw new InvalidOperationException("Erro ao remover produto financeiro.", ex);
            }
        }
    }
}
