using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BancoDataCoper.Models
{
    
    public class Agencia : BaseModel
    {
        public Agencia()
        {
        }

        public Agencia(PessoaJuridica pessoaJuridica, Banco banco, int codigo, int digitoVerificador)
        {
            PessoaJuridica = pessoaJuridica;
            Banco = banco;
            Codigo = codigo;
            DigitoVerificador = digitoVerificador;
        }

        public List<ContaCorrente> ContasCorrentes { get; private set; } = new List<ContaCorrente>();

        public int PessoaJuridicaForeignKey { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public PessoaJuridica PessoaJuridica { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public Banco Banco { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        //[RegularExpression("[0-9]{4}", ErrorMessage = "Máximo 4 digitos")]
        public int Codigo { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        //[RegularExpression("[0-9]{1}", ErrorMessage = "Máximo 1 digitos")]
        [DisplayName("Dígito Verificador")]
        public int DigitoVerificador { get; private set; }

        internal void AtualizaBanco(int bancoId, List<Banco> bancos)
        {
            Banco = bancos.Where(e => e.Id == bancoId).FirstOrDefault();
        }

        internal void AtualizaPessoaJuridica(int pessoaJuridicaId, List<PessoaJuridica> pessoasJuridicas)
        {
            PessoaJuridica = pessoasJuridicas.Where(e => e.Id == pessoaJuridicaId).FirstOrDefault();
        }

        internal void AtualizaCodigo(int codigo)
        {
            Codigo = codigo;
        }

        internal void AtualizaDigitoVerificador(int digitoVerificador)
        {
            DigitoVerificador = digitoVerificador;
        }
    }
}
    