using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBank.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBank.Repositories
{
    public interface IContaCorrenteRepository
    {
        Task<ContaCorrente> GetContaCorrente(int contaCorrenteId);
        Task<List<ContaCorrente>> GetContasCorrentes();
        Task UpdateContaCorrente(ContaCorrente contaCorrente, List<Banco> bancos, List<Agencia> agencias, List<Filial> filiais);
    }

    public class ContaCorrenteRepository : BaseRepository<ContaCorrente>, IContaCorrenteRepository
    {
        public ContaCorrenteRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<ContaCorrente> GetContaCorrente(int contaCorrenteId)
        {
            return await dbSet
                .Include(cc => cc.Agencia)
                .ThenInclude(f => f.Banco)
                .Include(cc => cc.Agencia)
                .ThenInclude(f => f.PessoaJuridica)
                .Include(cc => cc.Filial)
                .ThenInclude(a => a.Usuarios)
                .Include(cc => cc.Filial)
                .ThenInclude(cc => cc.PessoaJuridica)
                .Include(cc => cc.Filial)
                .ThenInclude(cc => cc.Empresa)
                .FirstOrDefaultAsync(b => b.Id == contaCorrenteId);
        }

        public async Task<List<ContaCorrente>> GetContasCorrentes()
        {
            return await dbSet
                .Include(cc => cc.Agencia)
                .ThenInclude(f => f.Banco)
                .Include(cc => cc.Agencia)
                .ThenInclude(f => f.PessoaJuridica)
                .Include(cc => cc.Filial)
                .ThenInclude(a => a.Usuarios)
                .Include(cc => cc.Filial)
                .ThenInclude(cc => cc.PessoaJuridica)
                .Include(cc => cc.Filial)
                .ThenInclude(cc => cc.Empresa)
                .ToListAsync();
        }

        public async Task UpdateContaCorrente(ContaCorrente contaCorrente, List<Banco> bancos, List<Agencia> agencias, List<Filial> filiais)
        {
            var contaCorrenteDB = await GetContaCorrente(contaCorrente.Id);

            if (contaCorrenteDB != null)
            {
                contaCorrenteDB.AtualizaBanco(contaCorrente.Banco.Id, bancos);
                contaCorrenteDB.AtualizaAgencia(contaCorrente.Agencia.Id, agencias);
                contaCorrenteDB.AtualizaFilial(contaCorrente.Filial.Id, filiais);

                contaCorrenteDB.AtualizaDescricao(contaCorrente.Descricao);
                contaCorrenteDB.AtualizaNumeroDaConta(contaCorrente.NumeroDaConta);
                contaCorrenteDB.AtualizaDigitoVerificadorCC(contaCorrente.DigitoVerificadorCC);

                await contexto.SaveChangesAsync();
            }
            else
            {

            }
        }
    }
}


