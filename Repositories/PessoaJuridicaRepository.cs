using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoDataCoper.Models;
using Microsoft.EntityFrameworkCore;
using static BancoDataCoper.Repositories.BancoRepository;

namespace BancoDataCoper.Repositories
{
    public interface IPessoaJuridicaRepository
    {
        Task<PessoaJuridica> GetPessoaJuridica(int bancoId);
        Task<List<PessoaJuridica>> GetPessoasJuridicas();
        //Task UpdatePessoaJuridica(PessoaJuridica pessoaJuridica);
    }

    public class PessoaJuridicaRepository : BaseRepository<PessoaJuridica>, IPessoaJuridicaRepository
    {
        public PessoaJuridicaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<PessoaJuridica> GetPessoaJuridica(int pessoaJuridicaId)
        {
            return await dbSet
                .Include(a => a.Agencia)
                .ThenInclude(a => a.Banco)
                .Include(a => a.Filial)
                .ThenInclude(a => a.Usuarios)
                .Include(a => a.Filial)
                .ThenInclude(a => a.Empresa)
                .FirstOrDefaultAsync(b => b.Id == pessoaJuridicaId);
        }

        public async Task<List<PessoaJuridica>> GetPessoasJuridicas()
        {
            return await dbSet
                .Include(a => a.Agencia)
                .ThenInclude(a => a.Banco)
                .Include(a => a.Filial)
                .ThenInclude(a => a.Usuarios)
                .Include(a => a.Filial)
                .ThenInclude(a => a.Empresa)
                .Where(u => u.Id != 1 && u.Id != 2)
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


