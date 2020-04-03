using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Databank.Models;

using Microsoft.EntityFrameworkCore;
using static Databank.Repositories.BancoRepository;

namespace Databank.Repositories
{
    public interface IBancoRepository
    {
        Task<Banco> GetBanco(int bancoId);
        Task<List<Banco>> GetBancos();
        Task UpdateBanco(Banco banco);
    }

    public class BancoRepository: BaseRepository<Banco>, IBancoRepository
    {
        public BancoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<Banco> GetBanco(int bancoId)
        {
            return await dbSet.FirstOrDefaultAsync(b => b.Id == bancoId);
        }

        public async Task<List<Banco>> GetBancos()
        {
            return await dbSet
                .Where(u => u.Id != 1)
                .ToListAsync();
        }

        public async Task UpdateBanco(Banco banco)
        {
            var bancoDB = await GetBanco(banco.Id);


            if (bancoDB != null)
            {
                bancoDB.AtualizaNome(banco.Nome);
                await contexto.SaveChangesAsync();
            }
            else
            {

            }
        }
    }


}


