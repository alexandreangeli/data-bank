using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataBank.Models;
using DataBank.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace DataBank.Controllers
{
    [Authorize]
    public class EmpresasController : Controller
    {
        private readonly ApplicationContext contexto;
        private readonly IEmpresaRepository empresaRepository;

        public EmpresasController(ApplicationContext contexto, IEmpresaRepository empresaRepository)
        {
            this.contexto = contexto;
            this.empresaRepository = empresaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var empresas = await empresaRepository.GetEmpresas();            

            return View(empresas);
        }

        public async Task<IActionResult> Details(int id)
        {
            var empresa = await empresaRepository.GetEmpresa(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] string Nome, [FromForm] string Sigla, [FromForm] bool Ativo)
        {
            var newEmpresa = new Empresa(Nome, Sigla, Ativo);

            contexto.Set<Empresa>().Add(newEmpresa);

            await contexto.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var empresa = await empresaRepository.GetEmpresa(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }        

        public async Task<IActionResult> Delete(int id)
        {
            var Empresa = await empresaRepository.GetEmpresa(id);
            
            if (Empresa == null || Empresa.Filiais.Any())
            {
                return NotFound();
            }

            return View(Empresa);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresa = await empresaRepository.GetEmpresa(id);

            contexto.Set<Empresa>().Remove(empresa);

            await contexto.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task UpdateEmpresa([FromBody]Empresa Empresa)
        {
            await empresaRepository.UpdateEmpresa(Empresa);
        }
    }
}
