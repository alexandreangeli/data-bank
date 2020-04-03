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
    public class AgenciaViewModel
    {
        public AgenciaViewModel()
        {
        }

        public AgenciaViewModel(Agencia agencia)
        {
            Agencia = agencia;
        }
        
        [Display(Name = "Banco")]
        public int SelectedBancoId { get; set; }
        public IEnumerable<SelectListItem> Bancos { get; set; }

        [Display(Name = "Pessoa Jurídica")]
        public int SelectedPessoaJuridicaId { get; set; }
        public IEnumerable<SelectListItem> PessoasJuridicas { get; set; }

        public List<Filial> FiliaisDB { get; set; }

        public Agencia Agencia { get; }

        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public PessoaJuridica PessoaJuridica { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public Banco Banco { get; private set; }
        [DataMember]
        [MinLength(4, ErrorMessage = "Deve ser composto por 4 dígitos")]
        [MaxLength(4, ErrorMessage = "Deve ser composto por 4 dígitos")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Codigo { get; private set; }
        [DataMember]
        [MaxLength(1, ErrorMessage = "Deve ser composto por 1 dígito")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Dígito Verificador")]
        public int DigitoVerificador { get; private set; }

        public string EmpresaIdd { get; set; }
    }
}
