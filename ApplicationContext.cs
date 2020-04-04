using DataBank.Models;

using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace DataBank.Repositories
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Banco>().HasKey(t => t.Id);
            modelBuilder.Entity<Banco>().HasMany(t => t.Agencias).WithOne(t => t.Banco);
            modelBuilder.Entity<Banco>().HasMany(t => t.ContasCorrentes).WithOne(t => t.Banco);

            modelBuilder.Entity<Agencia>().HasKey(t => t.Id);
            modelBuilder.Entity<Agencia>().HasOne(a => a.Banco);
            modelBuilder.Entity<Agencia>().HasOne(a => a.PessoaJuridica);
            modelBuilder.Entity<Agencia>().HasMany(t => t.ContasCorrentes).WithOne(t => t.Agencia);

            modelBuilder.Entity<Empresa>().HasKey(t => t.Id);
            modelBuilder.Entity<Empresa>().HasMany(t => t.Filiais).WithOne(t => t.Empresa);
            modelBuilder.Entity<Empresa>().HasMany(t => t.Usuarios).WithOne(t => t.Empresa);

            modelBuilder.Entity<Filial>().HasKey(t => t.Id);
            modelBuilder.Entity<Filial>().HasOne(t => t.Empresa);
            modelBuilder.Entity<Filial>().HasMany(t => t.Usuarios).WithOne(t => t.Filial);
            modelBuilder.Entity<Filial>().HasMany(t => t.ContasCorrentes).WithOne(t => t.Filial);
            modelBuilder.Entity<Filial>().HasMany(t => t.PostosDeCaixa).WithOne(t => t.Filial);

            modelBuilder.Entity<Usuario>().HasKey(t => t.Id);
            modelBuilder.Entity<Usuario>().HasOne(t => t.Filial);
            modelBuilder.Entity<Usuario>().HasOne(t => t.Empresa);
            modelBuilder.Entity<Usuario>().HasMany(t => t.PostosDeCaixa).WithOne(t => t.Usuario);

            modelBuilder.Entity<PessoaJuridica>().HasKey(t => t.Id);
            modelBuilder.Entity<PessoaJuridica>()
                .HasOne(t => t.Filial)
                .WithOne(t => t.PessoaJuridica)
                .HasForeignKey<Filial>(t => t.PessoaJuridicaForeignKey);
            modelBuilder.Entity<PessoaJuridica>()
                .HasOne(t => t.Agencia)
                .WithOne(t => t.PessoaJuridica)
                .HasForeignKey<Agencia>(t => t.PessoaJuridicaForeignKey);

            modelBuilder.Entity<PessoaFisica>().HasKey(t => t.Id);
            modelBuilder.Entity<PessoaFisica>()
               .HasOne(t => t.Usuario)
               .WithOne(t => t.PessoaFisica)
               .HasForeignKey<Usuario>(t => t.PessoaFisicaForeignKey);

            modelBuilder.Entity<ContaCorrente>().HasKey(t => t.Id);
            modelBuilder.Entity<ContaCorrente>().HasOne(t => t.Filial);
            modelBuilder.Entity<ContaCorrente>().HasOne(t => t.Banco);
            modelBuilder.Entity<ContaCorrente>().HasOne(t => t.Agencia);
            modelBuilder.Entity<ContaCorrente>().HasMany(t => t.PostosDeCaixa).WithOne(t => t.ContaCorrente);
            modelBuilder.Entity<ContaCorrente>().HasMany(t => t.MovimentosBancarios).WithOne(t => t.ContaCorrente);
            modelBuilder.Entity<ContaCorrente>().HasMany(t => t.TransferenciasGet).WithOne(t => t.TransferenciaGet);
            modelBuilder.Entity<ContaCorrente>().HasMany(t => t.TransferenciasSend).WithOne(t => t.TransferenciaSend);

            modelBuilder.Entity<PostoDeCaixa>().HasKey(t => t.Id);
            modelBuilder.Entity<PostoDeCaixa>().HasOne(t => t.Filial);
            modelBuilder.Entity<PostoDeCaixa>().HasOne(t => t.ContaCorrente);
            modelBuilder.Entity<PostoDeCaixa>().HasOne(t => t.Usuario);

            modelBuilder.Entity<MovimentoBancario>().HasKey(t => t.Id);
            modelBuilder.Entity<MovimentoBancario>().HasOne(t => t.ContaCorrente);
            modelBuilder.Entity<MovimentoBancario>().HasOne(t => t.TransferenciaGet);
            modelBuilder.Entity<MovimentoBancario>().HasOne(t => t.TransferenciaSend);


        }
    }
}