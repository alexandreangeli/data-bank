using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataBank.Models;
using DataBank.Repositories;
using DataBank.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace DataBank.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBancoRepository bancoRepository;
        private readonly IEmpresaRepository empresaRepository;
        private readonly IFilialRepository filialRepository;
        private readonly IPessoaJuridicaRepository pessoaJuridicaRepository;
        private readonly IPessoaFisicaRepository pessoaFisicaRepository;
        private readonly IAgenciaRepository agenciaRepository;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IContaCorrenteRepository contaCorrenteRepository;
        private readonly IPostoDeCaixaRepository postoDeCaixaRepository;
        private readonly IMovimentoBancarioRepository movimentoBancarioRepository;
        private readonly ApplicationContext contexto;

        public HomeController(IBancoRepository bancoRepository, IEmpresaRepository empresaRepository, IFilialRepository filialRepository, IPessoaJuridicaRepository pessoaJuridicaRepository, IPessoaFisicaRepository pessoaFisicaRepository, IAgenciaRepository agenciaRepository, IUsuarioRepository usuarioRepository, IContaCorrenteRepository contaCorrenteRepository, IPostoDeCaixaRepository postoDeCaixaRepository, IMovimentoBancarioRepository movimentoBancarioRepository, ApplicationContext contexto)
        {
            this.bancoRepository = bancoRepository;
            this.empresaRepository = empresaRepository;
            this.filialRepository = filialRepository;
            this.pessoaJuridicaRepository = pessoaJuridicaRepository;
            this.pessoaFisicaRepository = pessoaFisicaRepository;
            this.agenciaRepository = agenciaRepository;
            this.usuarioRepository = usuarioRepository;
            this.contaCorrenteRepository = contaCorrenteRepository;
            this.postoDeCaixaRepository = postoDeCaixaRepository;
            this.movimentoBancarioRepository = movimentoBancarioRepository;
            this.contexto = contexto;
        }

        public async Task<IActionResult> Inicio()
        {
            var pessoasJuridicas = await pessoaJuridicaRepository.GetPessoasJuridicas();
            if (!pessoasJuridicas.Any())
            {
                var PessoaJuridicaAdmin1 = new PessoaJuridica("Admin1", "", "", true, "", 0, "", "", "", "", "", "", "");
                contexto.Set<PessoaJuridica>().Add(PessoaJuridicaAdmin1);

                var PessoaJuridicaAdmin2 = new PessoaJuridica("Admin2", "", "", true, "", 0, "", "", "", "", "", "", "");
                contexto.Set<PessoaJuridica>().Add(PessoaJuridicaAdmin2);

                var newPessoaJuridica = new PessoaJuridica("DC - Filial 1", Format.FormatCNPJ(Format.SemFormatacao("67.983.897/0001-91")), "85741987", true, "Avenida Aracy Tanaka Biazetto", 347, "Pioneiros Catarinenses", "", "", Format.SemFormatacao("85805505"), "Cascavel", "PR", "Brasil");
                contexto.Set<PessoaJuridica>().Add(newPessoaJuridica);

                var newPessoaJuridica2 = new PessoaJuridica("DC - Filial 2", Format.FormatCNPJ(Format.SemFormatacao("67.983.897/0002-91")), "16485255", true, "Rua Ernesto Nazareth", 645, "Brasília", "", "", Format.SemFormatacao("85815110"), "Cascavel", "PR", "Brasil");
                contexto.Set<PessoaJuridica>().Add(newPessoaJuridica2);

                var newPessoaJuridica3 = new PessoaJuridica("SA - Filial 1", Format.FormatCNPJ(Format.SemFormatacao("42.078.762/0001-50")), "18745239", true, "Rua Safira", 68, "Esmeralda", "", "", Format.SemFormatacao("85806670"), "Cascavel", "PR", "Brasil");
                contexto.Set<PessoaJuridica>().Add(newPessoaJuridica3);

                var newPessoaJuridica4 = new PessoaJuridica("SA - Filial 2", Format.FormatCNPJ(Format.SemFormatacao("42.078.762/0002-50")), "85846259", true, "Rua Pereira", 6854, "Brazmadeira", "", "", Format.SemFormatacao("85814126"), "Cascavel", "PR", "Brasil");
                contexto.Set<PessoaJuridica>().Add(newPessoaJuridica4);

                var newPessoaJuridica5 = new PessoaJuridica("BB - Agência 1", Format.FormatCNPJ(Format.SemFormatacao("92.726.376/0001-04")), "48475168", true, "Rua Dom Manoel Konner", 284, "Interlagos", "", "", Format.SemFormatacao("85814425"), "Cascavel", "PR", "Brasil");
                contexto.Set<PessoaJuridica>().Add(newPessoaJuridica5);

                var newPessoaJuridica6 = new PessoaJuridica("BB - Agência 2", Format.FormatCNPJ(Format.SemFormatacao("92.726.376/0002-04")), "26857485", true, "Rua Pelotas", 285, "Canadá", "", "", Format.SemFormatacao("85813680"), "Cascavel", "PR", "Brasil");
                contexto.Set<PessoaJuridica>().Add(newPessoaJuridica6);

                var newPessoaJuridica7 = new PessoaJuridica("CX - Agência 1", Format.FormatCNPJ(Format.SemFormatacao("41.539.802/0001-51")), "79524874", true, "Rua São Tomás", 214, "Recanto Tropical", "", "", Format.SemFormatacao("85807370"), "Cascavel", "PR", "Brasil");
                contexto.Set<PessoaJuridica>().Add(newPessoaJuridica7);

                var newPessoaJuridica8 = new PessoaJuridica("CX - Agência 2", Format.FormatCNPJ(Format.SemFormatacao("41.539.802/0002-51")), "36902548", true, "Rua Cornalina", 333, "Esmeralda", "", "", Format.SemFormatacao("85806490"), "Cascavel", "PR", "Brasil");
                contexto.Set<PessoaJuridica>().Add(newPessoaJuridica8);

                var newPessoaJuridica9 = new PessoaJuridica("DC - Filial 3", Format.FormatCNPJ(Format.SemFormatacao("67.983.897/0003-91")), "214", true, "Rua Estanislau Ternoski", 53, "Floresta", "", "", Format.SemFormatacao("85814534"), "Cascavel", "PR", "Brasil");
                contexto.Set<PessoaJuridica>().Add(newPessoaJuridica9);

                var newPessoaJuridica10 = new PessoaJuridica("SA - Filial 3", Format.FormatCNPJ(Format.SemFormatacao("42.078.762/0003-50")), "2", true, "Rua Arlindo Oscar Carelli", 53, "Canadá", "", "", Format.SemFormatacao("85813596"), "Cascavel", "PR", "Brasil");
                contexto.Set<PessoaJuridica>().Add(newPessoaJuridica10);

                await contexto.SaveChangesAsync();
            }

            var empresas = await empresaRepository.GetEmpresas();
            if (!empresas.Any())
            {
                var EmpresaAdmin = new Empresa("Admin", "", true);
                contexto.Set<Empresa>().Add(EmpresaAdmin);

                var newEmpresa = new Empresa("DataCoper", "DC", true);
                contexto.Set<Empresa>().Add(newEmpresa);

                var newEmpresa2 = new Empresa("Saraiva", "SA", true);
                contexto.Set<Empresa>().Add(newEmpresa2);

                await contexto.SaveChangesAsync();
            }

            var bancos = await bancoRepository.GetBancos();
            if (!bancos.Any())
            {
                var BancoAdmin = new Banco("Admin", "");
                contexto.Set<Banco>().Add(BancoAdmin);

                var newBanco = new Banco("Banco do Brasil", "001");
                contexto.Set<Banco>().Add(newBanco);

                var newBanco2 = new Banco("Caixa Econômica", "104");
                contexto.Set<Banco>().Add(newBanco2);

                await contexto.SaveChangesAsync();
            }

            var filiais = await filialRepository.GetFiliais();
            if (!filiais.Any())
            {
                var empresass = contexto.Set<Empresa>().ToList();
                var pessoasJuridicass = contexto.Set<PessoaJuridica>().ToList();

                var FilialAdmin = new Filial(pessoasJuridicass.Where(p => p.Nome == "Admin1").FirstOrDefault(), empresass.Where(e => e.Nome == "Admin").FirstOrDefault(), true, 0);
                contexto.Set<Filial>().Add(FilialAdmin);

                var newFilial = new Filial(pessoasJuridicass.Where(p => p.Nome == "DC - Filial 1").FirstOrDefault(), empresass.Where(e => e.Nome == "DataCoper").FirstOrDefault(), true, 185642);
                contexto.Set<Filial>().Add(newFilial);

                var newFilial2 = new Filial(pessoasJuridicass.Where(p => p.Nome == "DC - Filial 2").FirstOrDefault(), empresass.Where(e => e.Nome == "DataCoper").FirstOrDefault(), true, 189754);
                contexto.Set<Filial>().Add(newFilial2);

                var newFilial3 = new Filial(pessoasJuridicass.Where(p => p.Nome == "SA - Filial 1").FirstOrDefault(), empresass.Where(e => e.Nome == "Saraiva").FirstOrDefault(), true, 258462);
                contexto.Set<Filial>().Add(newFilial3);

                var newFilial4 = new Filial(pessoasJuridicass.Where(p => p.Nome == "SA - Filial 2").FirstOrDefault(), empresass.Where(e => e.Nome == "Saraiva").FirstOrDefault(), true, 137965);
                contexto.Set<Filial>().Add(newFilial4);

                await contexto.SaveChangesAsync();
            }

            var agencias = await agenciaRepository.GetAgencias();
            if (!agencias.Any())
            {
                var bancoss = contexto.Set<Banco>().ToList();
                var pessoasJuridicass = contexto.Set<PessoaJuridica>().ToList();

                var AgenciaAdmin = new Agencia(pessoasJuridicass.Where(p => p.Nome == "Admin2").FirstOrDefault(), bancoss.Where(b => b.Nome == "Admin").FirstOrDefault(), 0, 0);
                contexto.Set<Agencia>().Add(AgenciaAdmin);

                var newAgencia = new Agencia(pessoasJuridicass.Where(p => p.Nome == "BB - Agência 1").FirstOrDefault(), bancoss.Where(b => b.Nome == "Banco do Brasil").FirstOrDefault(), 85, 1);
                contexto.Set<Agencia>().Add(newAgencia);

                var newAgencia2 = new Agencia(pessoasJuridicass.Where(p => p.Nome == "BB - Agência 2").FirstOrDefault(), bancoss.Where(b => b.Nome == "Banco do Brasil").FirstOrDefault(), 28, 2);
                contexto.Set<Agencia>().Add(newAgencia2);

                var newAgencia3 = new Agencia(pessoasJuridicass.Where(p => p.Nome == "CX - Agência 1").FirstOrDefault(), bancoss.Where(b => b.Nome == "Caixa Econômica").FirstOrDefault(), 36, 3);
                contexto.Set<Agencia>().Add(newAgencia3);

                var newAgencia4 = new Agencia(pessoasJuridicass.Where(p => p.Nome == "CX - Agência 2").FirstOrDefault(), bancoss.Where(b => b.Nome == "Caixa Econômica").FirstOrDefault(), 98, 4);
                contexto.Set<Agencia>().Add(newAgencia4);

                await contexto.SaveChangesAsync();
            }

            var pessoasFisicas = await pessoaFisicaRepository.GetPessoasFisicas();
            if (!pessoasFisicas.Any())
            {
                var PessoaFisicaAdmin = new PessoaFisica("Admin", "", "", "", "", "Masculino", true, "", 0, "", "", "", "", "", "", "");
                contexto.Set<PessoaFisica>().Add(PessoaFisicaAdmin);

                var newPessoaFisica = new PessoaFisica("João Pedro", "563.374.870-01", "147372586", "SSP", "21/09/1996", "Masculino", true, "Rua Morretes", 358, "Universitário", "", "", "85819060", "Cascavel", "PR", "Brasil");
                contexto.Set<PessoaFisica>().Add(newPessoaFisica);

                var newPessoaFisica2 = new PessoaFisica("Carlos Vendrame", "183.282.150-12", "404577994", "SSP", "11/05/1992", "Masculino", true, "Rua Martin Popenga", 1415, "Brazmadeira", "", "", "85814209", "Cascavel", "PR", "Brasil");
                contexto.Set<PessoaFisica>().Add(newPessoaFisica2);

                var newPessoaFisica3 = new PessoaFisica("Julia Roberts", "708.546.080-60", "308160873", "SSP", "13/02/1968", "Feminino", true, "Rua Agostinho Cerioli", 1415, "Universitário", "", "", "85819435", "Cascavel", "PR", "Brasil");
                contexto.Set<PessoaFisica>().Add(newPessoaFisica3);

                var newPessoaFisica4 = new PessoaFisica("Sandra Gomes", "887.765.530-51", "290722354", "SSP", "11/12/1982", "Feminino", true, "Rua Florêncio Galafassi", 241, "Periolo", "", "", "85817320", "Cascavel", "PR", "Brasil");
                contexto.Set<PessoaFisica>().Add(newPessoaFisica4);

                var newPessoaFisica5 = new PessoaFisica("Francisco Cuoco", "403.378.850-60", "356528303", "SSP", "01/10/1985", "Masculino", true, "Rua João de Mattos", 241, "Coqueiral", "", "", "85807530", "Cascavel", "PR", "Brasil");
                contexto.Set<PessoaFisica>().Add(newPessoaFisica5);

                await contexto.SaveChangesAsync();
            }

            var usuarios = await usuarioRepository.GetUsuarios();
            if (!usuarios.Any())
            {
                var filiaiss = contexto.Set<Filial>().ToList();
                var pessoasFisicass = contexto.Set<PessoaFisica>().ToList();

                var UsuarioAdmin = new Usuario(filiaiss.Where(f => f.PessoaJuridica.Nome == "Admin1").FirstOrDefault().Empresa, filiaiss.Where(f => f.PessoaJuridica.Nome == "Admin1").FirstOrDefault(), pessoasFisicass.Where(p => p.Nome == "Admin").FirstOrDefault(), "admin", 0, "admin", true);
                contexto.Set<Usuario>().Add(UsuarioAdmin);

                var newUsuario = new Usuario(filiaiss.Where(f => f.PessoaJuridica.Nome == "DC - Filial 1").FirstOrDefault().Empresa, filiaiss.Where(f => f.PessoaJuridica.Nome == "DC - Filial 1").FirstOrDefault(), pessoasFisicass.Where(p => p.Nome == "João Pedro").FirstOrDefault(), "joaopedro@gmail.com", 45998215707, "!Aa1111", true);
                contexto.Set<Usuario>().Add(newUsuario);

                var newUsuario2 = new Usuario(filiaiss.Where(f => f.PessoaJuridica.Nome == "DC - Filial 2").FirstOrDefault().Empresa, filiaiss.Where(f => f.PessoaJuridica.Nome == "DC - Filial 2").FirstOrDefault(), pessoasFisicass.Where(p => p.Nome == "Carlos Vendrame").FirstOrDefault(), "carlosvendrame@gmail.com", 45996584518, ">Cc3333", true);
                contexto.Set<Usuario>().Add(newUsuario2);

                var newUsuario3 = new Usuario(filiaiss.Where(f => f.PessoaJuridica.Nome == "SA - Filial 1").FirstOrDefault().Empresa, filiaiss.Where(f => f.PessoaJuridica.Nome == "SA - Filial 1").FirstOrDefault(), pessoasFisicass.Where(p => p.Nome == "Julia Roberts").FirstOrDefault(), "juliaroberts@hotmail.com", 45995784265, "<Dd3333", true);
                contexto.Set<Usuario>().Add(newUsuario3);

                var newUsuario4 = new Usuario(filiaiss.Where(f => f.PessoaJuridica.Nome == "SA - Filial 2").FirstOrDefault().Empresa, filiaiss.Where(f => f.PessoaJuridica.Nome == "SA - Filial 2").FirstOrDefault(), pessoasFisicass.Where(p => p.Nome == "Sandra Gomes").FirstOrDefault(), "sandragomes@hotmail.com", 45999285758, ".Bb2222", true);
                contexto.Set<Usuario>().Add(newUsuario4);

                await contexto.SaveChangesAsync();
            }

            var contaCorrentes = await contaCorrenteRepository.GetContasCorrentes();
            if (!contaCorrentes.Any())
            {
                var filiaiss = contexto.Set<Filial>().ToList();
                var bancoss = contexto.Set<Banco>().ToList();
                var agenciass = contexto.Set<Agencia>().ToList();

                var newContaCorrente = new ContaCorrente(bancoss.Where(b => b.Nome == "Banco do Brasil").FirstOrDefault(), agenciass.Where(a => a.PessoaJuridica.Nome == "BB - Agência 2").FirstOrDefault(), filiaiss.Where(f => f.PessoaJuridica.Nome == "DC - Filial 1").FirstOrDefault(), DateTime.Now, "Descricao", 1003609, "1", 750);
                contexto.Set<ContaCorrente>().Add(newContaCorrente);

                var newContaCorrente2 = new ContaCorrente(bancoss.Where(b => b.Nome == "Caixa Econômica").FirstOrDefault(), agenciass.Where(a => a.PessoaJuridica.Nome == "CX - Agência 2").FirstOrDefault(), filiaiss.Where(f => f.PessoaJuridica.Nome == "DC - Filial 1").FirstOrDefault(), DateTime.Now, "Descricao2", 02369466021, "1", 0);
                contexto.Set<ContaCorrente>().Add(newContaCorrente2);

                var newContaCorrente3 = new ContaCorrente(bancoss.Where(b => b.Nome == "Banco do Brasil").FirstOrDefault(), agenciass.Where(a => a.PessoaJuridica.Nome == "BB - Agência 1").FirstOrDefault(), filiaiss.Where(f => f.PessoaJuridica.Nome == "DC - Filial 2").FirstOrDefault(), DateTime.Now, "Descricao3", 1084805, "3", 0);
                contexto.Set<ContaCorrente>().Add(newContaCorrente3);

                var newContaCorrente4 = new ContaCorrente(bancoss.Where(b => b.Nome == "Banco do Brasil").FirstOrDefault(), agenciass.Where(a => a.PessoaJuridica.Nome == "BB - Agência 2").FirstOrDefault(), filiaiss.Where(f => f.PessoaJuridica.Nome == "DC - Filial 2").FirstOrDefault(), DateTime.Now, "Descricao4", 153363, "0", 0);
                contexto.Set<ContaCorrente>().Add(newContaCorrente4);

                var newContaCorrente5 = new ContaCorrente(bancoss.Where(b => b.Nome == "Caixa Econômica").FirstOrDefault(), agenciass.Where(a => a.PessoaJuridica.Nome == "CX - Agência 1").FirstOrDefault(), filiaiss.Where(f => f.PessoaJuridica.Nome == "SA - Filial 1").FirstOrDefault(), DateTime.Now, "Descricao5", 02318661837, "8", 0);
                contexto.Set<ContaCorrente>().Add(newContaCorrente5);

                var newContaCorrente6 = new ContaCorrente(bancoss.Where(b => b.Nome == "Caixa Econômica").FirstOrDefault(), agenciass.Where(a => a.PessoaJuridica.Nome == "CX - Agência 2").FirstOrDefault(), filiaiss.Where(f => f.PessoaJuridica.Nome == "SA - Filial 1").FirstOrDefault(), DateTime.Now, "Descricao5", 00332239172, "7", 0);
                contexto.Set<ContaCorrente>().Add(newContaCorrente6);

                var newContaCorrente7 = new ContaCorrente(bancoss.Where(b => b.Nome == "Caixa Econômica").FirstOrDefault(), agenciass.Where(a => a.PessoaJuridica.Nome == "CX - Agência 2").FirstOrDefault(), filiaiss.Where(f => f.PessoaJuridica.Nome == "SA - Filial 2").FirstOrDefault(), DateTime.Now, "Descricao7", 00291250081, "9", 0);
                contexto.Set<ContaCorrente>().Add(newContaCorrente7);

                var newContaCorrente8 = new ContaCorrente(bancoss.Where(b => b.Nome == "Banco do Brasil").FirstOrDefault(), agenciass.Where(a => a.PessoaJuridica.Nome == "BB - Agência 2").FirstOrDefault(), filiaiss.Where(f => f.PessoaJuridica.Nome == "SA - Filial 2").FirstOrDefault(), DateTime.Now, "Descricao7", 248757, "8", 0);
                contexto.Set<ContaCorrente>().Add(newContaCorrente8);


                await contexto.SaveChangesAsync();
            }

            var postosDeCaixa = await postoDeCaixaRepository.GetPostosDeCaixa();
            if (!postosDeCaixa.Any())
            {
                var filiaiss = await filialRepository.GetFiliais();
                var usuarioss = await usuarioRepository.GetUsuarios();
                var contasCorrentess = await contaCorrenteRepository.GetContasCorrentes();

                var newPostoDeCaixa = new PostoDeCaixa(filiaiss.Where(b => b.PessoaJuridica.Nome == "DC - Filial 1").FirstOrDefault(), usuarioss.Where(a => a.Email == "joaopedro@gmail.com").FirstOrDefault(), contasCorrentess.Where(f => f.NumeroDaConta == 1003609).FirstOrDefault(), 1, "DC - Filial 1 - João Pedro - Posto 1", true);
                contexto.Set<PostoDeCaixa>().Add(newPostoDeCaixa);

                var newPostoDeCaixa2 = new PostoDeCaixa(filiaiss.Where(b => b.PessoaJuridica.Nome == "DC - Filial 1").FirstOrDefault(), usuarioss.Where(a => a.Email == "joaopedro@gmail.com").FirstOrDefault(), contasCorrentess.Where(f => f.NumeroDaConta == 02369466021).FirstOrDefault(), 1, "DC - Filial 1 - João Pedro - Posto 2", true);
                contexto.Set<PostoDeCaixa>().Add(newPostoDeCaixa2);

                var newPostoDeCaixa3 = new PostoDeCaixa(filiaiss.Where(b => b.PessoaJuridica.Nome == "DC - Filial 2").FirstOrDefault(), usuarioss.Where(a => a.Email == "carlosvendrame@gmail.com").FirstOrDefault(), contasCorrentess.Where(f => f.NumeroDaConta == 1084805).FirstOrDefault(), 1, "DC - Filial 2 - Carlos Vendrame - Posto 1", true);
                contexto.Set<PostoDeCaixa>().Add(newPostoDeCaixa3);

                var newPostoDeCaixa4 = new PostoDeCaixa(filiaiss.Where(b => b.PessoaJuridica.Nome == "DC - Filial 2").FirstOrDefault(), usuarioss.Where(a => a.Email == "carlosvendrame@gmail.com").FirstOrDefault(), contasCorrentess.Where(f => f.NumeroDaConta == 153363).FirstOrDefault(), 1, "DC - Filial 2 - Carlos Vendrame - Posto 2", true);
                contexto.Set<PostoDeCaixa>().Add(newPostoDeCaixa4);

                var newPostoDeCaixa5 = new PostoDeCaixa(filiaiss.Where(b => b.PessoaJuridica.Nome == "SA - Filial 1").FirstOrDefault(), usuarioss.Where(a => a.Email == "juliaroberts@hotmail.com").FirstOrDefault(), contasCorrentess.Where(f => f.NumeroDaConta == 02318661837).FirstOrDefault(), 1, "SA - Filial 1 - Julia Roberts - Posto 1", true);
                contexto.Set<PostoDeCaixa>().Add(newPostoDeCaixa5);

                var newPostoDeCaixa6= new PostoDeCaixa(filiaiss.Where(b => b.PessoaJuridica.Nome == "SA - Filial 1").FirstOrDefault(), usuarioss.Where(a => a.Email == "juliaroberts@hotmail.com").FirstOrDefault(), contasCorrentess.Where(f => f.NumeroDaConta == 00332239172).FirstOrDefault(), 1, "SA - Filial 1 - Julia Roberts - Posto 2", true);
                contexto.Set<PostoDeCaixa>().Add(newPostoDeCaixa6);

                var newPostoDeCaixa7 = new PostoDeCaixa(filiaiss.Where(b => b.PessoaJuridica.Nome == "SA - Filial 2").FirstOrDefault(), usuarioss.Where(a => a.Email == "sandragomes@hotmail.com").FirstOrDefault(), contasCorrentess.Where(f => f.NumeroDaConta == 00291250081).FirstOrDefault(), 1, "SA - Filial 2 - Sandra Gomes- Posto 1", true);
                contexto.Set<PostoDeCaixa>().Add(newPostoDeCaixa7);

                var newPostoDeCaixa8 = new PostoDeCaixa(filiaiss.Where(b => b.PessoaJuridica.Nome == "SA - Filial 2").FirstOrDefault(), usuarioss.Where(a => a.Email == "sandragomes@hotmail.com").FirstOrDefault(), contasCorrentess.Where(f => f.NumeroDaConta == 248757).FirstOrDefault(), 1, "SA - Filial 2 - Sandra Gomes- Posto 2", true);
                contexto.Set<PostoDeCaixa>().Add(newPostoDeCaixa8);

                await contexto.SaveChangesAsync();
            }

            var movimentosBancarios = await movimentoBancarioRepository.GetMovimentosBancarios();
            if (!movimentosBancarios.Any())
            {
                var usuarioss = await usuarioRepository.GetUsuarios();
                var contasCorrentess = await contaCorrenteRepository.GetContasCorrentes();

                var newMovimentoBancario = new MovimentoBancario(contasCorrentess.Where(f => f.NumeroDaConta == 1003609).FirstOrDefault(), usuarioss.Where(a => a.Email == "joaopedro@gmail.com").FirstOrDefault().Email, 1500, "Depósito", DateTime.Now.AddDays(-10), false, null, null);
                contexto.Set<MovimentoBancario>().Add(newMovimentoBancario);

                var newMovimentoBancario2 = new MovimentoBancario(contasCorrentess.Where(f => f.NumeroDaConta == 1003609).FirstOrDefault(), usuarioss.Where(a => a.Email == "joaopedro@gmail.com").FirstOrDefault().Email, 750, "Saque", DateTime.Now.AddDays(-3), false, null, null);
                contexto.Set<MovimentoBancario>().Add(newMovimentoBancario2);

                var newMovimentoBancario3 = new MovimentoBancario(contasCorrentess.Where(f => f.NumeroDaConta == 1003609).FirstOrDefault(), usuarioss.Where(a => a.Email == "joaopedro@gmail.com").FirstOrDefault().Email, 300, "Saque", DateTime.Now.AddDays(-2), false, null, null);
                contexto.Set<MovimentoBancario>().Add(newMovimentoBancario3);

                var newMovimentoBancario4 = new MovimentoBancario(contasCorrentess.Where(f => f.NumeroDaConta == 1003609).FirstOrDefault(), usuarioss.Where(a => a.Email == "joaopedro@gmail.com").FirstOrDefault().Email, 300, "Depósito", DateTime.Now.AddDays(0), false, null, null);
                contexto.Set<MovimentoBancario>().Add(newMovimentoBancario4);

                await contexto.SaveChangesAsync();
            }

            return View();
        }

        [Authorize]
        public async Task<IActionResult> InicioLogado()
        {
            var usuario = await usuarioRepository.GetUsuario(User.Identity.Name);

            return View(new MovimentoBancarioViewModel(usuario));
        }

        [Authorize]
        public IActionResult InicioCadastro()
        {
            return View();
        }
    }
}
