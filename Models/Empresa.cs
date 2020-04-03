using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Databank.Models
{
    public class Empresa : BaseModel
    {
        public Empresa()
        {
        }

        public Empresa(string nome, string sigla, bool ativo)
        {
            Nome = nome;
            Sigla = sigla;
            Ativo = ativo;
        }
        public List<Usuario> Usuarios { get; private set; } = new List<Usuario>();
        public List<Filial> Filiais { get; private set; } = new List<Filial>();

        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Empresa")]
        public string Nome { get; private set; }

        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Sigla { get; private set; }

        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public bool Ativo { get; private set; }

        internal void AtualizaNome(string nome)
        {
            Nome = nome;
        }

        internal void AtualizaSigla(string sigla)
        {
            Sigla = sigla;
        }

        internal void AtualizaAtivo(bool ativo)
        {
            Ativo = ativo;
            if (Filiais != null && ativo == false)
            {
                foreach (var filial in Filiais)
                {
                    filial.AtualizaAtivo(ativo);
                }
            }
        }
    }

}