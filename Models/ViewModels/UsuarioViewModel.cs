using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DataBank.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
        }

        public UsuarioViewModel(Usuario usuario)
        {
            Usuario = usuario;
        }

        public UsuarioViewModel(List<Filial> filiaisDB)
        {
            FiliaisDB = filiaisDB;
        }
        
        [Display(Name = "Empresa")]
        public int SelectedEmpresaId { get; set; }
        public IEnumerable<SelectListItem> Empresas { get; set; }

        [Display(Name = "Filial")]
        public int SelectedFilialId { get; set; }
        public IEnumerable<SelectListItem> Filiais { get; set; }

        [Display(Name = "Pessoa Física")]
        public int SelectedPessoaFisicaId { get; set; }
        public IEnumerable<SelectListItem> PessoasFisicas { get; set; }

        public List<Filial> FiliaisDB { get; set; }

        public Usuario Usuario { get; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail inválido")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [Remote("EmailUnico", "Usuarios", ErrorMessage = "E-Mail já cadastrado")]
        public string Email { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression("^[1-9]{2}[2-9][0-9]{7,8}$", ErrorMessage = "Telefone inválido (xx xxxxx-xxxx)")]
        public long Celular { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^((?=.*[a-z]|[A-Z])|(?=.*[A-Z]))(?=.*\d)(?=.*[#$^+=. , ! < > @]).{6,10}$", ErrorMessage = "A senha deve ser formada por no mínimo 6 (seis) e máximo 10 (dez) caracteres. Sendo Letras (a-z , A-Z), Números (0 - 9) e Caracteres especiais ( . , ! < > @ ). As senhas devem conter ao menos um carácter de cada um dos três grupos")]
        public string Senha { get; private set; }
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public bool Ativo { get; private set; }

        public string EmpresaIdd { get; set; }
    }
}
