﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230601222445_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("SolicitacaoSequence");

            modelBuilder.HasSequence("UserSequence");

            modelBuilder.Entity("Core.Entities.Abstract.Solicitacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [SolicitacaoSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroProtocolo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SecretariaDestinoId")
                        .HasColumnType("int");

                    b.Property<int>("StatusSolicitacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SecretariaDestinoId");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("Core.Entities.Abstract.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [UserSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("Core.Entities.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Hierarquia")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Salario")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("Core.Entities.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Core.Entities.Familia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("Familias");
                });

            modelBuilder.Entity("Core.Entities.Reclamacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Autor")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Destino")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reclamacoes");
                });

            modelBuilder.Entity("Core.Entities.Secretaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("Secretarias");
                });

            modelBuilder.Entity("Core.Entities.CestaBasica", b =>
                {
                    b.HasBaseType("Core.Entities.Abstract.Solicitacao");

                    b.Property<int?>("AtendidoPorId")
                        .HasColumnType("int");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int>("FamiliaId")
                        .HasColumnType("int");

                    b.Property<string>("SituacaoDescricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SolicitadoPorId")
                        .HasColumnType("int");

                    b.HasIndex("AtendidoPorId");

                    b.HasIndex("EnderecoId")
                        .IsUnique()
                        .HasFilter("[EnderecoId] IS NOT NULL");

                    b.HasIndex("FamiliaId");

                    b.HasIndex("SolicitadoPorId");

                    b.ToTable("CestaBasicas");
                });

            modelBuilder.Entity("Core.Entities.Chamado", b =>
                {
                    b.HasBaseType("Core.Entities.Abstract.Solicitacao");

                    b.Property<int>("AtendenteId")
                        .HasColumnType("int");

                    b.Property<int>("SolicitanteId")
                        .HasColumnType("int");

                    b.Property<int>("StatusAtendimento")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("AtendenteId")
                        .IsUnique()
                        .HasFilter("[AtendenteId] IS NOT NULL");

                    b.HasIndex("SolicitanteId")
                        .IsUnique()
                        .HasFilter("[SolicitanteId] IS NOT NULL");

                    b.ToTable("Chamados");
                });

            modelBuilder.Entity("Core.Entities.Cidadao", b =>
                {
                    b.HasBaseType("Core.Entities.Abstract.User");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int?>("FamiliaId")
                        .HasColumnType("int");

                    b.Property<string>("PISPASEP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("EnderecoId")
                        .IsUnique()
                        .HasFilter("[EnderecoId] IS NOT NULL");

                    b.HasIndex("FamiliaId");

                    b.ToTable("Cidadoes");
                });

            modelBuilder.Entity("Core.Entities.Servidor", b =>
                {
                    b.HasBaseType("Core.Entities.Abstract.User");

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SecretariaId")
                        .HasColumnType("int");

                    b.HasIndex("CargoId")
                        .IsUnique()
                        .HasFilter("[CargoId] IS NOT NULL");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("SecretariaId");

                    b.ToTable("Servidores");
                });

            modelBuilder.Entity("Core.Entities.Abstract.Solicitacao", b =>
                {
                    b.HasOne("Core.Entities.Secretaria", "SecretariaDestino")
                        .WithMany("Solicitacoes")
                        .HasForeignKey("SecretariaDestinoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SecretariaDestino");
                });

            modelBuilder.Entity("Core.Entities.Familia", b =>
                {
                    b.HasOne("Core.Entities.Endereco", "Endereco")
                        .WithOne()
                        .HasForeignKey("Core.Entities.Familia", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Core.Entities.Secretaria", b =>
                {
                    b.HasOne("Core.Entities.Endereco", "Endereco")
                        .WithOne()
                        .HasForeignKey("Core.Entities.Secretaria", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Core.Entities.CestaBasica", b =>
                {
                    b.HasOne("Core.Entities.Servidor", "AtendidoPor")
                        .WithMany()
                        .HasForeignKey("AtendidoPorId");

                    b.HasOne("Core.Entities.Endereco", "Endereco")
                        .WithOne()
                        .HasForeignKey("Core.Entities.CestaBasica", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Familia", "Familia")
                        .WithMany("Cestas")
                        .HasForeignKey("FamiliaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Entities.Abstract.User", "SolicitadoPor")
                        .WithMany()
                        .HasForeignKey("SolicitadoPorId");

                    b.Navigation("AtendidoPor");

                    b.Navigation("Endereco");

                    b.Navigation("Familia");

                    b.Navigation("SolicitadoPor");
                });

            modelBuilder.Entity("Core.Entities.Chamado", b =>
                {
                    b.HasOne("Core.Entities.Servidor", "AtendidoPor")
                        .WithOne()
                        .HasForeignKey("Core.Entities.Chamado", "AtendenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Abstract.User", "SolicitadoPor")
                        .WithOne()
                        .HasForeignKey("Core.Entities.Chamado", "SolicitanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AtendidoPor");

                    b.Navigation("SolicitadoPor");
                });

            modelBuilder.Entity("Core.Entities.Cidadao", b =>
                {
                    b.HasOne("Core.Entities.Endereco", "Endereco")
                        .WithOne()
                        .HasForeignKey("Core.Entities.Cidadao", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Familia", null)
                        .WithMany("Membros")
                        .HasForeignKey("FamiliaId");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Core.Entities.Servidor", b =>
                {
                    b.HasOne("Core.Entities.Cargo", "Cargo")
                        .WithOne()
                        .HasForeignKey("Core.Entities.Servidor", "CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Secretaria", "Secretaria")
                        .WithMany("Servidores")
                        .HasForeignKey("SecretariaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("Endereco");

                    b.Navigation("Secretaria");
                });

            modelBuilder.Entity("Core.Entities.Familia", b =>
                {
                    b.Navigation("Cestas");

                    b.Navigation("Membros");
                });

            modelBuilder.Entity("Core.Entities.Secretaria", b =>
                {
                    b.Navigation("Servidores");

                    b.Navigation("Solicitacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
