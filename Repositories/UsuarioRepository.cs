using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoDataCoper.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoDataCoper.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetUsuario(int usuarioId);
        Task<Usuario> GetUsuario(string email);
        Task<List<Usuario>> GetUsuarios();
        Task UpdateUsuario(Usuario usuario, List<Empresa> empresas, List<Filial> filiais, List<PessoaFisica> pessoasFisicas);
    }

    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<Usuario> GetUsuario(int usuarioId)
        {
            return await dbSet
                .Include(u => u.Filial)
                .ThenInclude(u => u.PessoaJuridica)
                .Include(u => u.Filial)
                .ThenInclude(f => f.Empresa)
                .Include(u => u.Filial)
                .ThenInclude(f => f.ContasCorrentes)
                .Include(u => u.PessoaFisica)
                .Include(u => u.PostosDeCaixa)
                .FirstOrDefaultAsync(b => b.Id == usuarioId);
        }
        public async Task<Usuario> GetUsuario(string email)
        {
            return await dbSet
                .Include(u => u.Filial)
                .ThenInclude(u => u.PessoaJuridica)
                .Include(u => u.Filial)
                .ThenInclude(f => f.Empresa)
                .Include(u => u.Filial)
                .ThenInclude(f => f.ContasCorrentes)
                .Include(u => u.PessoaFisica)
                .Include(u => u.PostosDeCaixa)
                .FirstOrDefaultAsync(b => b.Email == email);
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            return await dbSet
                .Include(u => u.Filial)
                .ThenInclude(u => u.PessoaJuridica)
                .Include(u => u.Filial)
                .ThenInclude(f => f.Empresa)
                .Include(u => u.Filial)
                .ThenInclude(f => f.ContasCorrentes)
                .Include(u => u.PessoaFisica)
                .Include(u => u.PostosDeCaixa)
                .Where(u => u.Id != 1)
                .ToListAsync();
        }

        public async Task UpdateUsuario(Usuario usuario, List<Empresa> empresas, List<Filial> filiais, List<PessoaFisica> pessoasFisicas)
        {
            var usuarioDB = await GetUsuario(usuario.Id);

            if (usuarioDB != null)
            {
                usuarioDB.AtualizaEmpresa(usuario.Empresa.Id, empresas);                
                
                usuarioDB.AtualizaFilial(usuario.Filial.Id, filiais);
                
                usuarioDB.AtualizaPessoaFisica(usuario.PessoaFisica.Id, pessoasFisicas);

                usuarioDB.AtualizaEmail(usuario.Email);

                usuarioDB.AtualizaCelular(usuario.Celular);

                usuarioDB.AtualizaSenha(usuario.Senha);

                if (usuarioDB.Filial.Ativo == true && usuarioDB.PessoaFisica.Ativo == true)
                {
                    usuarioDB.AtualizaAtivo(usuario.Ativo);
                }

                await contexto.SaveChangesAsync();
            }
            else
            {

            }
        }
    }


}


