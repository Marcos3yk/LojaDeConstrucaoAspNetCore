﻿// <auto-generated />
using LojaDeConstrucao.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace LojaDeConstrucao.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180222013938_AddVenda")]
    partial class AddVenda
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LojaDeConstrucao.Domain.Produtos.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("LojaDeConstrucao.Domain.Produtos.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoriaId");

                    b.Property<string>("Nome");

                    b.Property<decimal>("Preco");

                    b.Property<int>("QtdeEstoque");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("LojaDeConstrucao.Domain.Vendas.ItemVenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Preco");

                    b.Property<int?>("ProdutoId");

                    b.Property<int>("Quantidade");

                    b.Property<decimal>("Total");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItemVenda");
                });

            modelBuilder.Entity("LojaDeConstrucao.Domain.Vendas.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CriadoEm");

                    b.Property<int?>("ItemId");

                    b.Property<string>("NomeCliente");

                    b.Property<decimal>("Total");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("LojaDeConstrucao.Domain.Produtos.Produto", b =>
                {
                    b.HasOne("LojaDeConstrucao.Domain.Produtos.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId");
                });

            modelBuilder.Entity("LojaDeConstrucao.Domain.Vendas.ItemVenda", b =>
                {
                    b.HasOne("LojaDeConstrucao.Domain.Produtos.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("LojaDeConstrucao.Domain.Vendas.Venda", b =>
                {
                    b.HasOne("LojaDeConstrucao.Domain.Vendas.ItemVenda", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");
                });
#pragma warning restore 612, 618
        }
    }
}
