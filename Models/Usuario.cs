using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BancoDataCoper.Models
{
    [DataContract]
    public class Usuario : BaseModel
    {
        public Usuario()
        {
        }

        public Usuario(Empresa empresa, Filial filial, PessoaFisica pessoaFisica, string email, long celular, string senha, bool ativo)
        {
            Empresa = empresa;
            Filial = filial;
            PessoaFisica = pessoaFisica;
            Email = email;
            Celular = celular;
            Senha = senha;
            Ativo = ativo;
        }

        //public List<MovimentoBancario> MovimentosBancarios { get; private set; } = new List<MovimentoBancario>();

        public List<PostoDeCaixa> PostosDeCaixa { get; private set; } = new List<PostoDeCaixa>();

        [DataMember]
        public Empresa Empresa { get; private set; }

        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public Filial Filial { get; private set; }

        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public PessoaFisica PessoaFisica { get; private set; }

        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail inválido")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [DisplayName("E-Mail")]
        [Remote("EmailUnico", "Usuarios", ErrorMessage = "E-Mail já cadastrado")]
        public string Email { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression("^[1-9]{2}[2-9][0-9]{7,8}$", ErrorMessage = "Telefone inválido (xx xxxxx-xxxx)")]
        public long Celular { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^((?=.*[a-z]|[A-Z])|(?=.*[A-Z]))(?=.*\d)(?=.*[#$^+=. , ! < > @]).{6,10}$", ErrorMessage = "A senha deve ser formada por no mínimo 6 (seis) e máximo 10 (dez) caracteres. Sendo Letras (a-z , A-Z), Números (0 - 9) e Caracteres especiais ( . , ! < > @ ). As senhas devem conter ao menos um carácter de cada um dos três grupos")]
        public string Senha { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public bool Ativo { get; private set; }

        public int PessoaFisicaForeignKey { get; private set; }

        internal void AtualizaSenha(string senha)
        {
            Senha = senha;
        }

        internal void AtualizaAtivo(bool ativo)
        {
            Ativo = ativo;
            if (PostosDeCaixa != null && ativo == false)
            {
                foreach (var postoDeCaixa in PostosDeCaixa)
                {
                    postoDeCaixa.AtualizaAtivo(ativo);
                }
            }
        }

        internal void AtualizaCelular(long celular)
        {
            Celular = celular;
        }

        internal void AtualizaEmail(string email)
        {
            Email = email;
        }

        internal void AtualizaPessoaFisica(int pessoaFisicaId, List<PessoaFisica> pessoasFisicas)
        {
            PessoaFisica = pessoasFisicas.Where(f => f.Id == pessoaFisicaId).FirstOrDefault();
        }

        internal void AtualizaFilial(int filialId, List<Filial> filiais)
        {
            Filial = filiais.Where(f => f.Id == filialId).FirstOrDefault();
        }

        internal void AtualizaEmpresa(int empresaId, List<Empresa> empresas)
        {
            Empresa = empresas.Where(e => e.Id == empresaId).FirstOrDefault();
        }
    }
}