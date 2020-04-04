using Databank.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Databank
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext contexto;
        private readonly IBancoRepository bancoRepository;
        private readonly IEmpresaRepository EmpresaRepository;

        public DataService(ApplicationContext contexto,
            IBancoRepository bancoRepository, IEmpresaRepository EmpresaRepository
         )
        { 
            this.contexto = contexto;
            this.bancoRepository = bancoRepository;
            this.EmpresaRepository = EmpresaRepository;
        }

        public async Task InicializaDB()
        {
            await contexto.Database.MigrateAsync();
        }
    }
}
