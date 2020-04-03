using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Databank.Models
{
    public class MovimentoBancario : BaseModel
    {
        public MovimentoBancario()
        {
        }

        public MovimentoBancario(ContaCorrente contaCorrente, string usuario, double valor, string tipo, DateTime data, bool cheque, ContaCorrente transferenciaGet, ContaCorrente transferenciaSend)
        {
            ContaCorrente = contaCorrente;
            Usuario = usuario;
            Valor = valor;
            Data = data;
            Tipo = tipo;
            Cheque = cheque;
            TransferenciaGet = transferenciaGet;
            TransferenciaSend = transferenciaSend;
        }

        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public ContaCorrente ContaCorrente { get; private set; }

        [DataMember]
        public string Usuario { get; private set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Currency)]
        [RegularExpression(@"\d+(\,\d{1,2})?", ErrorMessage = "Valor inválido")]
        [DataMember]
        public double Valor { get; private set; }

        //Tipos: saque, deposito, transferencia
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataMember]
        public string Tipo { get; private set; }

        [DataMember]
        public bool Cheque { get; private set; }

        [DataMember]
        public DateTime Data { get; private set; }

        [DataMember]
        public ContaCorrente TransferenciaGet { get; private set; }

        [DataMember]
        public ContaCorrente TransferenciaSend { get; private set; }

        [DataMember]
        public bool Ativo { get; private set; } = true;

        internal void AtualizaAtivo(bool ativo)
        {
            Ativo = ativo;
        }
    }
}
