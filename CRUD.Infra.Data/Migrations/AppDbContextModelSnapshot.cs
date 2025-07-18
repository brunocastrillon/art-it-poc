﻿// <auto-generated />
using System;
using CRUD.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRUD.Infra.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.36");

            modelBuilder.Entity("CRUD.Core.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("CodigoCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInsercao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoPessoa")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("UsuarioInsercao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CodigoCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("CRUD.Core.Domain.Entities.Telefone", b =>
                {
                    b.Property<int>("CodigoCliente")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NumeroTelefone")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CodigoTipoTelefone")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataInsercao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Operadora")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("UsuarioInsercao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CodigoCliente", "NumeroTelefone");

                    b.HasIndex("CodigoTipoTelefone");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("CRUD.Core.Domain.Entities.TipoTelefone", b =>
                {
                    b.Property<int>("CodigoTipoTelefone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataInsercao")
                        .HasColumnType("TEXT");

                    b.Property<string>("DescricaoTipoTelefone")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("UsuarioInsercao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CodigoTipoTelefone");

                    b.ToTable("TiposTelefones");
                });

            modelBuilder.Entity("CRUD.Core.Domain.Entities.Telefone", b =>
                {
                    b.HasOne("CRUD.Core.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Telefones")
                        .HasForeignKey("CodigoCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CRUD.Core.Domain.Entities.TipoTelefone", "TipoTelefone")
                        .WithMany("Telefones")
                        .HasForeignKey("CodigoTipoTelefone")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("TipoTelefone");
                });

            modelBuilder.Entity("CRUD.Core.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Telefones");
                });

            modelBuilder.Entity("CRUD.Core.Domain.Entities.TipoTelefone", b =>
                {
                    b.Navigation("Telefones");
                });
#pragma warning restore 612, 618
        }
    }
}
