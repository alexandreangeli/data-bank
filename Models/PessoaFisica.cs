using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DataBank.Models
{
    public class PessoaFisica : BaseModel
    {
        [DataMember]
        public Usuario Usuario { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression("^[A-ZÀ-Ö][a-zØ-öø-ÿ]*([ ][A-ZA-ZÀ-Ö][a-zØ-öø-ÿ]*)+$", ErrorMessage = "Insira o Nome Completo capitalizado")]
        public string Nome { get; private set; }
        [DataMember]
        [RegularExpression("[0-9]{3}[.]?[0-9]{3}[.]?[0-9]{3}[-]?[0-9]{2}", ErrorMessage = "CPF Inválido (xxx.xxx.xxx-xx ou xxxxxxxxxxxxxx)")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string CPF { get; private set; }
        [DataMember]
        [RegularExpression("[0-9]{2}[.]?[0-9]{3}[.]?[0-9]{3}[-]?[0-9]{1}", ErrorMessage = "RG Inválido (xx.xxx.xxx-x ou xxxxxxxxx)")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string RG { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Orgão Expeditor")]
        public string OrgaoExpedidor { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Data de Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida (dd/mm/aaaa)")]
        [MaxLength(10, ErrorMessage = "Data Inválida (dd/mm/aaaa)")]
        public string DataNascimento { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Gênero")]
        public string Genero { get; private set; }
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
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression("[0-9]{2}[0-9]{3}[-]?[0-9]{3}", ErrorMessage = "CEP Inválido (xxxxx-xxx ou xxxxxxxx)")]
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

        public PessoaFisica()
        {
        }

        public PessoaFisica(string nome, string cPF, string rG, string orgaoExpedidor, string dataNascimento, string genero, bool ativo, string rua, int numeroEndereco, string bairro, string complemento, string observacao, string cEP, string cidade, string uF, string pais)
        {
            Nome = nome;
            CPF = cPF;
            RG = rG;
            OrgaoExpedidor = orgaoExpedidor;
            DataNascimento = dataNascimento;
            Genero = genero;
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

        internal void AtualizaPessoaFisica(string nome, string cPF, string rG, string orgaoExpedidor, string dataNascimento, string genero, string rua, int numeroEndereco, string bairro, string complemento, string observacao, string cEP, string cidade, string uF, string pais)
        {
            Nome = nome;
            CPF = cPF;
            RG = rG;
            OrgaoExpedidor = orgaoExpedidor;
            DataNascimento = dataNascimento;
            Genero = genero;
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
            if (Usuario != null && ativo == false)
            {
                Usuario.AtualizaAtivo(ativo);
            }
            Ativo = ativo;
        }
    }
}