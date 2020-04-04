using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBank.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataBank
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSession();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                   .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
               options =>
               {
                   options.LoginPath = new PathString("/Usuarios/Login");
                   options.AccessDeniedPath = new PathString("/Home/Inicio");
               });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddDistributedMemoryCache();

            string connectionString = Configuration.GetConnectionString("Default");

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlite(connectionString));

            services.AddTransient<IDataService, DataService>();
            services.AddTransient<IBancoRepository, BancoRepository>();
            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<IFilialRepository, FilialRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IPessoaFisicaRepository, PessoaFisicaRepository>();
            services.AddTransient<IPessoaJuridicaRepository, PessoaJuridicaRepository>();
            services.AddTransient<IAgenciaRepository, AgenciaRepository>();
            services.AddTransient<IContaCorrenteRepository, ContaCorrenteRepository>();
            services.AddTransient<IPostoDeCaixaRepository, PostoDeCaixaRepository>();
            services.AddTransient<IMovimentoBancarioRepository, MovimentoBancarioRepository>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Inicio}/{id?}");
            });

            serviceProvider.GetService<IDataService>().InicializaDB().Wait();
        }
    }
}
