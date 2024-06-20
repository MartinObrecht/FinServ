﻿using FinServ.Domain.Entities;
using FinServ.Domain.Entities.Clientes;
using FinServ.Domain.Entities.Contas;
using FinServ.Domain.Entities.ProdutosFinanceiros;
using Microsoft.EntityFrameworkCore;

namespace FinServ.Infra.Database.Context
{
    public class FinServContext : DbContext
    {
        public FinServContext(DbContextOptions<FinServContext> options) : base(options)
        {
        }

        public DbSet<Investidor> Investidores { get; set; }
        public DbSet<ContaInvestimento> ContasInvestimento { get; set; }
        public DbSet<ProdutoFinanceiro> ProdutosFinanceiros { get; set; }
        public DbSet<TipoProdutoFinanceiro> TiposProdutoFinanceiro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Investidor>().ToTable("Investidores");
            modelBuilder.Entity<ContaInvestimento>().ToTable("ContasInvestimento");
            modelBuilder.Entity<ProdutoFinanceiro>().ToTable("ProdutosFinanceiros");
            modelBuilder.Entity<TipoProdutoFinanceiro>().ToTable("TiposProdutoFinanceiro");
        }
    }
}