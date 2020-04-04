using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataBank.Models;
using DataBank.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataBank.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace DataBank.Controllers
{
    [Authorize]
    public class PostosDeCaixaController : Controller
    {
        private readonly ApplicationContext contexto;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IEmpresaRepository empresaRepository;
        private readonly IFilialRepository filialRepository;
        private readonly IPessoaFisicaRepository pessoaFisicaRepository;
        private readonly IContaCorrenteRepository contaCorrenteRepository;
        private readonly IPostoDeCaixaRepository postoDeCaixaRepository;

        public PostosDeCaixaController(ApplicationContext contexto, IUsuarioRepository usuarioRepository, IEmpresaRepository empresaRepository, IFilialRepository filialRepository, IPessoaFisicaRepository pessoaFisicaRepository, IContaCorrenteRepository contaCorrenteRepository, IPostoDeCaixaRepository postoDeCaixaRepository)
        {
            this.contexto = contexto;
            this.usuarioRepository = usuarioRepository;
            this.empresaRepository = empresaRepository;
            this.filialRepository = filialRepository;
            this.pessoaFisicaRepository = pessoaFisicaRepository;
            this.contaCorrenteRepository = contaCorrenteRepository;
            this.postoDeCaixaRepository = postoDeCaixaRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await postoDeCaixaRepository.GetPostosDeCaixa());
        }

        public async Task<IActionResult> Details(int id)
        {
            var postoDeCaixa = await postoDeCaixaRepository.GetPostoDeCaixa(id);
            if (postoDeCaixa == null)
            {
                return NotFound();
            }

            return View(postoDeCaixa);
        }

        public async Task<IActionResult> Create(string filialId, string usuarioId)
        {
            if (filialId == null)
            {
                var filiaisDb = await filialRepository.GetFiliais();
                if (filiaisDb.Any())
                {
                    filialId = filiaisDb.FirstOrDefault().Id.ToString();
                }
            }

            if (usuarioId == null)
            {
                var usuariosDb = await filialRepository.GetFiliais();
                if (usuariosDb.Any())
                {
                    usuarioId = usuariosDb.FirstOrDefault().Id.ToString();
                }
            }

            var filiais = await filialRepository.GetFiliais();
            var filialSelect = filiais.Where(f => f.Ativo == true).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.PessoaJuridica.Nome });

            var usuarios = await usuarioRepository.GetUsuarios();
            var usuariosAtivos = usuarios.Where(u => u.Ativo == true).ToList();
            var usuarioSelect = usuariosAtivos.Where(e => e.Ativo == true).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Email });

            var contaCorrente = await contaCorrenteRepository.GetContasCorrentes();
            var contaCorrentesAtivas = contaCorrente.Where(c => c.Ativo == true).ToList();
            var contaCorrenteSelect = contaCorrentesAtivas.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.NumeroDaConta.ToString() + " " + x.DigitoVerificadorCC.ToString() });

            if (!filialSelect.Where(e => e.Value == filialId).Any() && filialSelect.Any())
            {
                filialId = filialSelect.First().Value;
            }

            if (filiais.Where(f => f.Id.ToString() == filialId).FirstOrDefault().Usuarios.Any())
            {
                if (!filiais.Where(f => f.Id.ToString() == filialId).FirstOrDefault().Usuarios.Where(u => u.Id.ToString() == usuarioId).Any())
                {
                    usuarioId = filiais.Where(f => f.Id.ToString() == filialId).FirstOrDefault().Usuarios.FirstOrDefault().Id.ToString();
                }
            }

            var contasAtivas = await contaCorrenteRepository.GetContasCorrentes();

            return View(new PostoDeCaixaViewModel()
            {
                Filiais = filialSelect,
                Usuarios = usuarioSelect,
                UsuariosDB = await usuarioRepository.GetUsuarios(),
                ContasCorrentes = contaCorrenteSelect,
                ContasCorrentesDB = contasAtivas.Where(c => c.Ativo == true).ToList(),
                FilialIdd = filialId,
                UsuarioIdd = usuarioId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] int SelectedFilialId, [FromForm] int SelectedUsuarioId, [FromForm] int SelectedContaCorrenteId, [FromForm] string nome, [FromForm] bool Ativo)
        {
            var filial = await filialRepository.GetFilial(SelectedFilialId);

            var contaCorrente = await contaCorrenteRepository.GetContaCorrente(SelectedContaCorrenteId);

            var usuario = await usuarioRepository.GetUsuario(SelectedUsuarioId);

            var CodigoDoPosto = filial.PostosDeCaixa.Count() + 1;

            var newPostoDeCaixa = new PostoDeCaixa(filial, usuario, contaCorrente, CodigoDoPosto, nome, Ativo);

            contexto.Set<PostoDeCaixa>().Add(newPostoDeCaixa);

            await contexto.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id, string filialId)
        {
            var postoDeCaixa = await postoDeCaixaRepository.GetPostoDeCaixa(id);

            if (filialId == null)
            {
                filialId = postoDeCaixa.Filial.Id.ToString();
            }

            if (postoDeCaixa == null)
            {
                return NotFound();
            }

            var filiais = await filialRepository.GetFiliais();
            var filialSelect = filiais.Where(e => e.Ativo == true).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.PessoaJuridica.Nome });

            if (!filialSelect.Where(e => e.Value == filialId).Any() && filialSelect.Any())
            {
                filialId = filialSelect.First().Value;
            }

            var contaCorrentes = await contaCorrenteRepository.GetContasCorrentes();
            var contaCorrentesAtivas = contaCorrentes.Where(c => c.Ativo == true).ToList();
            var contaCorrenteSelect = contaCorrentesAtivas.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.NumeroDaConta.ToString() + " " + x.DigitoVerificadorCC.ToString() });

            var usuarios = await usuarioRepository.GetUsuarios();
            var usuariosAtivos = usuarios.Where(u => u.Ativo == true).ToList();
            var usuarioSelect = usuariosAtivos.Where(e => e.Ativo == true).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Email });

            return View(new PostoDeCaixaViewModel(postoDeCaixa)
            {
                Filiais = filialSelect,
                ContasCorrentes = contaCorrenteSelect,
                ContasCorrentesDB = await contaCorrenteRepository.GetContasCorrentes(),
                Usuarios = usuarioSelect,
                UsuariosDB = await usuarioRepository.GetUsuarios(),
                FilialIdd = filialId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task UpdatePostoDeCaixa([FromBody]PostoDeCaixa postoDeCaixa)
        {
            var filiais = await filialRepository.GetFiliais();
            var contasCorrentes = await contaCorrenteRepository.GetContasCorrentes();
            var usuarios = await usuarioRepository.GetUsuarios();

            await postoDeCaixaRepository.UpdatePostoDeCaixa(postoDeCaixa, filiais, usuarios, contasCorrentes);
        }
    }
}