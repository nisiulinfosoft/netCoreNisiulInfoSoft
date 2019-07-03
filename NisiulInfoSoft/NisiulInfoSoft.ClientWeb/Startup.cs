using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NisiulInfoSoft.ClientWeb.Context;
using NisiulInfoSoft.Context;
using NisiulInfoSoft.Repository;
using NisiulInfoSoft.Services;

namespace NisiulInfoSoft.ClientWeb
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

            ////Asi lo requiere google, se crea "SeguridadContext" context ficticio
            //services.AddDbContext<SeguridadContext>(
            //    option =>
            //    {
            //        option.UseSqlServer(Configuration.GetConnectionString("cnnNisiulInfoSoft"));
            //    }
            //);

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

            //Para injectar en pagina layout vista
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            ////Asi lo requiere google, se crea "SeguridadContext" context ficticio
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<SeguridadContext>()
            //    .AddDefaultTokenProviders();

            ////Uso con google
            //services.AddAuthentication().AddGoogle(

            //    opt =>
            //    {
            //        opt.ClientId = "370093857430-1hfeg4p3gtat2mv6or6i1c5tk4914i0g.apps.googleusercontent.com";
            //        opt.ClientSecret = "RBsWMgBYcfx2xqoAhXvxd8uj";
            //    }

            //    );

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //cookies
            services.AddDistributedMemoryCache();
            services.AddSession(

                options =>
                {
                    options.IdleTimeout = TimeSpan.FromSeconds(120);
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
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
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            //app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
