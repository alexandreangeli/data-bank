using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoDataCoper.Models;
using BancoDataCoper.Models.ViewModels;
using BancoDataCoper.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BancoDataCoper.Controllers
{
    [Authorize]
    public class FiliaisController : Controller
    {
        private readonly IFilialRepository filialRepository;
        private readonly IEmpresaRepository empresaRepository;
        private readonly IPessoaJuridicaRepository pessoaJuridicaRepository;
        private readonly ApplicationContext contexto;

        public FiliaisController(IFilialRepository filialRepository, IEmpresaRepository empresaRepository, IPessoaJuridicaRepository pessoaJuridicaRepository, ApplicationContext contexto)
        {
            this.filialRepository = filialRepository;
            this.empresaRepository = empresaRepository;
            this.pessoaJuridicaRepository = pessoaJuridicaRepository;
            this.contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await filialRepository.GetFiliais());
        }

        public async Task<IActionResult> Details(int id)
        {
            var filial = await filialRepository.GetFilial(id);

            if (filial == null)
            {
                return NotFound();
            }

            return View(filial);
        }

        public async Task<IActionResult> Create()
        {
            var empresas = await empresaRepository.GetEmpresas();
            var empresaSelect = empresas.Where(e => e.Ativo == true).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nome});

            var pessoasJuridicas = await pessoaJuridicaRepository.GetPessoasJuridicas();
            var pessoaJuridicaSelect = pessoasJuridicas.Where(e => e.Ativo == true).Where(e => e.Agencia == null && e.Filial == null).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nome });

            return View(new FilialViewModel() { Empresas = empresaSelect,
                                                PessoasJuridicas = pessoaJuridicaSelect});
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] int SelectedPessoaJuridicaId, [FromForm] int SelectedEmpresaId, [FromForm] long NumeroRegistroNaJuntaComercial, [FromForm] bool Ativo)
        {
            var empresa = await empresaRepository.GetEmpresa(SelectedEmpresaId);
            var pessoaJuridica = await pessoaJuridicaRepository.GetPessoaJuridica(SelectedPessoaJuridicaId);

            if (pessoaJuridica.Agencia != null || pessoaJuridica.Filial != null)
            {
                return RedirectToAction(nameof(Create));
            }

            var newFilial = new Filial(pessoaJuridica, empresa, Ativo, NumeroRegistroNaJuntaComercial);

            contexto.Set<Filial>().Add(newFilial);

            await contexto.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {     
            var filial = await filialRepository.GetFilial(id);
            if (filial == null)
            {
                return NotFound();
            }

            var empresas = await empresaRepository.GetEmpresas();
            var empresaSelect = empresas.Where(e => e.Ativo == true).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nome });

            var pessoasJuridicas = await pessoaJuridicaRepository.GetPessoasJuridicas();
            var pessoaJuridicaSelect = pessoasJuridicas.Where(e => e.Ativo == true).Where(e => (e.Agencia == null && e.Filial == null) || e.Filial == filial).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nome });

            return View(new FilialViewModel(filial)
            {
                Empresas = empresaSelect,
                PessoasJuridicas = pessoaJuridicaSelect
            });
        }

        //public bool CNPJUnica(string cnpj)
        //{
        //    if(cnpj != null)
        //    {
        //        return !contexto.Set<Filial>().Where(f => Format.SemFormatacao(f.CNPJ) == Format.SemFormatacao(cnpj)).Any();

        //    }
        //    return true;
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task UpdateFilial([FromBody]Filial filial)
        {
            var empresas = await empresaRepository.GetEmpresas();
            var pessoasJuridicas = await pessoaJuridicaRepository.GetPessoasJuridicas();

            await filialRepository.UpdateFilial(filial, empresas, pessoasJuridicas);
        }

    }
}
