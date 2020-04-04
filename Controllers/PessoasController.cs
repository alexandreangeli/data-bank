using DataBank.Models;
using DataBank.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DataBank.Controllers
{
    [Authorize]
    public class PessoasController : Controller
    {
        private readonly ApplicationContext contexto;
        private readonly IPessoaFisicaRepository pessoaFisicaRepository;
        private readonly IPessoaJuridicaRepository pessoaJuridicaRepository;

        public PessoasController(ApplicationContext contexto, IPessoaFisicaRepository pessoaFisicaRepository, IPessoaJuridicaRepository pessoaJuridicaRepository)
        {
            this.contexto = contexto;
            this.pessoaFisicaRepository = pessoaFisicaRepository;
            this.pessoaJuridicaRepository = pessoaJuridicaRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> IndexPF()
        {
            var pessoasFisicas = await pessoaFisicaRepository.GetPessoasFisicas();
            return View(pessoasFisicas);
        }

        public async Task<IActionResult> IndexPJ()
        {
            var pessoasJuridicas = await pessoaJuridicaRepository.GetPessoasJuridicas();
            return View(pessoasJuridicas);
        }

        public async Task<IActionResult> DetailsPF(int id)
        {
            var pessoaFisica = await pessoaFisicaRepository.GetPessoaFisica(id);

            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return View(pessoaFisica);
        }

        public async Task<IActionResult> DetailsPJ(int id)
        {
            var pessoaJuridica = await pessoaJuridicaRepository.GetPessoaJuridica(id);

            if (pessoaJuridica == null)
            {
                return NotFound();
            }

            return View(pessoaJuridica);
        }

        public IActionResult CreatePF()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePF([FromForm] string Nome, [FromForm] string CPF, [FromForm] string RG, [FromForm] string OrgaoExpedidor, [FromForm] string DataNascimento, [FromForm] string Genero, [FromForm] bool Ativo, [FromForm] string Rua, [FromForm] int NumeroEndereco, [FromForm] string Bairro, [FromForm] string Complemento, [FromForm] string Observacao, [FromForm] string CEP, [FromForm] string Cidade, [FromForm] string UF, [FromForm] string Pais)
        {
            var newPessoaFisica = new PessoaFisica(Nome, Format.FormatCPF(Format.SemFormatacao(CPF)), Format.SemFormatacao(RG), OrgaoExpedidor, DataNascimento, Genero, Ativo, Rua, NumeroEndereco, Bairro, Complemento, Observacao, Format.SemFormatacao(CEP), Cidade, UF, Pais);

            contexto.Set<PessoaFisica>().Add(newPessoaFisica);

            await contexto.SaveChangesAsync();

            return RedirectToAction(nameof(IndexPF));
        }

        public IActionResult CreatePJ()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePJ([FromForm] string Nome, [FromForm] string CNPJ, [FromForm] string NumeroMunicipal, [FromForm] bool Ativo, [FromForm] string Rua, [FromForm] int NumeroEndereco, [FromForm] string Bairro, [FromForm] string Complemento, [FromForm] string Observacao, [FromForm] string CEP, [FromForm] string Cidade, [FromForm] string UF, [FromForm] string Pais)
        {
            var newPessoaJuridica = new PessoaJuridica(Nome, Format.FormatCNPJ(Format.SemFormatacao(CNPJ)), NumeroMunicipal, Ativo, Rua, NumeroEndereco, Bairro, Complemento, Observacao, Format.SemFormatacao(CEP), Cidade, UF, Pais);

            contexto.Set<PessoaJuridica>().Add(newPessoaJuridica);

            await contexto.SaveChangesAsync();

            return RedirectToAction(nameof(IndexPJ));
        }

        public async Task<IActionResult> EditPF([FromRoute]int id)
        {
            var pessoaFisica = await pessoaFisicaRepository.GetPessoaFisica(id);
            return View(pessoaFisica);
        }

        [HttpPost]
        public async Task<IActionResult> EditPF([FromForm]int Id,
            [FromForm] string Nome,
            [FromForm] string CPF, [FromForm] string RG, [FromForm] string OrgaoExpedidor,
            [FromForm] string DataNascimento, [FromForm] string Genero, [FromForm] bool Ativo,
            [FromForm] string Rua, [FromForm] int NumeroEndereco, [FromForm] string Bairro, [FromForm] string Complemento,
            [FromForm] string Observacao, [FromForm] string CEP, [FromForm] string Cidade, [FromForm] string UF,
            [FromForm] string Pais)
        {
            var pessoa = await pessoaFisicaRepository.GetPessoaFisica(Id);

            pessoa.AtualizaPessoaFisica(Nome, Format.FormatCPF(Format.SemFormatacao(CPF)), Format.SemFormatacao(RG),
                OrgaoExpedidor, DataNascimento, Genero, Rua, NumeroEndereco, Bairro, Complemento,
                Observacao, Format.SemFormatacao(CEP), Cidade, UF, Pais);

            pessoa.AtualizaAtivo(Ativo);

            contexto.Update(pessoa);

            await contexto.SaveChangesAsync();

            Response.Redirect("/Pessoas/IndexPF");

            return View(pessoa);
        }

        public async Task<IActionResult> EditPJ([FromRoute]int id)
        {
            var pessoaJuridica = await pessoaJuridicaRepository.GetPessoaJuridica(id);
            return View(pessoaJuridica);
        }

        [HttpPost]
        public async Task<IActionResult> EditPJ([FromForm]int Id, [FromForm] string Nome, [FromForm] string CNPJ,
            [FromForm] string NumeroMunicipal, [FromForm] bool Ativo, [FromForm] string Rua,
            [FromForm] int NumeroEndereco, [FromForm] string Bairro, [FromForm] string Complemento,
            [FromForm] string Observacao, [FromForm] string CEP, [FromForm] string Cidade,
            [FromForm] string UF, [FromForm] string Pais)
        {
            var pessoa = await pessoaJuridicaRepository.GetPessoaJuridica(Id);

            pessoa.AtualizaPessoaJuridica(Nome, Format.FormatCNPJ(Format.SemFormatacao(CNPJ)), NumeroMunicipal,
                Rua, NumeroEndereco, Bairro, Complemento, Observacao, Format.SemFormatacao(CEP), Cidade, UF, Pais);

            if (!contexto.Set<PessoaJuridica>().Where(f => f.Ativo == true && f.Id != Id).Where(f => Format.SemFormatacao(f.CNPJ) == Format.SemFormatacao(CNPJ)).Any())
            {
                pessoa.AtualizaAtivo(Ativo);
            }

            contexto.Update(pessoa);

            await contexto.SaveChangesAsync();

            Response.Redirect("/Pessoas/IndexPJ");

            return View(pessoa);
        }

        public bool CNPJUnica(string cnpj, int id)
        {
            if (cnpj != null)
            {
                return !contexto.Set<PessoaJuridica>().Where(f => f.Ativo == true).Where(f => Format.SemFormatacao(f.CNPJ) == Format.SemFormatacao(cnpj)).Where(f => f.Id != id).Any();
            }
            return true;
        }
    }
}
