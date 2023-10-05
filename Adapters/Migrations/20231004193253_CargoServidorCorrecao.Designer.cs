﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231004193253_CargoServidorCorrecao")]
    partial class CargoServidorCorrecao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.DTOCargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Hierarquia")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Salario")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("Core.Entities.DTOCestaBasica", b =>
                {
                    b.Property<int>("SolcitacaoID")
                        .HasColumnType("integer");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("integer");

                    b.Property<int>("FamiliaId")
                        .HasColumnType("integer");

                    b.HasKey("SolcitacaoID");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.HasIndex("FamiliaId");

                    b.ToTable("CestaBasicas");
                });

            modelBuilder.Entity("Core.Entities.DTOChamado", b =>
                {
                    b.Property<int>("SolicitacaoId")
                        .HasColumnType("integer");

                    b.Property<int>("StatusAtendimento")
                        .HasColumnType("integer");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SolicitacaoId");

                    b.ToTable("Chamados");
                });

            modelBuilder.Entity("Core.Entities.DTOCidadao", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int?>("FamiliaId")
                        .HasColumnType("integer");

                    b.Property<string>("PISPASEP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasIndex("FamiliaId");

                    b.ToTable("Cidadoes");
                });

            modelBuilder.Entity("Core.Entities.DTOEndereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Core.Entities.DTOFamilia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EnderecoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("Familias");
                });

            modelBuilder.Entity("Core.Entities.DTOReclamacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AutorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DestinoId")
                        .HasColumnType("integer");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AutorId")
                        .IsUnique();

                    b.HasIndex("DestinoId")
                        .IsUnique();

                    b.ToTable("Reclamacoes");
                });

            modelBuilder.Entity("Core.Entities.DTOSecretaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CNPJ")
                        .HasColumnType("text");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("Secretarias");
                });

            modelBuilder.Entity("Core.Entities.DTOServidor", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("CargoId")
                        .HasColumnType("integer");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SecretariaId")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.HasIndex("CargoId");

                    b.HasIndex("SecretariaId");

                    b.ToTable("Servidores");
                });

            modelBuilder.Entity("Infrastructure.DataBaseModels.Entities.DTOSolicitacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AtendidoPorId")
                        .HasColumnType("integer");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Fim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NumeroProtocolo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SecretariaId")
                        .HasColumnType("integer");

                    b.Property<int>("SolicitadoPorId")
                        .HasColumnType("integer");

                    b.Property<int>("StatusSolicitacao")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AtendidoPorId")
                        .IsUnique();

                    b.HasIndex("SecretariaId");

                    b.HasIndex("SolicitadoPorId");

                    b.ToTable("Solicitacoes");
                });

            modelBuilder.Entity("Infrastructure.DataBaseModels.Entities.DTOUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Entities.DTOCestaBasica", b =>
                {
                    b.HasOne("Core.Entities.DTOEndereco", "Endereco")
                        .WithOne()
                        .HasForeignKey("Core.Entities.DTOCestaBasica", "EnderecoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Entities.DTOFamilia", "Familia")
                        .WithMany("Cestas")
                        .HasForeignKey("FamiliaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Infrastructure.DataBaseModels.Entities.DTOSolicitacao", "Solicitacao")
                        .WithOne()
                        .HasForeignKey("Core.Entities.DTOCestaBasica", "SolcitacaoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Familia");

                    b.Navigation("Solicitacao");
                });

            modelBuilder.Entity("Core.Entities.DTOChamado", b =>
                {
                    b.HasOne("Infrastructure.DataBaseModels.Entities.DTOSolicitacao", "Solicitacao")
                        .WithOne()
                        .HasForeignKey("Core.Entities.DTOChamado", "SolicitacaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Solicitacao");
                });

            modelBuilder.Entity("Core.Entities.DTOCidadao", b =>
                {
                    b.HasOne("Core.Entities.DTOFamilia", "Familia")
                        .WithMany("Membros")
                        .HasForeignKey("FamiliaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Infrastructure.DataBaseModels.Entities.DTOUser", "User")
                        .WithOne()
                        .HasForeignKey("Core.Entities.DTOCidadao", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Familia");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.DTOFamilia", b =>
                {
                    b.HasOne("Core.Entities.DTOEndereco", "Endereco")
                        .WithOne()
                        .HasForeignKey("Core.Entities.DTOFamilia", "EnderecoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Core.Entities.DTOReclamacao", b =>
                {
                    b.HasOne("Core.Entities.DTOCidadao", "Autor")
                        .WithOne()
                        .HasForeignKey("Core.Entities.DTOReclamacao", "AutorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Entities.DTOSecretaria", "Destino")
                        .WithOne()
                        .HasForeignKey("Core.Entities.DTOReclamacao", "DestinoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Destino");
                });

            modelBuilder.Entity("Core.Entities.DTOSecretaria", b =>
                {
                    b.HasOne("Core.Entities.DTOEndereco", "Endereco")
                        .WithOne()
                        .HasForeignKey("Core.Entities.DTOSecretaria", "EnderecoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Core.Entities.DTOServidor", b =>
                {
                    b.HasOne("Core.Entities.DTOCargo", "Cargo")
                        .WithMany("Servidors")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Core.Entities.DTOSecretaria", "Secretaria")
                        .WithMany("Servidores")
                        .HasForeignKey("SecretariaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Infrastructure.DataBaseModels.Entities.DTOUser", "User")
                        .WithOne()
                        .HasForeignKey("Core.Entities.DTOServidor", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("Secretaria");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.DataBaseModels.Entities.DTOSolicitacao", b =>
                {
                    b.HasOne("Core.Entities.DTOServidor", "AtendidoPor")
                        .WithOne()
                        .HasForeignKey("Infrastructure.DataBaseModels.Entities.DTOSolicitacao", "AtendidoPorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Core.Entities.DTOSecretaria", "SecretariaDestino")
                        .WithMany("Solicitacoes")
                        .HasForeignKey("SecretariaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Infrastructure.DataBaseModels.Entities.DTOUser", "SolicitadoPor")
                        .WithMany("Solicitacao")
                        .HasForeignKey("SolicitadoPorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AtendidoPor");

                    b.Navigation("SecretariaDestino");

                    b.Navigation("SolicitadoPor");
                });

            modelBuilder.Entity("Infrastructure.DataBaseModels.Entities.DTOUser", b =>
                {
                    b.HasOne("Core.Entities.DTOEndereco", "Endereco")
                        .WithOne()
                        .HasForeignKey("Infrastructure.DataBaseModels.Entities.DTOUser", "EnderecoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Core.Entities.DTOCargo", b =>
                {
                    b.Navigation("Servidors");
                });

            modelBuilder.Entity("Core.Entities.DTOFamilia", b =>
                {
                    b.Navigation("Cestas");

                    b.Navigation("Membros");
                });

            modelBuilder.Entity("Core.Entities.DTOSecretaria", b =>
                {
                    b.Navigation("Servidores");

                    b.Navigation("Solicitacoes");
                });

            modelBuilder.Entity("Infrastructure.DataBaseModels.Entities.DTOUser", b =>
                {
                    b.Navigation("Solicitacao");
                });
#pragma warning restore 612, 618
        }
    }
}
