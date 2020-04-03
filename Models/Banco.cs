using Databank.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Databank.Models
{    
    public class Banco: BaseModel
    {
        [DataMember]        
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; private set; } = "";

        [DataMember]
        [Remote("CodigoUnico", "Bancos", ErrorMessage = "Código já está em uso")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Código")]
        public string Codigo { get; private set; } = "";

        public List<Agencia> Agencias { get; private set; } = new List<Agencia>();
        public List<ContaCorrente> ContasCorrentes { get; private set; } = new List<ContaCorrente>();

        public Banco()
        {
        }

        public Banco(string nome, string codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }
        
        internal void AtualizaNome(string nome)
        {
            Nome = nome;
        }
    }
}