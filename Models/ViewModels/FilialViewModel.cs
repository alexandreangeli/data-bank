using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BancoDataCoper.Models.ViewModels
{
    public class FilialViewModel
    {
        public FilialViewModel()
        {
        }

        public FilialViewModel(Filial filial)
        {
            Filial = filial;            
        }

        [Display(Name = "Pessoa Juridica")]
        public int SelectedPessoaJuridicaId { get; set; }
        public IEnumerable<SelectListItem> PessoasJuridicas { get; set; }        

        [Display(Name = "Empresa")]
        public int SelectedEmpresaId { get; set; }
        public IEnumerable<SelectListItem> Empresas { get; set; }
        
        public Filial Filial { get; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public bool Ativo { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Número na Junta")]
        public long NumeroRegistroNaJuntaComercial { get; private set; }
        //[DataMember]
        //[Required(ErrorMessage = "Campo obrigatório")]
        //public string NomeFantasia { get; private set; }
        //[DataMember]
        //[Required(ErrorMessage = "Campo obrigatório")]
        //[RegularExpression("[0-9]{2}[.]?[0-9]{3}[.]?[0-9]{3}[/]?[0-9]{4}[-]?[0-9]{2}", ErrorMessage = "CNPJ Inválida (xx.xxx.xxx/xxxx-xx ou xxxxxxxxxxxxxx)")]
        //[Remote("CNPJUnica", "Filiais", ErrorMessage = "CNPJ já está em uso")]
        //public string CNPJ { get; private set; }
        //[DataMember]
        //[Required(ErrorMessage = "Campo obrigatório")]
        //public long NumeroDaInscricaoMunicipal { get; private set; }
    }
}
