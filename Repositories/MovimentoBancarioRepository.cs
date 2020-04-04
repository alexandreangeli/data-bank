using System.Collections.Generic;
using System.Threading.Tasks;
using DataBank.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBank.Repositories
{
    public interface IMovimentoBancarioRepository
    {
        Task<MovimentoBancario> GetMovimentoBancario(int movimentoBancarioId);
        Task<List<MovimentoBancario>> GetMovimentosBancarios();
        //Task UpdateUsuario(Usuario usuario, List<Empresa> empresas, List<Filial> filiais, List<PessoaFisica> pessoasFisicas, List<PostoDeCaixa> postosDeCaixa);
    }

    public class MovimentoBancarioRepository : BaseRepository<MovimentoBancario>, IMovimentoBancarioRepository
    {
        public MovimentoBancarioRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<MovimentoBancario> GetMovimentoBancario(int movimentoBancarioId)
        {
            return await dbSet
                .Include(u => u.ContaCorrente)
                .ThenInclude(u => u.Filial)
                .ThenInclude(u => u.PessoaJuridica)
                .FirstOrDefaultAsync(b => b.Id == movimentoBancarioId);
        }

        public async Task<List<MovimentoBancario>> GetMovimentosBancarios()
        {
            return await dbSet
                .Include(u => u.ContaCorrente)
                .ThenInclude(u => u.Filial)
                .ThenInclude(u => u.PessoaJuridica)
                .ToListAsync();
        }

        //public async Task UpdateUsuario(Usuario usuario, List<Empresa> empresas, List<Filial> filiais, List<PessoaFisica> pessoasFisicas, List<PostoDeCaixa> postosDeCaixa)
        //{
        //    var usuarioDB = await GetUsuario(usuario.Id);

        //    if (usuarioDB != null)
        //    {
        //        usuarioDB.AtualizaEmpresa(usuario.Empresa.Id, empresas);                
                
        //        usuarioDB.AtualizaFilial(usuario.Filial.Id, filiais);

        //        foreach (var posto in postosDeCaixa)
        //        {
        //            posto.Usuario = null;
        //        }
        //        usuarioDB.AtualizaPessoaFisica(usuario.PessoaFisica.Id, pessoasFisicas);

        //        usuarioDB.AtualizaEmail(usuario.Email);

        //        usuarioDB.AtualizaCelular(usuario.Celular);

        //        usuarioDB.AtualizaSenha(usuario.Senha);

        //        if (usuarioDB.Filial.Ativo == true && usuarioDB.PessoaFisica.Ativo == true)
        //        {
        //            usuarioDB.AtualizaAtivo(usuario.Ativo);
        //        }

        //        await contexto.SaveChangesAsync();
        //    }
        //    else
        //    {

        //    }
        //}
    }


}


