using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataBank.Models;
using DataBank.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DataBank.Controllers
{
    [Authorize]
    public class BancosController : Controller
    {
        private readonly ApplicationContext contexto;
        private readonly IBancoRepository bancoRepository;

        public BancosController(ApplicationContext contexto, IBancoRepository bancoRepository)
        {
            this.contexto = contexto;
            this.bancoRepository = bancoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var bancos = await bancoRepository.GetBancos();
            return View(bancos);
        }

        public async Task<IActionResult> Details(int id)
        {
            var banco = await bancoRepository.GetBanco(id);

            if (banco == null)
            {
                return NotFound();
            }

            return View(banco);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] string Nome, [FromForm] string Codigo)
        {
            var newBanco = new Banco(Nome, Codigo);

            contexto.Set<Banco>().Add(newBanco);

            await contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {            
            var banco = await bancoRepository.GetBanco(id);

            if (banco == null)
            {
                return NotFound();
            }

            return View(banco);
        }        

        public async Task<IActionResult> Delete(int id)
        {
            var banco = await bancoRepository.GetBanco(id);

            if (banco == null)
            {
                return NotFound();
            }

            return View(banco);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banco = await bancoRepository.GetBanco(id);

            contexto.Set<Banco>().Remove(banco);

            await contexto.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task UpdateBanco([FromBody]Banco banco)
        {
            await bancoRepository.UpdateBanco(banco);
        }

        public bool CodigoUnico(string codigo)
        {
            return !contexto.Set<Banco>().Where(b => b.Codigo == codigo).Any();
        }
    }
}
