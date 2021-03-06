﻿// <auto-generated />
using System;
using DataBank.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataBank.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20200403235359_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("DataBank.Models.Agencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BancoId");

                    b.Property<int>("Codigo");

                    b.Property<int>("DigitoVerificador");

                    b.Property<int>("PessoaJuridicaForeignKey");

                    b.HasKey("Id");

                    b.HasIndex("BancoId");

                    b.HasIndex("PessoaJuridicaForeignKey")
                        .IsUnique();

                    b.ToTable("Agencia");
                });

            modelBuilder.Entity("DataBank.Models.Banco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Codigo")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Banco");
                });

            modelBuilder.Entity("DataBank.Models.ContaCorrente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AgenciaId");

                    b.Property<bool>("Ativo");

                    b.Property<int?>("BancoId");

                    b.Property<DateTime>("DataDeAbertura");

                    b.Property<DateTime?>("DataDeEncerramento");

                    b.Property<string>("Descricao");

                    b.Property<string>("DigitoVerificadorCC")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<int?>("FilialId");

                    b.Property<long>("NumeroDaConta");

                    b.Property<double>("Saldo");

                    b.HasKey("Id");

                    b.HasIndex("AgenciaId");

                    b.HasIndex("BancoId");

                    b.HasIndex("FilialId");

                    b.ToTable("ContaCorrente");
                });

            modelBuilder.Entity("DataBank.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Sigla")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("DataBank.Models.Filial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<int>("EmpresaId");

                    b.Property<long>("NumeroRegistroNaJuntaComercial");

                    b.Property<int>("PessoaJuridicaForeignKey");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("PessoaJuridicaForeignKey")
                        .IsUnique();

                    b.ToTable("Filial");
                });

            modelBuilder.Entity("DataBank.Models.MovimentoBancario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<bool>("Cheque");

                    b.Property<int>("ContaCorrenteId");

                    b.Property<DateTime>("Data");

                    b.Property<string>("Tipo")
                        .IsRequired();

                    b.Property<int?>("TransferenciaGetId");

                    b.Property<int?>("TransferenciaSendId");

                    b.Property<string>("Usuario");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("ContaCorrenteId");

                    b.HasIndex("TransferenciaGetId");

                    b.HasIndex("TransferenciaSendId");

                    b.ToTable("MovimentoBancario");
                });

            modelBuilder.Entity("DataBank.Models.PessoaFisica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Bairro")
                        .IsRequired();

                    b.Property<string>("CEP")
                        .IsRequired();

                    b.Property<string>("CPF")
                        .IsRequired();

                    b.Property<string>("Cidade")
                        .IsRequired();

                    b.Property<string>("Complemento");

                    b.Property<string>("DataNascimento")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Genero")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("NumeroEndereco");

                    b.Property<string>("Observacao");

                    b.Property<string>("OrgaoExpedidor")
                        .IsRequired();

                    b.Property<string>("Pais")
                        .IsRequired();

                    b.Property<string>("RG")
                        .IsRequired();

                    b.Property<string>("Rua")
                        .IsRequired();

                    b.Property<string>("UF")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("PessoaFisica");
                });

            modelBuilder.Entity("DataBank.Models.PessoaJuridica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Bairro")
                        .IsRequired();

                    b.Property<string>("CEP")
                        .IsRequired();

                    b.Property<string>("CNPJ")
                        .IsRequired();

                    b.Property<string>("Cidade")
                        .IsRequired();

                    b.Property<string>("Complemento");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("NumeroEndereco");

                    b.Property<string>("NumeroMunicipal")
                        .IsRequired();

                    b.Property<string>("Observacao");

                    b.Property<string>("Pais")
                        .IsRequired();

                    b.Property<string>("Rua")
                        .IsRequired();

                    b.Property<string>("UF")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("PessoaJuridica");
                });

            modelBuilder.Entity("DataBank.Models.PostoDeCaixa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<int>("CodigoDoPosto");

                    b.Property<int?>("ContaCorrenteId");

                    b.Property<int?>("FilialId");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("ContaCorrenteId");

                    b.HasIndex("FilialId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("PostoDeCaixa");
                });

            modelBuilder.Entity("DataBank.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<long>("Celular");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int?>("EmpresaId");

                    b.Property<int>("FilialId");

                    b.Property<int>("PessoaFisicaForeignKey");

                    b.Property<string>("Senha")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("FilialId");

                    b.HasIndex("PessoaFisicaForeignKey")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("DataBank.Models.Agencia", b =>
                {
                    b.HasOne("DataBank.Models.Banco", "Banco")
                        .WithMany("Agencias")
                        .HasForeignKey("BancoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataBank.Models.PessoaJuridica", "PessoaJuridica")
                        .WithOne("Agencia")
                        .HasForeignKey("DataBank.Models.Agencia", "PessoaJuridicaForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataBank.Models.ContaCorrente", b =>
                {
                    b.HasOne("DataBank.Models.Agencia", "Agencia")
                        .WithMany("ContasCorrentes")
                        .HasForeignKey("AgenciaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataBank.Models.Banco", "Banco")
                        .WithMany("ContasCorrentes")
                        .HasForeignKey("BancoId");

                    b.HasOne("DataBank.Models.Filial", "Filial")
                        .WithMany("ContasCorrentes")
                        .HasForeignKey("FilialId");
                });

            modelBuilder.Entity("DataBank.Models.Filial", b =>
                {
                    b.HasOne("DataBank.Models.Empresa", "Empresa")
                        .WithMany("Filiais")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataBank.Models.PessoaJuridica", "PessoaJuridica")
                        .WithOne("Filial")
                        .HasForeignKey("DataBank.Models.Filial", "PessoaJuridicaForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataBank.Models.MovimentoBancario", b =>
                {
                    b.HasOne("DataBank.Models.ContaCorrente", "ContaCorrente")
                        .WithMany("MovimentosBancarios")
                        .HasForeignKey("ContaCorrenteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataBank.Models.ContaCorrente", "TransferenciaGet")
                        .WithMany("TransferenciasGet")
                        .HasForeignKey("TransferenciaGetId");

                    b.HasOne("DataBank.Models.ContaCorrente", "TransferenciaSend")
                        .WithMany("TransferenciasSend")
                        .HasForeignKey("TransferenciaSendId");
                });

            modelBuilder.Entity("DataBank.Models.PostoDeCaixa", b =>
                {
                    b.HasOne("DataBank.Models.ContaCorrente", "ContaCorrente")
                        .WithMany("PostosDeCaixa")
                        .HasForeignKey("ContaCorrenteId");

                    b.HasOne("DataBank.Models.Filial", "Filial")
                        .WithMany("PostosDeCaixa")
                        .HasForeignKey("FilialId");

                    b.HasOne("DataBank.Models.Usuario", "Usuario")
                        .WithMany("PostosDeCaixa")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataBank.Models.Usuario", b =>
                {
                    b.HasOne("DataBank.Models.Empresa", "Empresa")
                        .WithMany("Usuarios")
                        .HasForeignKey("EmpresaId");

                    b.HasOne("DataBank.Models.Filial", "Filial")
                        .WithMany("Usuarios")
                        .HasForeignKey("FilialId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataBank.Models.PessoaFisica", "PessoaFisica")
                        .WithOne("Usuario")
                        .HasForeignKey("DataBank.Models.Usuario", "PessoaFisicaForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
