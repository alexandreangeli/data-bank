using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace BancoDataCoper.Models
{
    public class ContaCorrente : BaseModel
    {
        public ContaCorrente()
        {
        }

        public ContaCorrente(Banco banco, Agencia agencia, Filial filial, DateTime dataDeAbertura, string descricao, long numeroDaConta, string digitoVerificadorCC, double saldo)
        {
            Banco = banco;
            Agencia = agencia;
            Filial = filial;
            DataDeAbertura = dataDeAbertura;
            Descricao = descricao;
            NumeroDaConta = numeroDaConta;
            DigitoVerificadorCC = digitoVerificadorCC;
            Saldo = saldo;
        }

        public List<MovimentoBancario> MovimentosBancarios { get; private set; } = new List<MovimentoBancario>();

        public List<MovimentoBancario> TransferenciasGet { get; private set; } = new List<MovimentoBancario>();

        public List<MovimentoBancario> TransferenciasSend { get; private set; } = new List<MovimentoBancario>();

        public List<PostoDeCaixa> PostosDeCaixa { get; private set; } = new List<PostoDeCaixa>();

        [DataMember]
        public Banco Banco { get; private set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataMember]
        public Agencia Agencia { get; private set; }      
        
        //[Required(ErrorMessage = "Campo obrigatório")]
        [DataMember]
        public Filial Filial { get; private set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataMember]
        [DisplayName("Data de Abertura")]
        public DateTime DataDeAbertura { get; private set; }
        [DataMember]
        [DisplayName("Data de Encerramento")]
        public DateTime? DataDeEncerramento { get; private set; }
        [DataMember]
        public string Descricao { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Número da Conta")]
        public long NumeroDaConta { get; private set; }
        [DataMember]
        [MaxLength(2, ErrorMessage = "Máximo de 2 digitos")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Dígito Verificador")]
        public string DigitoVerificadorCC { get; private set; }
        [DataMember]
        [DataType(DataType.Currency)]
        public double Saldo { get; private set; }
        [DataMember]
        public bool Ativo { get; private set; } = true;

        internal void AtualizaBanco(int bancoId, List<Banco> bancos)
        {
            Banco = bancos.Where(e => e.Id == bancoId).FirstOrDefault();

        }

        internal void AtualizaAgencia(int agenciaId, List<Agencia> agencias)
        {
            Agencia = agencias.Where(e => e.Id == agenciaId).FirstOrDefault();

        }

        internal void AtualizaFilial(int filialId, List<Filial> filiais)
        {
            Filial = filiais.Where(e => e.Id == filialId).FirstOrDefault();
        }

        internal void AtualizaDescricao(string descricao)
        {
            Descricao = descricao;
        }

        internal void AtualizaNumeroDaConta(long numeroDaConta)
        {
            NumeroDaConta = numeroDaConta;
        }

        internal void AtualizaDigitoVerificadorCC(string digitoVerificadorCC)
        {
            DigitoVerificadorCC = digitoVerificadorCC;
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

        internal void AtualizaDataDeEncerramento()
        {
            DataDeEncerramento = DateTime.Now;
        }

        internal void AtualizaSaldo(double saldo)
        {
            Saldo = saldo;
        }
    }
}
