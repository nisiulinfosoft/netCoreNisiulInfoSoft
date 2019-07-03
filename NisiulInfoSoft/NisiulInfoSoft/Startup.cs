using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NisiulInfoSoft.Context;
using NisiulInfoSoft.Repository;
using NisiulInfoSoft.Services;

namespace NisiulInfoSoft
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NisiulInfoSoftContext>(
                option =>
                {
                    option.UseSqlServer(Configuration.GetConnectionString("cnnNisiulInfoSoft"));
                }
            );

            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<ICargoService, CargoService>();
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IPersonalService, PersonalService>();
            services.AddScoped<IPersonalRepository, PersonalRepository>();
            services.AddScoped<ITipoUsuarioService, TipoUsuarioService>();
            services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddCors(
                options =>
                {
                    options.AddPolicy("AllTrafic", config =>
                    {
                        config.AllowAnyHeader().AllowAnyMethod()
                        .AllowAnyOrigin().AllowCredentials();
                    });
                }
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllTrafic");
            app.UseMvc();
        }
    }
}
