﻿// <auto-generated />
using System;
using Fiap.Api.AspNet5.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fiap.Api.AspNet5.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230602001026_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fiap.Api.AspNet5.Models.CategoriaModel", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"));

                    b.Property<string>("NomeCategoria")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            CategoriaId = 1,
                            NomeCategoria = "TV"
                        },
                        new
                        {
                            CategoriaId = 2,
                            NomeCategoria = "Smartphone"
                        },
                        new
                        {
                            CategoriaId = 3,
                            NomeCategoria = "PC"
                        },
                        new
                        {
                            CategoriaId = 4,
                            NomeCategoria = "Notebook"
                        });
                });

            modelBuilder.Entity("Fiap.Api.AspNet5.Models.MarcaModel", b =>
                {
                    b.Property<int>("MarcaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarcaId"));

                    b.Property<string>("NomeMarca")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("MarcaId");

                    b.ToTable("Marcas");

                    b.HasData(
                        new
                        {
                            MarcaId = 1,
                            NomeMarca = "LG"
                        },
                        new
                        {
                            MarcaId = 2,
                            NomeMarca = "Apple"
                        },
                        new
                        {
                            MarcaId = 3,
                            NomeMarca = "Samsung"
                        },
                        new
                        {
                            MarcaId = 4,
                            NomeMarca = "Motorola"
                        });
                });

            modelBuilder.Entity("Fiap.Api.AspNet5.Models.ProdutoModel", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoId"));

                    b.Property<string>("Caracteristicas")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ProdutoId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("MarcaId");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            ProdutoId = 1,
                            Caracteristicas = "",
                            CategoriaId = 2,
                            DataLancamento = new DateTime(2023, 6, 1, 21, 10, 26, 593, DateTimeKind.Local).AddTicks(1710),
                            Descricao = "Apple iPhone 12",
                            MarcaId = 2,
                            Nome = "iPhone 12 mini",
                            Preco = 5000m,
                            Sku = "SKUIPH12"
                        },
                        new
                        {
                            ProdutoId = 2,
                            Caracteristicas = "",
                            CategoriaId = 2,
                            DataLancamento = new DateTime(2023, 6, 1, 21, 10, 26, 593, DateTimeKind.Local).AddTicks(1737),
                            Descricao = "Apple iPhone 11",
                            MarcaId = 2,
                            Nome = "iPhone 11",
                            Preco = 11000m,
                            Sku = "SKUIPH11"
                        },
                        new
                        {
                            ProdutoId = 3,
                            Caracteristicas = "",
                            CategoriaId = 2,
                            DataLancamento = new DateTime(2023, 6, 1, 21, 10, 26, 593, DateTimeKind.Local).AddTicks(1738),
                            Descricao = "Apple iPhone 12",
                            MarcaId = 2,
                            Nome = "iPhone 12",
                            Preco = 12000m,
                            Sku = "SKUIPH12"
                        },
                        new
                        {
                            ProdutoId = 4,
                            Caracteristicas = "",
                            CategoriaId = 2,
                            DataLancamento = new DateTime(2023, 6, 1, 21, 10, 26, 593, DateTimeKind.Local).AddTicks(1739),
                            Descricao = "Apple iPhone 13",
                            MarcaId = 2,
                            Nome = "iPhone 13",
                            Preco = 13000m,
                            Sku = "SKUIPH13"
                        });
                });

            modelBuilder.Entity("Fiap.Api.AspNet5.Models.UsuarioModel", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Regra")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            UsuarioId = 1,
                            NomeUsuario = "Admin Senior",
                            Regra = "Senior",
                            Senha = "123456"
                        },
                        new
                        {
                            UsuarioId = 2,
                            NomeUsuario = "Admin Pleno",
                            Regra = "Pleno",
                            Senha = "123456"
                        },
                        new
                        {
                            UsuarioId = 3,
                            NomeUsuario = "Admin Junior",
                            Regra = "Junior",
                            Senha = "123456"
                        });
                });

            modelBuilder.Entity("Fiap.Api.AspNet5.Models.ProdutoModel", b =>
                {
                    b.HasOne("Fiap.Api.AspNet5.Models.CategoriaModel", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fiap.Api.AspNet5.Models.MarcaModel", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Marca");
                });
#pragma warning restore 612, 618
        }
    }
}
