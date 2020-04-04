using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DataBank.Models.ViewModels
{
    public class PostoDeCaixaViewModel
    {
        public PostoDeCaixaViewModel()
        {
        }

        public PostoDeCaixaViewModel(PostoDeCaixa postoDeCaixa)
        {
            PostoDeCaixa = postoDeCaixa;
        }

        public PostoDeCaixaViewModel(List<ContaCorrente> contasCorrentesDB, List<Usuario> usuariosDB)
        {
            ContasCorrentesDB = contasCorrentesDB;
            UsuariosDB = usuariosDB;
        }

        [Display(Name = "Filial")]
        public int SelectedFilialId { get; set; }
        public IEnumerable<SelectListItem> Filiais { get; set; }
        
        [Display(Name = "ContaCorrente")]
        public int SelectedContaCorrenteId { get; set; }
        public IEnumerable<SelectListItem> ContasCorrentes { get; set; }

        [Display(Name = "Usuário")]
        public int SelectedUsuarioId { get; set; }
        public IEnumerable<SelectListItem> Usuarios { get; set; }

        public List<ContaCorrente> ContasCorrentesDB { get; set; }
        public List<Usuario> UsuariosDB { get; set; }

        public PostoDeCaixa PostoDeCaixa{ get; }

        public Filial Filial { get; private set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataMember]
        public Usuario Usuario { get; private set; }

        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public ContaCorrente ContaCorrente { get; private set; }

        [DataMember]
        [DisplayName("Código do posto")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int CodigoDoPosto { get; private set; }

        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; private set; }

        [DataMember]
        public bool Ativo { get; private set; }

        public string FilialIdd { get; set; }
        public string UsuarioIdd { get; set; }

    }
}
