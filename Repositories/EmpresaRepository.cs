using Databank.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Databank.Repositories
{
    public interface IEmpresaRepository
    {
        Task SaveEmpresa(List<EmpresaJson> Empresas);
        Task<List<Empresa>> GetEmpresas();
        Task<Empresa> GetEmpresa(int EmpresaId);
        Task UpdateEmpresa(Empresa Empresa);      
    }


    public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public EmpresaRepository(ApplicationContext contexto, IHttpContextAccessor httpContextAccessor) : base(contexto)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task SaveEmpresa(List<EmpresaJson> Empresas)
        {
            foreach (var Empresa in Empresas)
            {
                if (!await dbSet.Where(p => p.Nome == Empresa.Nome).AnyAsync())
                {
                    await dbSet.AddAsync(new Empresa(Empresa.Nome, Empresa.Sigla, Empresa.Ativo));
                }
            }
            await contexto.SaveChangesAsync();
        }

        public async Task<List<Empresa>> GetEmpresas()
        {
            return await dbSet
                .Include(e => e.Filiais)
                .ThenInclude(f => f.Usuarios)
                .Include(e => e.Filiais)
                .ThenInclude(f => f.PostosDeCaixa)
                .Where(u => u.Id != 1)
                .ToListAsync();
        }

        public async Task<Empresa> GetEmpresa(int EmpresaId)
        {
            return await dbSet
                .Include(e => e.Filiais)
                .ThenInclude(f => f.Usuarios)
                .Include(e => e.Filiais)
                .ThenInclude(f => f.PostosDeCaixa)
                .Where(u => u.Id != 1)
                .FirstOrDefaultAsync(e => e.Id == EmpresaId);
        }


        public async Task UpdateEmpresa(Empresa empresa)
        {
            var empresaDB = await GetEmpresa(empresa.Id);


            if (empresaDB != null)
            {
                empresaDB.AtualizaNome(empresa.Nome);
                empresaDB.AtualizaSigla(empresa.Sigla);
                empresaDB.AtualizaAtivo(empresa.Ativo);
                await contexto.SaveChangesAsync();
            }
            else
            {
                
            }            
        }
        

    }

    public class EmpresaJson
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public bool Ativo { get; set; }
    }
}
