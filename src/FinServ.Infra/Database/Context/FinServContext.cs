using FinServ.Domain.Entities.Admin;
using FinServ.Domain.Entities.Ativos;
using FinServ.Domain.Entities.Clientes;
using FinServ.Domain.Entities.Produtos;
using Microsoft.EntityFrameworkCore;

namespace FinServ.Infra.Database.Context
{
    public class FinServContext : DbContext
    {
        public FinServContext(DbContextOptions<FinServContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Ativo> Ativos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Admin> Administradores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Clientes").HasAlternateKey(a => a.Cpf);
            modelBuilder.Entity<Produto>().ToTable("Produtos").HasIndex(i => i.CodigoProduto).IsUnique();
            modelBuilder.Entity<Ativo>().ToTable("Ativos");

            modelBuilder.Entity<Admin>().ToTable("Administradores").HasKey(k => k.Email);
            modelBuilder.Entity<Admin>().ToTable("Administradores").HasIndex(a => new { a.Email, a.CodigoAcesso }).IsUnique();
        }
    }
}