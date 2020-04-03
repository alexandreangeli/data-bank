using System.Collections.Generic;
using System.Threading.Tasks;
using BancoDataCoper.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoDataCoper.Repositories
{
    public interface IPostoDeCaixaRepository
    {
        Task<PostoDeCaixa> GetPostoDeCaixa(int postoDeCaixaId);
        Task<List<PostoDeCaixa>> GetPostosDeCaixa();
        Task UpdatePostoDeCaixa(PostoDeCaixa postoDeCaixa, List<Filial> filiais, List<Usuario> usuarios, List<ContaCorrente> contasCorrentes);
    }

    public class PostoDeCaixaRepository : BaseRepository<PostoDeCaixa>, IPostoDeCaixaRepository
    {
        public PostoDeCaixaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<PostoDeCaixa> GetPostoDeCaixa(int postoDeCaixaId)
        {
            return await dbSet
                .Include(u => u.ContaCorrente)
                .ThenInclude(u => u.Agencia)
                .ThenInclude(u => u.PessoaJuridica)
                .Include(u => u.Usuario)
                .ThenInclude(u => u.PessoaFisica)
                .Include(u => u.Usuario)
                .ThenInclude(u => u.Filial)
                .Include(u => u.Filial)
                .ThenInclude(u => u.Empresa)
                .Include(u => u.Filial)
                .ThenInclude(u => u.PessoaJuridica)
                .Include(u => u.Filial)
                .ThenInclude(f => f.ContasCorrentes)
                .FirstOrDefaultAsync(b => b.Id == postoDeCaixaId);
        }

        public async Task<List<PostoDeCaixa>> GetPostosDeCaixa()
        {
            return await dbSet
                .Include(u => u.ContaCorrente)
                .ThenInclude(u => u.Agencia)
                .ThenInclude(u => u.PessoaJuridica)
                .Include(u => u.Usuario)
                .ThenInclude(u => u.PessoaFisica)
                .Include(u => u.Usuario)
                .ThenInclude(u => u.Filial)
                .Include(u => u.Filial)
                .ThenInclude(u => u.Empresa)
                .Include(u => u.Filial)
                .ThenInclude(u => u.PessoaJuridica)
                .Include(u => u.Filial)
                .ThenInclude(f => f.ContasCorrentes)
                .ToListAsync();
        }

        public async Task UpdatePostoDeCaixa(PostoDeCaixa postoDeCaixa, List<Filial> filiais, List<Usuario> usuarios, List<ContaCorrente> contasCorrentes)
        {
            var postoDeCaixaDB = await GetPostoDeCaixa(postoDeCaixa.Id);

            if (postoDeCaixaDB != null)
            {
                postoDeCaixaDB.AtualizaFilial(postoDeCaixa.Filial.Id, filiais);

                postoDeCaixaDB.AtualizaContaCorrente(postoDeCaixa.ContaCorrente.Id, contasCorrentes);

                postoDeCaixaDB.AtualizaUsuario(postoDeCaixa.Usuario.Id, usuarios);

                postoDeCaixaDB.AtualizaNome(postoDeCaixa.Nome);

                if (postoDeCaixaDB.Filial.Ativo == true
                    && postoDeCaixaDB.Usuario.PessoaFisica.Ativo == true
                    && postoDeCaixaDB.Usuario.Ativo == true
                    && postoDeCaixaDB.ContaCorrente.Ativo == true)
                {
                    postoDeCaixaDB.AtualizaAtivo(postoDeCaixa.Ativo);
                }

                await contexto.SaveChangesAsync();
            }
            else
            {

            }
        }
    }


}


