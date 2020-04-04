using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBank.Models;

using Microsoft.EntityFrameworkCore;
using static DataBank.Repositories.BancoRepository;

namespace DataBank.Repositories
{
    public interface IPessoaFisicaRepository
    {
        Task<PessoaFisica> GetPessoaFisica(int pessoaFisicaId);
        Task<List<PessoaFisica>> GetPessoasFisicas();
        //Task UpdateBanco(Banco banco);
    }

    public class PessoaFisicaRepository : BaseRepository<PessoaFisica>, IPessoaFisicaRepository
    {
        public PessoaFisicaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<PessoaFisica> GetPessoaFisica(int pessoaFisicaId)
        {
            return await dbSet
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(b => b.Id == pessoaFisicaId);
        }

        public async Task<List<PessoaFisica>> GetPessoasFisicas()
        {
            return await dbSet
                .Include(a => a.Usuario)
                .Where(u => u.Id != 1)
                .ToListAsync();
        }

        //public async Task UpdateBanco(Banco banco)
        //{
        //    var bancoDB = await GetBanco(banco.Id);


        //    if (bancoDB != null)
        //    {
        //        bancoDB.AtualizaNome(banco.Nome);
        //        await contexto.SaveChangesAsync();
        //    }
        //    else
        //    {

        //    }
        //}
    }
}


