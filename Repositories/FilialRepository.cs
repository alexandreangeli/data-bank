using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoDataCoper.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoDataCoper.Repositories
{
    public interface IFilialRepository
    {
        Task<Filial> GetFilial(int FilialId);
        Task<List<Filial>> GetFiliais();
        Task UpdateFilial(Filial filial, List<Empresa> empresas, List<PessoaJuridica> pessoasJuridicas);
    }

    public class FilialRepository : BaseRepository<Filial>, IFilialRepository
    {
        public FilialRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<Filial> GetFilial(int FilialId)
        {
            return await dbSet
                .Include(f => f.PessoaJuridica)
                .Include(f => f.Empresa)
                .Include(f => f.Usuarios)
                .Include(f => f.ContasCorrentes)
                .Include(f=> f.PostosDeCaixa)
                .FirstOrDefaultAsync(b => b.Id == FilialId);
        }

        public async Task<List<Filial>> GetFiliais()
        {
            return await dbSet
                .Include(f => f.PessoaJuridica)
                .Include(f => f.Empresa)
                .Include(f => f.Usuarios)
                .Include(f => f.ContasCorrentes)
                .Include(f => f.PostosDeCaixa)
                .Where(u => u.Id != 1)
                .ToListAsync();
        }

        public async Task UpdateFilial(Filial filial, List<Empresa> empresas, List<PessoaJuridica> pessoasJuridicas)
        {
            var filialDB = await GetFilial(filial.Id);

            if (filialDB != null)
            {
                filialDB.AtualizaEmpresa(filial.Empresa.Id, empresas);
                filialDB.AtualizaPessoaJuridica(filial.PessoaJuridica.Id, pessoasJuridicas, filialDB);
                filialDB.AtualizaNumeroRegistroNaJuntaComercial(filial.NumeroRegistroNaJuntaComercial);
                if (filialDB.Empresa.Ativo == true && filialDB.PessoaJuridica.Ativo == true)
                {
                    filialDB.AtualizaAtivo(filial.Ativo);
                }
                await contexto.SaveChangesAsync();
            }
        }
    }


}


