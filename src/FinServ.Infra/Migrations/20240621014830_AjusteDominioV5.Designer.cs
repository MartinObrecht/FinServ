﻿// <auto-generated />
using System;
using FinServ.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinServ.Infra.Migrations
{
    [DbContext(typeof(FinServContext))]
    [Migration("20240621014830_AjusteDominioV5")]
    partial class AjusteDominioV5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinServ.Domain.Entities.Clientes.Investidor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Investidores", (string)null);
                });

            modelBuilder.Entity("FinServ.Domain.Entities.Contas.CarteiraInvestimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AtivoFinanceiroId")
                        .HasColumnType("int");

                    b.Property<int>("ContaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContaId")
                        .IsUnique();

                    b.ToTable("CarteirasInvestimento", (string)null);
                });

            modelBuilder.Entity("FinServ.Domain.Entities.Contas.ContaInvestimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InvestidorId")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<double>("Saldo")
                        .HasColumnType("double(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("InvestidorId");

                    b.ToTable("ContasInvestimento", (string)null);
                });

            modelBuilder.Entity("FinServ.Domain.Entities.ProdutosFinanceiros.Ativo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarteiraInvestimentoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdutoFinanceiroId")
                        .HasColumnType("int");

                    b.Property<double>("ValorCompra")
                        .HasColumnType("double(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarteiraInvestimentoId");

                    b.HasIndex("ProdutoFinanceiroId");

                    b.ToTable("AtivosFinanceiros", (string)null);
                });

            modelBuilder.Entity("FinServ.Domain.Entities.ProdutosFinanceiros.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TaxaJurosMes")
                        .HasColumnType("double(18,2)");

                    b.Property<int>("TipoProdutoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoProdutoId");

                    b.ToTable("ProdutosFinanceiros", (string)null);
                });

            modelBuilder.Entity("FinServ.Domain.Entities.ProdutosFinanceiros.TipoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CodigoProduto")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CodigoProduto")
                        .IsUnique();

                    b.ToTable("TiposProdutoFinanceiro", (string)null);
                });

            modelBuilder.Entity("FinServ.Domain.Entities.Contas.CarteiraInvestimento", b =>
                {
                    b.HasOne("FinServ.Domain.Entities.Contas.ContaInvestimento", "Conta")
                        .WithOne("CarteiraInvestimento")
                        .HasForeignKey("FinServ.Domain.Entities.Contas.CarteiraInvestimento", "ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("FinServ.Domain.Entities.Contas.ContaInvestimento", b =>
                {
                    b.HasOne("FinServ.Domain.Entities.Clientes.Investidor", "Investidor")
                        .WithMany()
                        .HasForeignKey("InvestidorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Investidor");
                });

            modelBuilder.Entity("FinServ.Domain.Entities.ProdutosFinanceiros.Ativo", b =>
                {
                    b.HasOne("FinServ.Domain.Entities.Contas.CarteiraInvestimento", null)
                        .WithMany("AtivosFinanceiros")
                        .HasForeignKey("CarteiraInvestimentoId");

                    b.HasOne("FinServ.Domain.Entities.ProdutosFinanceiros.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoFinanceiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("FinServ.Domain.Entities.ProdutosFinanceiros.Produto", b =>
                {
                    b.HasOne("FinServ.Domain.Entities.ProdutosFinanceiros.TipoProduto", "TipoProduto")
                        .WithMany()
                        .HasForeignKey("TipoProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoProduto");
                });

            modelBuilder.Entity("FinServ.Domain.Entities.Contas.CarteiraInvestimento", b =>
                {
                    b.Navigation("AtivosFinanceiros");
                });

            modelBuilder.Entity("FinServ.Domain.Entities.Contas.ContaInvestimento", b =>
                {
                    b.Navigation("CarteiraInvestimento")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
