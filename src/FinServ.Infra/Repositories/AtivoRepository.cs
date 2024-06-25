using FinServ.Domain.Entities.Ativos;
using FinServ.Domain.Repositories;
using FinServ.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinServ.Infra.Repositories
{
    public class AtivoRepository : IAtivoRepository
    {
        private readonly FinServContext _context;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ILogger<AtivoRepository> _logger;

        public AtivoRepository(FinServContext context, IProdutoRepository produtoRepository, IClienteRepository clienteRepository, ILogger<AtivoRepository> logger)
        {
            _context = context;
            _produtoRepository = produtoRepository;
            _clienteRepository = clienteRepository;
            _logger = logger;
        }

        public async Task<Ativo> AddAsync(Ativo entity)
        {
            try
            {
                await Task.Run(() =>
                {
                    _context.Ativos.Add(entity);
                    _context.SaveChanges();
                });

                return await Task.FromResult(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cadastrar ativo: {Ativo}", entity);
                throw new InvalidOperationException("Erro ao cadastrar ativo.", ex);
            }
        }

        public async Task DeleteAsync(Ativo entity)
        {
            try
            {
                await Task.Run(() =>
                {
                    _context.Ativos.Remove(entity);
                    _context.SaveChanges();
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar ativo: {Ativo}", entity);
                throw new InvalidOperationException("Erro ao deletar ativo.", ex);
            }
        }

        public Task<IEnumerable<Ativo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExtratoAtivos>> GetAtivos(int clienteId)
        {
            try
            {
                var extratos = await _context.Ativos
                    .AsNoTracking()
                    .Include(a => a.Produto)
                    .Include(a => a.Cliente)
                    .Where(a => a.ClienteId == clienteId)
                    .Select(a => new ExtratoAtivos
                    {
                        NomeCliente = a.Cliente.Nome,
                        NomeProduto = a.Produto.Nome,
                        DescricaoProduto = a.Produto.Descricao,
                        DataVencimentoProduto = a.Produto.DataVencimento,
                        TaxaJurosMes = a.Produto.TaxaJurosMensal,
                        ValorCompra = a.ValorCompra,
                        DataCompra = a.DataCompra,
                        ValorAtual = a.ValorAtual,
                        Quantidade = a.Quantidade
                    })
                    .ToListAsync();

                return extratos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar extrato de ativos por cliente");
                throw new InvalidOperationException("Erro ao buscar extrato de ativos por cliente", ex);
            }
        }

        public async Task<Ativo?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Ativos.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar ativo por id: {Id}", id);
                throw new InvalidOperationException("Erro ao buscar ativo por id.", ex);
            }            
        }

        public async Task<IEnumerable<Ativo>> GetProdutosExpiry(DateTime dataVencimentoProduto)
        {
            try
            {
                return await _context.Ativos
                    .AsNoTracking()
                    .Include(a => a.Produto)
                    .Where(a => a.Produto.DataVencimento == dataVencimentoProduto)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar ativos com produtos próximos do vencimento");
                throw new InvalidOperationException("Erro ao buscar ativos com produtos próximos do vencimento", ex);
            }
        }

        public void Update(Ativo entity)
        {
            throw new NotImplementedException();
        }
    }
}

