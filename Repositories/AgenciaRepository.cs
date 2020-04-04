using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBank.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBank.Repositories
{
    public interface IAgenciaRepository
    {
        Task<Agencia> GetAgencia(int agenciaId);
        Task<List<Agencia>> GetAgencias();
        Task UpdateAgencia(Agencia agencia, List<Banco> bancos, List<PessoaJuridica> pessoasJuridicas);
    }

    public class AgenciaRepository : BaseRepository<Agencia>, IAgenciaRepository
    {
        public AgenciaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<Agencia> GetAgencia(int agenciaId)
        {
            return await dbSet
                .Include(u => u.Banco)
                .Include(u => u.PessoaJuridica)
                .ThenInclude(u => u.Filial)
                .Include(u => u.PessoaJuridica)
                .Include(u => u.ContasCorrentes)
                .FirstOrDefaultAsync(b => b.Id == agenciaId);
        }

        public async Task<List<Agencia>> GetAgencias()
        {
            return await dbSet
                .Include(u => u.Banco)
                .Include(u => u.PessoaJuridica)
                .ThenInclude(u => u.Filial)
                .Include(u => u.PessoaJuridica)
                .Include(u => u.ContasCorrentes)
                .Where(u => u.Id != 1)
                .ToListAsync();
        }

        public async Task UpdateAgencia(Agencia agencia, List<Banco> bancos, List<PessoaJuridica> pessoasJuridicas)
        {
            var agenciaDB = await GetAgencia(agencia.Id);

            if (agenciaDB != null)
            {                
                agenciaDB.AtualizaBanco(agencia.Banco.Id, bancos);

                agenciaDB.AtualizaPessoaJuridica(agencia.PessoaJuridica.Id, pessoasJuridicas);

                agenciaDB.AtualizaCodigo(agencia.Codigo);

                agenciaDB.AtualizaDigitoVerificador(agencia.DigitoVerificador);

                await contexto.SaveChangesAsync();
            }
        }
    }
}



