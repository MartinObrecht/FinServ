using FinServ.Domain.Entities.Clientes;
using FinServ.Domain.Entities.Contas;
using FinServ.Domain.Entities.Produtos;
using Microsoft.EntityFrameworkCore;

namespace FinServ.Infra.Database.Context
{
    public class FinServContext : DbContext
    {
        public FinServContext(DbContextOptions<FinServContext> options) : base(options)
        {
        }

        public DbSet<Investidor> Investidores { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoProduto> TiposProduto { get; set; }
        public DbSet<Ativo> Ativos { get; set; }
        public DbSet<Carteira> Carteiras { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Investidor>().ToTable("Investidores");
            modelBuilder.Entity<Conta>().ToTable("Contas");
            modelBuilder.Entity<Produto>().ToTable("Produtos");
            modelBuilder.Entity<TipoProduto>().ToTable("TiposProduto").HasIndex(i => i.CodigoProduto).IsUnique();
            modelBuilder.Entity<Ativo>().ToTable("Ativos");
            modelBuilder.Entity<Carteira>().ToTable("Carteiras");
        }
    }
}