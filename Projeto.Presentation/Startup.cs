using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Projeto.Infra.Data.Contexts;
using Projeto.Infra.Data.Repositories;

namespace Projeto.Presentation
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();


            services.AddDbContext<DataContext>
                (options => options.UseSqlServer
                (Configuration.GetConnectionString("ProjetoGerenciadorTarefa")));
            
            
            services.AddTransient<UsuarioRepository>();
            services.AddTransient<TarefaRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(); //habilitar a pasta \wwwroot
           
            app.UseCookiePolicy(); 
            app.UseAuthentication(); 
           
            
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(
            endpoints =>
            {
                endpoints.MapControllerRoute(name: "default",
                    pattern: "{controller=Account}/{action=Login}");
            });

        }
    }
}
