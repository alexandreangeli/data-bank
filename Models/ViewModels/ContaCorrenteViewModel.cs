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
    public class ContaCorrenteViewModel
    {
        public ContaCorrenteViewModel()
        {
        }

        public ContaCorrenteViewModel(ContaCorrente contaCorrente)
        {
            ContaCorrente = contaCorrente;
        }

        public ContaCorrenteViewModel(List<Agencia> agenciasDB)
        {
            AgenciasDB = agenciasDB;
        }
        
        [Display(Name = "Banco")]
        public int SelectedBancoId { get; set; }
        public IEnumerable<SelectListItem> Bancos { get; set; }

        [Display(Name = "Agência")]
        public int SelectedAgenciaId { get; set; }
        public IEnumerable<SelectListItem> Agencias { get; set; }

        [Display(Name = "Filial")]
        public int SelectedFilialId { get; set; }
        public IEnumerable<SelectListItem> Filiais { get; set; }

        public List<Agencia> AgenciasDB { get; set; }

        public ContaCorrente ContaCorrente { get; }

        [DataMember]
        public Banco Banco { get; private set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataMember]
        public Agencia Agencia { get; private set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataMember]
        public Filial Filial { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Data de Abertura")]
        [DataMember]
        public DateTime DataDeAbertura { get; set; }
        [DisplayName("Data de Encerramento")]
        [DataMember]
        public DateTime? DataDeEncerramento { get; set; }
        [DataMember]
        public string Descricao { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public long NumeroDaConta { get; private set; }
        [DataMember]
        [MaxLength(2, ErrorMessage = "Máximo de 2 digitos")]
        [DisplayName("Dígito Verificador")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string DigitoVerificadorCC { get; private set; }
        [DataMember]
        [DataType(DataType.Currency)]
        public double Saldo { get; set; }

        public string BancoIdd { get; set; }
    }
}
