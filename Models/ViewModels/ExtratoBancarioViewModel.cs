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
    public class ExtratoBancarioViewModel
    {
        public ExtratoBancarioViewModel()
        {
        }

        public ExtratoBancarioViewModel(Usuario usuario)
        {
            Usuario = usuario;
        }

        public ExtratoBancarioViewModel(Usuario usuario, ContaCorrente contaCorrente)
        {
            Usuario = usuario;
            ContaCorrente = contaCorrente;
        }

        public ExtratoBancarioViewModel(Usuario usuario, List<ContaCorrente> contasCorrentes, List<Filial> filiais, List<Banco> bancos)
        {
            Usuario = usuario;
            ContasCorrentes = contasCorrentes;
            Bancos = bancos;
            Filiais = filiais;
        }

        public Usuario Usuario { get; private set; }

        public ContaCorrente ContaCorrente { get; private set; }
        public List<ContaCorrente> ContasCorrentes { get; private set; }
        public List<Banco> Bancos { get; private set; }
        public List<Filial> Filiais { get; private set; }

        public DateTime DataInicial { get; set; } = DateTime.Now.AddMonths(-1).Date;
        public DateTime DataFinal { get; set; } = DateTime.Now.Date;

        public IEnumerable<MovimentoBancario> Movimentos { get; set; }

        [DataType(DataType.Currency)]
        public double Variacao { get; set; } = 0;
        [DataType(DataType.Currency)]
        public double SaldoAtualizado { get; set; }
        [DataType(DataType.Currency)]
        public double SaldoFinal { get; set; } = 0;
        [DataType(DataType.Currency)]
        public double SaldoInicial { get; set; }

        public int BancoIdd { get; set; }
        public int FilialIdd { get; set; }
        public List<ContaCorrente> ContasCorrentesDB { get; set; }

    }
}
