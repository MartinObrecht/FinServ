using FinServ.Domain.Entities.Ativos;
using FinServ.Domain.Repositories;
using FinServ.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinServ.Infra.Repositories
{
    public class AtivoRepository : Repository<Ativo>, IAtivoRepository
    {
        private readonly FinServContext _context;
        private readonly ILogger<AtivoRepository> _logger;

        public AtivoRepository(FinServContext context, ILogger<AtivoRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<ExtratoAtivos>> ExtratoAtivos(string cpf)
        {
            try
            {
                var extratos = await _context.Ativos
                    .AsNoTracking()
                    .Include(a => a.Produto)
                    .Include(a => a.Cliente)
                    .Where(a => a.Cliente.Cpf == cpf)
                    .Select(a => new ExtratoAtivos
                    {
                        NomeCliente = a.Cliente.Nome,
                        SaldoCliente = a.Cliente.Saldo,
                        IdAtivo = a.Id,
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

        public async Task<IEnumerable<Ativo>> GetAtivosByClienteAsync(int clienteId)
        {
            try
            {
                return await _context.Ativos.AsNoTracking().Where(a => a.ClienteId == clienteId).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar ativos por cliente: {ClienteId}", clienteId);
                throw new InvalidOperationException("Erro ao buscar ativos por cliente.", ex);
            }
        }

        public async Task<IEnumerable<Ativo>> GetAtivosByCpfAsync(string cpf)
        {
            try
            {
                return await _context.Ativos
                    .AsNoTracking()
                    .Include(a => a.Cliente)
                    .Where(a => a.Cliente.Cpf == cpf)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar ativos por cpf: {Cpf}", cpf);
                throw new InvalidOperationException("Erro ao buscar ativos por cpf.", ex);
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
    }
}

