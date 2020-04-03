using System.Linq;
using System.Threading.Tasks;
using Databank.Models;
using Databank.Models.ViewModels;
using Databank.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Databank.Controllers
{
    [Authorize]
    public class AgenciasController : Controller
    {
        private readonly IAgenciaRepository agenciaRepository;
        private readonly IBancoRepository bancoRepository;
        private readonly IPessoaJuridicaRepository pessoaJuridicaRepository;
        private readonly ApplicationContext contexto;

        public AgenciasController(IAgenciaRepository agenciaRepository, IBancoRepository bancoRepository, IPessoaJuridicaRepository pessoaJuridicaRepository, ApplicationContext contexto)
        {
            this.agenciaRepository = agenciaRepository;
            this.bancoRepository = bancoRepository;
            this.pessoaJuridicaRepository = pessoaJuridicaRepository;
            this.contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await agenciaRepository.GetAgencias());
        }

        public async Task<IActionResult> Details(int id)
        {
            var agencia = await agenciaRepository.GetAgencia(id);

            if (agencia == null)
            {
                return NotFound();
            }

            return View(agencia);
        }

        public async Task<IActionResult> Create()
        {
            var bancos = await bancoRepository.GetBancos();
            var bancoSelect = bancos.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nome});

            var pessoasJuridicas = await pessoaJuridicaRepository.GetPessoasJuridicas();
            var pessoaJuridicaSelect = pessoasJuridicas.Where(e => e.Ativo == true).Where(e => e.Agencia == null && e.Filial == null).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nome });

            return View(new AgenciaViewModel() { Bancos = bancoSelect,
                                                 PessoasJuridicas = pessoaJuridicaSelect});
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] int SelectedBancoId, [FromForm] int SelectedPessoaJuridicaId, [FromForm] int Codigo, [FromForm] int DigitoVerificador)
        {
            var banco = await bancoRepository.GetBanco(SelectedBancoId);
            var pessoaJuridica = await pessoaJuridicaRepository.GetPessoaJuridica(SelectedPessoaJuridicaId);

            if (pessoaJuridica.Agencia != null || pessoaJuridica.Filial != null)
            {
                return RedirectToAction(nameof(Create));
            }

            var newAgencia = new Agencia(pessoaJuridica, banco, Codigo, DigitoVerificador);


            contexto.Set<Agencia>().Add(newAgencia);

            await contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {     
            var agencia = await agenciaRepository.GetAgencia(id);
            if (agencia == null)
            {
                return NotFound();
            }
            var bancos = await bancoRepository.GetBancos();
            var bancoSelect = bancos.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nome });

            var pessoasJuridicas = await pessoaJuridicaRepository.GetPessoasJuridicas();
            var pessoaJuridicaSelect = pessoasJuridicas.Where(e => e.Ativo == true).Where(e => (e.Agencia == null && e.Filial == null) || e.Agencia == agencia).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nome });

            return View(new AgenciaViewModel(agencia)
            {
                Bancos = bancoSelect,
                PessoasJuridicas = pessoaJuridicaSelect
            });
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task UpdateAgencia([FromBody]Agencia agencia)
        {
            var bancos = await bancoRepository.GetBancos();
            var pessoasJuridicas = await pessoaJuridicaRepository.GetPessoasJuridicas();
            await agenciaRepository.UpdateAgencia(agencia, bancos, pessoasJuridicas);
        }

    }
}
 