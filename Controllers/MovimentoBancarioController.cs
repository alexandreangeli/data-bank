using System;
using System.Linq;
using System.Threading.Tasks;
using Databank.Models;
using Databank.Models.ViewModels;
using Databank.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Databank.Controllers
{
    [Authorize]
    public class MovimentoBancarioController : Controller
    {
        private readonly IFilialRepository filialRepository;
        private readonly IEmpresaRepository empresaRepository;
        private readonly IPessoaJuridicaRepository pessoaJuridicaRepository;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IContaCorrenteRepository contaCorrenteRepository;
        private readonly IBancoRepository bancoRepository;
        private readonly IMovimentoBancarioRepository movimentoBancarioRepository;
        private readonly ApplicationContext contexto;

        public MovimentoBancarioController(IFilialRepository filialRepository, IEmpresaRepository empresaRepository, IPessoaJuridicaRepository pessoaJuridicaRepository, IUsuarioRepository usuarioRepository, IContaCorrenteRepository contaCorrenteRepository, IBancoRepository bancoRepository, IMovimentoBancarioRepository movimentoBancarioRepository, ApplicationContext contexto)
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

        public async Task<IActionResult> InicioLancamento([FromForm] bool Adicionar)
        {
            var usuario = await usuarioRepository.GetUsuario(User.Identity.Name);

            return View(new MovimentoBancarioViewModel(usuario));
        }

        public async Task<IActionResult> DigitarConta()
        {
            var usuario = await usuarioRepository.GetUsuario(User.Identity.Name);

            return View(new MovimentoBancarioViewModel(usuario));
        }
        [HttpPost]
        public async Task<IActionResult> DigitarConta([FromForm] long contaCorrente, [FromForm] string DigitoVerificadorCC)
        {
            var usuario = await usuarioRepository.GetUsuario(User.Identity.Name);

            var ContasCorrentesDB = contexto.Set<ContaCorrente>().Include(u => u.Filial).Where(u => u.NumeroDaConta == contaCorrente).ToList();

            if (usuario.Email == "admin")
            {
                if (ContasCorrentesDB.Count() == 1 && ContasCorrentesDB.FirstOrDefault().DigitoVerificadorCC == DigitoVerificadorCC)
                {
                    return RedirectToAction("TipoDeMovimento", new { ContaCorrenteId = ContasCorrentesDB.FirstOrDefault().Id });
                }
            }
            else
            {
                if (usuario.PostosDeCaixa.Where(u => u.Ativo == true).Where(u => u.ContaCorrente == ContasCorrentesDB.FirstOrDefault()).Any())
                {
                    if (ContasCorrentesDB.Count() == 1 && ContasCorrentesDB.FirstOrDefault().Filial == usuario.Filial && ContasCorrentesDB.FirstOrDefault().DigitoVerificadorCC == DigitoVerificadorCC)
                    {
                        return RedirectToAction("TipoDeMovimento", new { ContaCorrenteId = ContasCorrentesDB.FirstOrDefault().Id });
                    }
                }
            }

            return RedirectToAction(nameof(SelecionarConta));

        }

        public async Task<IActionResult> SelecionarConta(int bancoId, int filialId)
        {
            var usuario = await usuarioRepository.GetUsuario(User.Identity.Name);

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

            return View(new MovimentoBancarioViewModel(usuario, contasCorrentes, filiais, bancos)
            {
                ContasCorrentesDB = await contaCorrenteRepository.GetContasCorrentes(),
                FilialIdd = filialId,
                BancoIdd = bancoId
            });
        }
        [HttpPost]
        public async Task<IActionResult> SelecionarConta([FromForm] int ContaCorrenteId)
        {
            var ContaCorrente = await contaCorrenteRepository.GetContaCorrente(ContaCorrenteId);
            return RedirectToAction("TipoDeMovimento", new { ContaCorrenteId = ContaCorrente.Id });
        }

        public async Task<IActionResult> TipoDeMovimento(int ContaCorrenteId)
        {
            var usuario = await usuarioRepository.GetUsuario(User.Identity.Name);

            var contaCorrente = await contaCorrenteRepository.GetContaCorrente(ContaCorrenteId);

            if(usuario.Email == "admin" && contaCorrente.Ativo == true)
            {
                return View(new MovimentoBancarioViewModel(usuario, contaCorrente));
            }

            if (usuario.Filial.ContasCorrentes.Where(u => u.Id == ContaCorrenteId).FirstOrDefault() == null
                || usuario.Filial.ContasCorrentes.Where(u => u.Id == ContaCorrenteId).FirstOrDefault().Ativo == false)
            {
                return RedirectToAction(nameof(SelecionarConta));
            }

            return View(new MovimentoBancarioViewModel(usuario, contaCorrente));
        }

        [HttpPost]
        public async Task<IActionResult> Saque([FromForm] int ContaCorrenteId, [FromForm] string tipo)
        {
            var usuario = await usuarioRepository.GetUsuario(User.Identity.Name);

            var contaCorrente = await contaCorrenteRepository.GetContaCorrente(ContaCorrenteId);

            return View(new MovimentoBancarioViewModel(usuario, contaCorrente)
            {
                Tipo = tipo
            });
        }

        [HttpPost]
        public async Task<IActionResult> Deposito([FromForm] int ContaCorrenteId, [FromForm] string tipo)
        {
            var usuario = await usuarioRepository.GetUsuario(User.Identity.Name);

            var contaCorrente = await contaCorrenteRepository.GetContaCorrente(ContaCorrenteId);

            return View(new MovimentoBancarioViewModel(usuario, contaCorrente)
            {
                Tipo = tipo
            });
        }

        public async Task<IActionResult> Transferencia(int ContaCorrenteId, string tipo, int filialId)
        {
            var usuario = await usuarioRepository.GetUsuario(User.Identity.Name);

            var contaCorrente = await contaCorrenteRepository.GetContaCorrente(ContaCorrenteId);

            return View(new MovimentoBancarioViewModel(usuario, contaCorrente)
            {
                Tipo = tipo,
                ContasCorrentesDB = await contaCorrenteRepository.GetContasCorrentes(),
                FilialIdd = filialId,
                FiliaisDB = await filialRepository.GetFiliais()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Transferencia([FromForm] int ContaCorrenteId, [FromForm] string tipo)
        {
            var filiaisDb = await filialRepository.GetFiliais();

            var usuario = await usuarioRepository.GetUsuario(User.Identity.Name);

            int filialId;

            if (usuario.Email == "admin")
            {
                filialId = filiaisDb.FirstOrDefault().Id;

            }
            else
            {
                filialId = filiaisDb.Where(f => f.Empresa == usuario.Empresa).FirstOrDefault().Id;
            }

            var contaCorrente = await contaCorrenteRepository.GetContaCorrente(ContaCorrenteId);

            return View(new MovimentoBancarioViewModel(usuario, contaCorrente)
            {
                Tipo = tipo,
                ContasCorrentesDB = await contaCorrenteRepository.GetContasCorrentes(),
                FilialIdd = filialId,
                FiliaisDB = await filialRepository.GetFiliais()
            });
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmarMovimento([FromForm] int ContaCorrenteId, [FromForm] double Valor, [FromForm] string tipo, [FromForm] bool cheque, [FromForm] int ContaCorrenteDestinoId)
        {
            var usuario = await usuarioRepository.GetUsuario(User.Identity.Name);


            var contaCorrente = await contaCorrenteRepository.GetContaCorrente(ContaCorrenteId);

            var contaCorrenteDestino = await contaCorrenteRepository.GetContaCorrente(ContaCorrenteDestinoId);


            var movimentoBancario = new MovimentoBancario(contaCorrente, usuario.Email, Valor, tipo, DateTime.Now, cheque, contaCorrenteDestino, contaCorrente);

            return View(new MovimentoBancarioViewModel(usuario, contaCorrente, movimentoBancario));
        }

        [HttpPost]
        public async Task<IActionResult> MovimentoConfirmado([FromForm] int ContaCorrenteId, [FromForm] double Valor, [FromForm] string tipo, [FromForm] bool cheque, [FromForm] int ContaCorrenteDestinoId)
        {
            var usuario = await usuarioRepository.GetUsuario(User.Identity.Name);

            var contaCorrente = await contaCorrenteRepository.GetContaCorrente(ContaCorrenteId);

            var contaCorrenteDestino = await contaCorrenteRepository.GetContaCorrente(ContaCorrenteDestinoId);

            MovimentoBancario movimentoBancarioGet;
            MovimentoBancario movimentoBancario;

            if (tipo == "saque")
            {
                if (contaCorrente.Saldo >= Valor)
                {
                    var saldo = contaCorrente.Saldo - Valor;
                    contaCorrente.AtualizaSaldo(saldo);
                    movimentoBancario = new MovimentoBancario(contaCorrente, usuario.Email, Valor, "Saque", DateTime.Now, cheque, contaCorrenteDestino, null);
                    contexto.Set<MovimentoBancario>().Add(movimentoBancario);

                }
                else
                {
                    return NotFound();
                }
            }

            if (tipo == "deposito")
            {
                var saldo = contaCorrente.Saldo + Valor;
                contaCorrente.AtualizaSaldo(saldo);
                movimentoBancario = new MovimentoBancario(contaCorrente, usuario.Email, Valor, "Depósito", DateTime.Now, cheque, contaCorrenteDestino, null);
                contexto.Set<MovimentoBancario>().Add(movimentoBancario);

            }

            if (tipo == "transferencia")
            {
                if (contaCorrente.Saldo >= Valor)
                {
                    var saldoSend = contaCorrente.Saldo - Valor;
                    contaCorrente.AtualizaSaldo(saldoSend);

                    var saldoGet = contaCorrenteDestino.Saldo + Valor;
                    contaCorrenteDestino.AtualizaSaldo(saldoGet);

                    movimentoBancario = new MovimentoBancario(contaCorrente, usuario.Email, Valor, "Envia Transferência", DateTime.Now, cheque, contaCorrenteDestino, contaCorrente);

                    movimentoBancarioGet = new MovimentoBancario(contaCorrenteDestino, usuario.Email, Valor, "Recebe Transferência", DateTime.Now, cheque, contaCorrenteDestino, contaCorrente);

                    contexto.Set<MovimentoBancario>().Add(movimentoBancario);

                    contexto.Set<MovimentoBancario>().Add(movimentoBancarioGet);

                }
                else
                {
                    return NotFound();
                }
            }

            await contexto.SaveChangesAsync();

            return RedirectToAction(nameof(InicioLancamento));
        }

        public async Task<IActionResult> EstornoLancamento(int bancoId, int filialId)
        {
            var usuario = await usuarioRepository.GetUsuario(User.Identity.Name);

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

            return View(new MovimentoBancarioViewModel(usuario, contasCorrentes, filiais, bancos)
            {
                ContasCorrentesDB = await contaCorrenteRepository.GetContasCorrentes(),
                FilialIdd = filialId,
                BancoIdd = bancoId
            });
        }

        public async Task<IActionResult> ExibirMovimentos([FromForm] int ContaCorrenteId, [FromForm] DateTime Data)
        {
            var MovimentosDB = await movimentoBancarioRepository.GetMovimentosBancarios();
            var MovimentosConta = MovimentosDB.Where(m => m.ContaCorrente.Id == ContaCorrenteId).ToList();
            var MovimentosContaData = MovimentosConta.Where(m => m.Data.ToShortDateString() == Data.ToShortDateString()).ToList();

            var usuario = await usuarioRepository.GetUsuario(User.Identity.Name);

            var contaCorrente = await contaCorrenteRepository.GetContaCorrente(ContaCorrenteId);

            if (Data == DateTime.MinValue)
            {
                return View(new MovimentoBancarioViewModel(usuario, contaCorrente, Data)
                {
                    Movimentos = MovimentosConta
                });
            }

            return View(new MovimentoBancarioViewModel(usuario, contaCorrente, Data)
            {
                Movimentos = MovimentosContaData
            });
        }

        public async Task<IActionResult> ConfirmarEstorno(int movimentoId)
        {
            var movimentoBancario = await movimentoBancarioRepository.GetMovimentoBancario(movimentoId);

            return View(movimentoBancario);
        }

        public async Task<IActionResult> EstornoConfirmado(int ContaCorrenteId, int MovimentoId)
        {
            var usuario = await usuarioRepository.GetUsuario(User.Identity.Name);

            var contaCorrente = await contaCorrenteRepository.GetContaCorrente(ContaCorrenteId);

            var movimentoBancario = await movimentoBancarioRepository.GetMovimentoBancario(MovimentoId);


            if (movimentoBancario.Tipo == "Saque")
            {
                var novoSaldo = contaCorrente.Saldo + movimentoBancario.Valor;
                contaCorrente.AtualizaSaldo(novoSaldo);
            }
            if (movimentoBancario.Tipo == "Depósito")
            {
                var novoSaldo = contaCorrente.Saldo - movimentoBancario.Valor;
                contaCorrente.AtualizaSaldo(novoSaldo);
            }
            if (movimentoBancario.Tipo == "Envia Transferência")
            {
                var novoSaldo = contaCorrente.Saldo + movimentoBancario.Valor;
                contaCorrente.AtualizaSaldo(novoSaldo);


                var movimentoBancarioGet = await movimentoBancarioRepository.GetMovimentoBancario(MovimentoId + 1);

                var novoSaldoGet = movimentoBancarioGet.ContaCorrente.Saldo - movimentoBancario.Valor;
                movimentoBancarioGet.ContaCorrente.AtualizaSaldo(novoSaldoGet);

                movimentoBancarioGet.AtualizaAtivo(false);
            }
            if (movimentoBancario.Tipo == "Recebe Transferência")
            {
                var novoSaldo = contaCorrente.Saldo - movimentoBancario.Valor;
                contaCorrente.AtualizaSaldo(novoSaldo);

                var movimentoBancarioSend = await movimentoBancarioRepository.GetMovimentoBancario(MovimentoId - 1);

                var novoSaldoSend = movimentoBancarioSend.ContaCorrente.Saldo + movimentoBancario.Valor;
                movimentoBancarioSend.ContaCorrente.AtualizaSaldo(novoSaldoSend);

                movimentoBancarioSend.AtualizaAtivo(false);
            }

            movimentoBancario.AtualizaAtivo(false);

            await contexto.SaveChangesAsync();

            return RedirectToAction(nameof(EstornoLancamento));
        }
    }
}