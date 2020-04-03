using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BancoDataCoper.Models;
using BancoDataCoper.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using BancoDataCoper.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using Microsoft.AspNetCore.Authorization;

namespace BancoDataCoper.Controllers
{    
    public class UsuariosController : Controller
    {
        private readonly ApplicationContext contexto;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IEmpresaRepository empresaRepository;
        private readonly IFilialRepository filialRepository;
        private readonly IPessoaFisicaRepository pessoaFisicaRepository;
        private readonly IPostoDeCaixaRepository postoDeCaixaRepository;

        public UsuariosController(ApplicationContext contexto, IUsuarioRepository usuarioRepository, IEmpresaRepository empresaRepository, IFilialRepository filialRepository, IPessoaFisicaRepository pessoaFisicaRepository, IPostoDeCaixaRepository postoDeCaixaRepository)
        {
            this.contexto = contexto;
            this.usuarioRepository = usuarioRepository;
            this.empresaRepository = empresaRepository;
            this.filialRepository = filialRepository;
            this.pessoaFisicaRepository = pessoaFisicaRepository;
            this.postoDeCaixaRepository = postoDeCaixaRepository;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await usuarioRepository.GetUsuarios());
        }

        public async Task<IActionResult> Details(int id)
        {
            var usuario = await usuarioRepository.GetUsuario(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        public async Task<IActionResult> Create(string empresaId)
        {
            if (empresaId == null)
            {
                var empresasDb = await empresaRepository.GetEmpresas();
                if (empresasDb.Any())
                {
                    empresaId = empresasDb.FirstOrDefault().Id.ToString();
                }
            }

            var empresas = await empresaRepository.GetEmpresas();
            var empresaSelect = empresas.Where(e => e.Ativo == true).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nome });

            var filiais = await filialRepository.GetFiliais();
            var filialSelect = filiais.Where(f => f.Ativo == true).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.PessoaJuridica.Nome });

            var pessoasFisicas = await pessoaFisicaRepository.GetPessoasFisicas();
            var pessoasFisicasSelect = pessoasFisicas.Where(f => f.Ativo == true).Where(e => e.Usuario == null).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nome });


            if (!empresaSelect.Where(e => e.Value == empresaId).Any() && empresaSelect.Any())
            {
                empresaId = empresaSelect.First().Value;
            }

            return View(new UsuarioViewModel()
            {
                Empresas = empresaSelect,
                Filiais = filialSelect,
                FiliaisDB = await filialRepository.GetFiliais(),
                EmpresaIdd = empresaId,
                PessoasFisicas = pessoasFisicasSelect
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] int SelectedEmpresaId, [FromForm] int SelectedFilialId, [FromForm] int SelectedPessoaFisicaId, [FromForm] string Email, [FromForm] long Celular, [FromForm] string Senha, [FromForm] bool Ativo)
        {
            var empresa = await empresaRepository.GetEmpresa(SelectedEmpresaId);

            var filial = await filialRepository.GetFilial(SelectedFilialId);

            var pessoaFisica = await pessoaFisicaRepository.GetPessoaFisica(SelectedPessoaFisicaId);

            if (pessoaFisica.Usuario != null)
            {
                return RedirectToAction(nameof(Create));
            }

            var newUsuario = new Usuario(empresa, filial, pessoaFisica, Email, Celular, Senha, Ativo);

            contexto.Set<Usuario>().Add(newUsuario);

            await contexto.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id, string empresaId)
        {
            var usuario = await usuarioRepository.GetUsuario(id);

            if (empresaId == null)
            {
                empresaId = usuario.Filial.Empresa.Id.ToString();
            }

            if (usuario == null)
            {
                return NotFound();
            }
            var empresas = await empresaRepository.GetEmpresas();
            var empresaSelect = empresas.Where(e => e.Ativo == true).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nome });

            if (!empresaSelect.Where(e => e.Value == empresaId).Any() && empresaSelect.Any())
            {
                empresaId = empresaSelect.First().Value;
            }

            var filiais = await filialRepository.GetFiliais();
            var filialSelect = filiais.Where(f => f.Ativo == true).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.PessoaJuridica.Nome });

            var pessoasFisicas = await pessoaFisicaRepository.GetPessoasFisicas();
            var pessoasFisicasSelect = pessoasFisicas.Where(f => f.Ativo == true).Where(e => (e.Usuario == null) || (e.Usuario == usuario)).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nome });

            return View(new UsuarioViewModel(usuario)
            {
                Empresas = empresaSelect,
                Filiais = filialSelect,
                FiliaisDB = await filialRepository.GetFiliais(),
                EmpresaIdd = empresaId,
                PessoasFisicas = pessoasFisicasSelect
            });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await usuarioRepository.GetUsuario(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await contexto.Set<Usuario>().FindAsync(id);
            contexto.Set<Usuario>().Remove(usuario);
            await contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task UpdateUsuario([FromBody]Usuario usuario)
        {
            var empresas = await empresaRepository.GetEmpresas();
            var filiais = await filialRepository.GetFiliais();
            var pessoasFisicas = await pessoaFisicaRepository.GetPessoasFisicas();
            
            await usuarioRepository.UpdateUsuario(usuario, empresas, filiais, pessoasFisicas);


        }
        public bool EmailUnico(string email)
        {
            if (email != null)
            {
                return !contexto.Set<Usuario>().Where(u => u.Email == email).Any();
            }
            return true;
        }
        //Login


        //======================================================>
        public IActionResult Login()
        {
            if (string.IsNullOrEmpty(Request.QueryString.ToString()))
            {
                return View();
            }
            var returnUrl = Request.QueryString.ToString().Replace("%2F","/").Remove(0,11);
            return View((object)returnUrl);

        }
        public IActionResult Relogin()
        {

            return View();


        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] string returnUrl, [FromForm]string email, [FromForm]string password)
        {            
            var users = contexto.Set<Usuario>().Where(u => u.Ativo == true).ToList(); ;

            if (users.Where(u => u.Email == email && u.Senha.ToString() == password).Any())
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, email)
        };
                var userIdentity = new ClaimsIdentity(claims, "SecureLogin");
                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    userPrincipal,
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                        IsPersistent = false,
                        AllowRefresh = false
                    });

                return GoToReturnUrl(returnUrl);
            }

            return RedirectToAction("Relogin", "Usuarios");
        }

        private IActionResult GoToReturnUrl(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("InicioLogado", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Inicio", "Home");
        }
        //https://jonhilton.net/2017/10/07/a-simple-way-to-secure-your-.net-core-2.0-web-app/

    }
}