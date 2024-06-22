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
    [Migration("20240622133859_ajuste_nome_coluna_taxa_juros")]
    partial class ajuste_nome_coluna_taxa_juros
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

            modelBuilder.Entity("FinServ.Domain.Entities.Contas.Carteira", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AtivoId")
                        .HasColumnType("int");

                    b.Property<int>("ContaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContaId")
                        .IsUnique();

                    b.ToTable("Carteiras", (string)null);
                });

            modelBuilder.Entity("FinServ.Domain.Entities.Contas.Conta", b =>
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
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("InvestidorId");

                    b.ToTable("Contas", (string)null);
                });

            modelBuilder.Entity("FinServ.Domain.Entities.Produtos.Ativo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarteiraId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<double>("ValorCompra")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CarteiraId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Ativos", (string)null);
                });

            modelBuilder.Entity("FinServ.Domain.Entities.Produtos.Produto", b =>
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

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<double>("TaxaJurosMensal")
                        .HasColumnType("float");

                    b.Property<int>("TipoProdutoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoProdutoId");

                    b.ToTable("Produtos", (string)null);
                });

            modelBuilder.Entity("FinServ.Domain.Entities.Produtos.TipoProduto", b =>
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

                    b.ToTable("TiposProduto", (string)null);
                });

            modelBuilder.Entity("FinServ.Domain.Entities.Contas.Carteira", b =>
                {
                    b.HasOne("FinServ.Domain.Entities.Contas.Conta", "Conta")
                        .WithOne("Carteira")
                        .HasForeignKey("FinServ.Domain.Entities.Contas.Carteira", "ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("FinServ.Domain.Entities.Contas.Conta", b =>
                {
                    b.HasOne("FinServ.Domain.Entities.Clientes.Investidor", "Investidor")
                        .WithMany()
                        .HasForeignKey("InvestidorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Investidor");
                });

            modelBuilder.Entity("FinServ.Domain.Entities.Produtos.Ativo", b =>
                {
                    b.HasOne("FinServ.Domain.Entities.Contas.Carteira", null)
                        .WithMany("Ativos")
                        .HasForeignKey("CarteiraId");

                    b.HasOne("FinServ.Domain.Entities.Produtos.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("FinServ.Domain.Entities.Produtos.Produto", b =>
                {
                    b.HasOne("FinServ.Domain.Entities.Produtos.TipoProduto", "TipoProduto")
                        .WithMany("Produtos")
                        .HasForeignKey("TipoProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoProduto");
                });

            modelBuilder.Entity("FinServ.Domain.Entities.Contas.Carteira", b =>
                {
                    b.Navigation("Ativos");
                });

            modelBuilder.Entity("FinServ.Domain.Entities.Contas.Conta", b =>
                {
                    b.Navigation("Carteira")
                        .IsRequired();
                });

            modelBuilder.Entity("FinServ.Domain.Entities.Produtos.TipoProduto", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
