using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DataBank.Models
{
    public class PessoaJuridica : BaseModel
    {
        [Required]
        [DataMember]
        public Filial Filial { get; private set; }
        [Required]
        [DataMember]
        public Agencia Agencia { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; private set; }
        [DataMember]
        [RegularExpression("[0-9]{2}[.]?[0-9]{3}[.]?[0-9]{3}[/]?[0-9]{4}[-]?[0-9]{2}", ErrorMessage = "CNPJ Inválida (xx.xxx.xxx/xxxx-xx ou xxxxxxxxxxxxxx)")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Remote("CNPJUnica", "Pessoas", ErrorMessage = "CNPJ já está em uso por pessoa Ativa", AdditionalFields = "Id")]
        public string CNPJ { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Inscrição Municipal")]
        public string NumeroMunicipal { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public bool Ativo { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Rua { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Número")]
        public int NumeroEndereco { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Bairro { get; private set; }
        [DataMember]
        public string Complemento { get; private set; }
        [DataMember]
        [DisplayName("Observação")]
        public string Observacao { get; private set; }
        [DataMember]
        [RegularExpression("[0-9]{2}[0-9]{3}[-]?[0-9]{3}", ErrorMessage = "CEP Inválido (xxxxx-xxx ou xxxxxxxx)")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string CEP { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cidade { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Estado")]
        public string UF { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("País")]
        public string Pais { get; private set; }

        public PessoaJuridica()
        {
        }

        public PessoaJuridica(string nome, string cNPJ, string numeroMunicipal,
            bool ativo, string rua, int numeroEndereco,
            string bairro, string complemento, string observacao,
            string cEP, string cidade, string uF, string pais)
        {
            Nome = nome;
            CNPJ = cNPJ;
            NumeroMunicipal = numeroMunicipal;
            Ativo = ativo;
            Rua = rua;
            NumeroEndereco = numeroEndereco;
            Bairro = bairro;
            Complemento = complemento;
            Observacao = observacao;
            CEP = cEP;
            Cidade = cidade;
            UF = uF;
            Pais = pais;
        }

        //internal void AtualizaFilial(Filial filialDB)
        //{
        //    Filial = filialDB;
        //}

        internal void AtualizaPessoaJuridica(string nome, string cNPJ, string numeroMunicipal, string rua, int numeroEndereco,
          string bairro, string complemento, string observacao,
          string cEP, string cidade, string uF, string pais)
        {
            Nome = nome;
            CNPJ = cNPJ;
            NumeroMunicipal = numeroMunicipal;
            Rua = rua;
            NumeroEndereco = numeroEndereco;
            Bairro = bairro;
            Complemento = complemento;
            Observacao = observacao;
            CEP = cEP;
            Cidade = cidade;
            UF = uF;
            Pais = pais;
        }

        internal void AtualizaAtivo(bool ativo)
        {
            if (Filial != null && ativo == false)
            {
                Filial.AtualizaAtivo(ativo);
            }
            Ativo = ativo;
            //if (Agencia != null && ativo == false)
            //{
            //    Agencia.AtualizaAtivo(ativo);
            //}
        }

        internal void AtualizaId(int id)
        {
            Id = id;
        }
    }
}