using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace DataBank.Models
{
    public class PostoDeCaixa : BaseModel
    {
        public PostoDeCaixa()
        {
        }

        public PostoDeCaixa(Filial filial, Usuario usuario, ContaCorrente contaCorrente, int codigoDoPosto, string nome, bool ativo)
        {
            Filial = filial;
            Usuario = usuario;
            ContaCorrente = contaCorrente;
            CodigoDoPosto = codigoDoPosto;
            Nome = nome;
            Ativo = ativo;
        }

        [DataMember]
        public Filial Filial { get; private set; }

        [DataMember]
        [Required]
        public Usuario Usuario { get; set; }

        [DataMember]
        public ContaCorrente ContaCorrente { get; private set; }

        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Código do posto")]
        public int CodigoDoPosto { get; private set; }

        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; private set; }

        internal void AtualizaFilial(int filialId, List<Filial> filiais)
        {
            var filialAntiga = Filial;

            Filial = filiais.Where(e => e.Id == filialId).FirstOrDefault();

            if (filialAntiga.Id != Filial.Id)
            {
                AtualizaCodigoDoPosto(Filial.PostosDeCaixa.Count() + 1);
            }
        }

        [DataMember]
        public bool Ativo { get; private set; }

        internal void AtualizaContaCorrente(int contaCorrenteId, List<ContaCorrente> contasCorrentes)
        {
            ContaCorrente = contasCorrentes.Where(e => e.Id == contaCorrenteId).FirstOrDefault();
        }

        internal void AtualizaUsuario(int usuarioId, List<Usuario> usuarios)
        {
            Usuario = usuarios.Where(e => e.Id == usuarioId).FirstOrDefault();
        }

        internal void AtualizaCodigoDoPosto(int codigoDoPosto)
        {
            CodigoDoPosto = codigoDoPosto;
        }

        internal void AtualizaNome(string nome)
        {
            Nome = nome;
        }

        internal void AtualizaAtivo(bool ativo)
        {
            Ativo = ativo;
        }
    }
}