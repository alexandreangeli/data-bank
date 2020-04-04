using System;
using System.Linq;
using System.Threading.Tasks;
using DataBank.Models.ViewModels;
using DataBank.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DataBank.Controllers
{
    public class ExtratoBancarioController : Controller
    {
        private readonly IFilialRepository filialRepository;
        private readonly IEmpresaRepository empresaRepository;
        private readonly IPessoaJuridicaRepository pessoaJuridicaRepository;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IContaCorrenteRepository contaCorrenteRepository;
        private readonly IBancoRepository bancoRepository;
        private readonly IMovimentoBancarioRepository movimentoBancarioRepository;
        private readonly ApplicationContext contexto;

        public ExtratoBancarioController(IFilialRepository filialRepository, IEmpresaRepository empresaRepository, IPessoaJuridicaRepository pessoaJuridicaRepository, IUsuarioRepository usuarioRepository, IContaCorrenteRepository contaCorrenteRepository, IBancoRepository bancoRepository, IMovimentoBancarioRepository movimentoBancarioRepository, ApplicationContext contexto)
        {
            this.filialRepository = filialRepository;
            this.empresaRepository = empresaRepository;
            this.pessoaJuridicaRepository = pessoaJuridicaRepository;
            this.usuarioRepository = usuarioRepository;
            this.contaCorrenteRepository = contaCorrenteRepository;
            this.bancoRepository = bancoRepository;
            this.movimentoBancarioRepository = movimentoBancarioRepository;
            this.contexto = contexto;
        }

        [Authorize]
        public async Task<IActionResult> InicioExtrato(int bancoId, int filialId)
        {
            var usuario = await usuarioRepository.GetUsuario(User.Identity.Name);

            if (usuario.Email != "admin")
            {
                return View(new ExtratoBancarioViewModel(usuario));
            }

            var contasCorrentes = await contaCorrenteRepository.GetContasCorrentes();
            var bancos = await bancoRepository.GetBancos();
            var filiais = await filialRepository.GetFiliais();

            if (bancoId == 0)
            {
                bancoId = bancos.Where(b => b.Id != 1).FirstOrDefault().Id;
            }

            if (filialId == 0)
            {
                filialId = filiais.Where(b => b.Id != 1).FirstOrDefault().Id;
            }

            return View(new ExtratoBancarioViewModel(usuario, contasCorrentes, filiais, bancos)
            {
                ContasCorrentesDB = await contaCorrenteRepository.GetContasCorrentes(),
                FilialIdd = filialId,
                BancoIdd = bancoId
            });
        }
        public async Task<IActionResult> Extrato([FromForm] int ContaCorrenteId, [FromForm] DateTime dataInicial, [FromForm]DateTime dataFinal)
        {
            var usuario = await usuarioRepository.GetUsuario(User.Identity.Name);

            var contaCorrente = await contaCorrenteRepository.GetContaCorrente(ContaCorrenteId);

            var movimentos = await movimentoBancarioRepository.GetMovimentosBancarios();
            var movimentosDaConta = movimentos.Where(m => m.ContaCorrente == contaCorrente);
            var movimentosAteDataFinal = movimentosDaConta.Where(m => m.Data <= dataFinal.Date.AddDays(1));
            var movimentosNoPeriodo = movimentosDaConta.Where(m => m.Data <= dataFinal.Date.AddDays(1) && m.Data >= dataInicial);

            var extrato = new ExtratoBancarioViewModel(usuario, contaCorrente);

            foreach (var movimento in movimentosAteDataFinal)
            {
                if ((movimento.Tipo == "Saque" || movimento.Tipo == "Envia Transferência") && movimento.Ativo == true)
                {
                    extrato.SaldoFinal -= movimento.Valor;
                }
                else if ((movimento.Tipo == "Depósito" || movimento.Tipo == "Recebe Transferência") && movimento.Ativo == true)
                {
                    extrato.SaldoFinal += movimento.Valor;
                }
            }

            extrato.SaldoInicial = extrato.SaldoFinal;

            foreach (var movimento in movimentosNoPeriodo)
            {
                if ((movimento.Tipo == "Saque" || movimento.Tipo == "Envia Transferência") && movimento.Ativo == true)
                {
                    extrato.SaldoInicial += movimento.Valor;
                }
                else if ((movimento.Tipo == "Depósito" || movimento.Tipo == "Recebe Transferência") && movimento.Ativo == true)
                {
                    extrato.SaldoInicial -= movimento.Valor;
                }
            }

            extrato.DataInicial = dataInicial;
            extrato.DataFinal = dataFinal;
            extrato.Movimentos = movimentosNoPeriodo;

            return View(extrato);
        }
    }
}