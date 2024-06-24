using FinServ.Domain.Entities.Ativos;
using FinServ.Domain.Repositories;
using FinServ.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinServ.Infra.Repositories
{
    public class AtivoRepository : IAtivoRepository
    {
        private readonly FinServContext _dbContext;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ILogger<AtivoRepository> _logger;

        public AtivoRepository(FinServContext dbContext, IProdutoRepository produtoRepository, IClienteRepository clienteRepository, ILogger<AtivoRepository> logger)
        {
            _dbContext = dbContext;
            _produtoRepository = produtoRepository;
            _clienteRepository = clienteRepository;
            _logger = logger;
        }

        public Task<Ativo> AddAsync(Ativo entity)
        {
            throw new NotImplementedException();
        }

        public Task<Ativo> CreateAtivoAsync(Ativo ativo)
        {
            throw new NotImplementedException();
        }

        public Task<Ativo> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Ativo entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ativo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExtratoAtivos>> CreateAsync(int clienteId)
        {
            try
            {
                var extratos = await _dbContext.Ativos
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

        public Task<Ativo> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Ativo> UpdateAsync(Ativo ativo)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Ativo>.UpdateAsync(Ativo entity)
        {
            throw new NotImplementedException();
        }
    }
}

