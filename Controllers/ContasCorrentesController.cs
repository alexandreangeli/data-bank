using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BancoDataCoper.Models;
using BancoDataCoper.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using BancoDataCoper.Models.ViewModels;
using System;
using Microsoft.AspNetCore.Authorization;

namespace BancoDataCoper.Controllers
{
    [Authorize]
    public class ContasCorrentesController : Controller
    {
        private readonly ApplicationContext contexto;
        private readonly IContaCorrenteRepository contaCorrenteRepository;
        private readonly IEmpresaRepository empresaRepository;
        private readonly IFilialRepository filialRepository;
        private readonly IBancoRepository bancoRepository;
        private readonly IAgenciaRepository agenciaRepository;

        public ContasCorrentesController(ApplicationContext contexto, IContaCorrenteRepository contaCorrenteRepository, IEmpresaRepository empresaRepository, IFilialRepository filialRepository, IBancoRepository bancoRepository, IAgenciaRepository agenciaRepository)
        {
            this.contexto = contexto;
            this.contaCorrenteRepository = contaCorrenteRepository;
            this.empresaRepository = empresaRepository;
            this.filialRepository = filialRepository;
            this.bancoRepository = bancoRepository;
            this.agenciaRepository = agenciaRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await contaCorrenteRepository.GetContasCorrentes());
        }

        public async Task<IActionResult> Details(int id)
        {
            var contaCorrente = await contaCorrenteRepository.GetContaCorrente(id);
            if (contaCorrente == null)
            {
                return NotFound();
            }

            return View(contaCorrente);
        }

        public async Task<IActionResult> Create(string bancoId)
        {
            if (bancoId == null)
            {
                var bancosDb = await bancoRepository.GetBancos();
                if (bancosDb.Any())
                {
                    bancoId = bancosDb.FirstOrDefault().Id.ToString();
                }
            }

            var filiais = await filialRepository.GetFiliais();
            var filialSelect = filiais.Where(f => f.Ativo == true).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.PessoaJuridica.Nome });

            var bancos = await bancoRepository.GetBancos();
            var bancoSelect = bancos.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nome });

            var agencias = await agenciaRepository.GetAgencias();
            var agenciaSelect = agencias.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.PessoaJuridica.Nome });

            if (!bancoSelect.Where(e => e.Value == bancoId).Any() && bancoSelect.Any())
            {
                bancoId = bancoSelect.First().Value;
            }

            return View(new ContaCorrenteViewModel()
            {
                Bancos = bancoSelect,
                Agencias = agenciaSelect,
                AgenciasDB = await agenciaRepository.GetAgencias(),
                BancoIdd = bancoId,
                Filiais = filialSelect
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] int SelectedBancoId, [FromForm] int SelectedAgenciaId, [FromForm] int SelectedFilialId, [FromForm] string Descricao, [FromForm] long NumeroDaConta, [FromForm] string DigitoVerificadorCC)
        {
            var banco = await bancoRepository.GetBanco(SelectedBancoId);

            var agencia = await agenciaRepository.GetAgencia(SelectedAgenciaId);

            var filial = await filialRepository.GetFilial(SelectedFilialId);

            var newContaCorrente = new ContaCorrente(banco, agencia, filial, DateTime.Now, Descricao, NumeroDaConta, DigitoVerificadorCC, 0);

            contexto.Set<ContaCorrente>().Add(newContaCorrente);

            await contexto.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id, string bancoId)
        {
            var contaCorrente = await contaCorrenteRepository.GetContaCorrente(id);

            if(contaCorrente.Ativo == false)
            {
                return NotFound();
            }

            if (bancoId == null)
            {
                bancoId = contaCorrente.Agencia.Banco.Id.ToString();
            }

            if (contaCorrente == null)
            {
                return NotFound();
            }

            var bancos = await bancoRepository.GetBancos();
            var bancoSelect = bancos.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nome });

            if(!bancoSelect.Where(e => e.Value == bancoId).Any() && bancoSelect.Any())
            {
                bancoId = bancoSelect.First().Value;
            } 

            var agencias = await agenciaRepository.GetAgencias();
            var agenciaSelect = agencias.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.PessoaJuridica.Nome });

            var filiais = await filialRepository.GetFiliais();
            var filialSelect = filiais.Where(f => f.Ativo == true).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.PessoaJuridica.Nome });

            return View(new ContaCorrenteViewModel(contaCorrente)
            {
                Bancos = bancoSelect,
                Agencias = agenciaSelect,
                AgenciasDB = await agenciaRepository.GetAgencias(),
                BancoIdd = bancoId,
                Filiais = filialSelect
            });
        }

        public async Task<IActionResult> Deactivate(int id)
        {
            var contaCorrente = await contaCorrenteRepository.GetContaCorrente(id);
        
            if (contaCorrente == null)
            {
                return NotFound();
            }

            return View(contaCorrente);
        }

        [HttpPost, ActionName("Deactivate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateConfirmed(int id)
        {
            var contaCorrente = await contaCorrenteRepository.GetContaCorrente(id);

            contaCorrente.AtualizaAtivo(false);
            contaCorrente.AtualizaDataDeEncerramento();

            await contexto.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task UpdateContaCorrente([FromBody]ContaCorrente contaCorrente)
        {
            var bancos = await bancoRepository.GetBancos();
            var filiais = await filialRepository.GetFiliais();
            var agencias = await agenciaRepository.GetAgencias();

            await contaCorrenteRepository.UpdateContaCorrente(contaCorrente, bancos, agencias, filiais);
        }

        //public bool EmailUnico(string email)
        //{
        //    if (email != null)
        //    {
        //        return !contexto.Set<Usuario>().Where(u => u.Email == email).Any();
        //    }
        //    return true;
        //}
    }
}
  