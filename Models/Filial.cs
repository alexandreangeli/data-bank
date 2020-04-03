using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace BancoDataCoper.Models
{
    public class Filial : BaseModel
    {
        public Filial()
        {
        }

        public Filial(PessoaJuridica pessoaJuridica, Empresa empresa, bool ativo, long numeroRegistroNaJuntaComercial)
        {
            PessoaJuridica = pessoaJuridica;
            Empresa = empresa;
            Ativo = ativo;
            NumeroRegistroNaJuntaComercial = numeroRegistroNaJuntaComercial;
        }

        //public Filial(Empresa empresa, bool ativo, string nomeFantasia, string cNPJ, long numeroDaInscricaoMunicipal, long numeroRegistroNaJuntaComercial)
        //{
        //    Empresa = empresa;
        //    Ativo = ativo;
        //    NomeFantasia = nomeFantasia;
        //    CNPJ = cNPJ;
        //    NumeroDaInscricaoMunicipal = numeroDaInscricaoMunicipal;
        //    NumeroRegistroNaJuntaComercial = numeroRegistroNaJuntaComercial;
        //}

        public List<ContaCorrente> ContasCorrentes { get; private set; } = new List<ContaCorrente>();
        public List<Usuario> Usuarios { get; private set; } = new List<Usuario>();
        public List<PostoDeCaixa> PostosDeCaixa { get; private set; } = new List<PostoDeCaixa>();

        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public PessoaJuridica PessoaJuridica { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public Empresa Empresa { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public bool Ativo { get; private set; }
        //[DataMember]
        //[Required(ErrorMessage = "Campo obrigatório")]
        //[DisplayName("Filial")]        
        //public string NomeFantasia { get; private set; }
        //[DataMember]
        //[Required(ErrorMessage = "Campo obrigatório")]
        //[RegularExpression("[0-9]{2}[.]?[0-9]{3}[.]?[0-9]{3}[/]?[0-9]{4}[-]?[0-9]{2}", ErrorMessage = "CNPJ Inválida (xx.xxx.xxx/xxxx-xx ou xxxxxxxxxxxxxx)")]
        //[Remote("CNPJUnica", "Filiais", ErrorMessage = "CNPJ já está em uso")]
        //public string CNPJ { get; private set; }
        //[DataMember]
        //[Required(ErrorMessage = "Campo obrigatório")]
        //[DisplayName("Inscrição Municipal")]
        //public long NumeroDaInscricaoMunicipal { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Número na Junta")]
        public long NumeroRegistroNaJuntaComercial { get; private set; }

        public int PessoaJuridicaForeignKey { get; private set; }

        internal void AtualizaEmpresa(int empresaId, List<Empresa> empresas)
        {
            Empresa = empresas.Where(e => e.Id == empresaId).FirstOrDefault();
            foreach (var usuario in Usuarios)
            {
                usuario.AtualizaEmpresa(empresaId, empresas);
            }
        }

        internal void AtualizaPessoaJuridica(int pessoaJuridicaId, List<PessoaJuridica> pessoasJuridicas, Filial filialDB)
        {

            PessoaJuridica = pessoasJuridicas.Where(e => e.Id == pessoaJuridicaId).FirstOrDefault();
        }

        //internal void AtualizaNomeFantasia(string nomeFantasia)
        //{
        //    NomeFantasia = nomeFantasia;
        //}

        //internal void AtualizaCNPJ(string cNPJ)
        //{
        //    CNPJ = cNPJ;
        //}

        //internal void AtualizaNumeroDaInscricaoMunicipal(long numeroDaInscricaoMunicipalbool)
        //{
        //    NumeroDaInscricaoMunicipal = numeroDaInscricaoMunicipalbool;
        //}

        internal void AtualizaNumeroRegistroNaJuntaComercial(long numeroRegistroNaJuntaComercial)
        {
            NumeroRegistroNaJuntaComercial = numeroRegistroNaJuntaComercial;
        }

        internal void AtualizaAtivo(bool ativo)
        {
            Ativo = ativo;
            if (Usuarios != null && ativo == false)
            {
                foreach (var usuario in Usuarios)
                {
                    usuario.AtualizaAtivo(ativo);
                }
            }
            //if (PostosDeCaixa != null && ativo == false)
            //{
            //    foreach (var postoDeCaixa in PostosDeCaixa)
            //    {
            //        postoDeCaixa.AtualizaAtivo(ativo);
            //    }
            //}
        }
    }

}