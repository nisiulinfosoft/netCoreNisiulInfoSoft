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
using NisiulInfoSoft.API.Microservicios.Context;
using NisiulInfoSoft.API.Microservicios.Helpers;
using NisiulInfoSoft.API.Microservicios.Process;
using NisiulInfoSoft.API.Microservicios.Services;

namespace NisiulInfoSoft.API.Microservicios
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
            string servidor = "Server=tcp:srvgalaxylema.database.windows.net,1433;Initial Catalog=bdventasgalaxy;Persist Security Info=False;User ID=galaxy;Password=A123456789123$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            services.AddDbContext<NisiulInfoSoftContext>(options => {
                options.UseSqlServer(servidor);
            });

            services.AddTransient<IPedidoServices, PedidoServices>();
            services.AddSingleton<IServiceBusTopicSubscription, ServiceBusTopicSubscription>();
            services.AddSingleton<IProcessData, ProcessData>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            //levatamos en listener para monitorear las suscripcion
            IServiceBusTopicSubscription suscriptor = app.ApplicationServices.GetService<IServiceBusTopicSubscription>();
            suscriptor.PrepareFiltersAndHandleMessages().GetAwaiter().GetResult();
        }
    }
}
