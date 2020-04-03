using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Databank.Models.ViewModels
{
    public class MovimentoBancarioViewModel
    {
        public MovimentoBancarioViewModel()
        {
        }

        public MovimentoBancarioViewModel(Usuario usuario)
        {
            Usuario = usuario;
        }

        public MovimentoBancarioViewModel(Usuario usuario, ContaCorrente contaCorrente)
        {
            Usuario = usuario;
            ContaCorrente = contaCorrente;
        }

        public MovimentoBancarioViewModel(Usuario usuario, ContaCorrente contaCorrente, DateTime data)
        {
            Usuario = usuario;
            ContaCorrente = contaCorrente;
            Data = data;
        }

        public MovimentoBancarioViewModel(Usuario usuario, ContaCorrente contaCorrente, MovimentoBancario movimentoBancario)
        {
            Usuario = usuario;
            ContaCorrente = contaCorrente;
            MovimentoBancario = movimentoBancario;
        }

        public MovimentoBancarioViewModel(Usuario usuario, List<ContaCorrente> contasCorrentes, List<Filial> filiais, List<Banco> bancos)
        {
            Usuario = usuario;
            ContasCorrentes = contasCorrentes;
            Filiais = filiais;
            Bancos = bancos;
        }

        [DataMember]
        public Usuario Usuario { get; private set; }

        [DataMember]
        public ContaCorrente ContaCorrente { get; private set; }
        public List<ContaCorrente> ContasCorrentes { get; private set; }
        public List<Filial> Filiais { get; private set; }
        public List<Banco> Bancos { get; private set; }

        [DataMember]
        public MovimentoBancario MovimentoBancario { get; private set; }

        [DataMember]
        public List<MovimentoBancario> Movimentos { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime Data { get; private set; }

        public List<ContaCorrente> ContasCorrentesDB { get; set; }
        public List<Filial> FiliaisDB { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"\d+(\,\d{1,2})?", ErrorMessage = "Valor inválido")]
        [DataType(DataType.Currency)]
        public double Valor { get; private set; }

        [DataMember]
        public string Tipo { get; set; }

        public int FilialIdd { get; set; }
        public int BancoIdd { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Número da Conta")]
        public long NumeroDaConta { get; private set; }

        [DataMember]
        [MaxLength(2, ErrorMessage = "Máximo de 2 digitos")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Dígito Verificador")]
        public string DigitoVerificadorCC { get; private set; }
    }
}
