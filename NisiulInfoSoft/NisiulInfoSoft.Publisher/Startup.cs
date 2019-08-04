using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NisiulInfoSoft.Publisher.Helpers;
using NisiulInfoSoft.Publisher.Models;

namespace NisiulInfoSoft.Publisher
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
            //Inicio para tomar tomar valores de appsettings.json
            services.AddOptions();
            services.Configure<ParametroConfig>(Configuration);


            string url = Environment.GetEnvironmentVariable("Urlidentity");
            if (string.IsNullOrEmpty(url))
            {
                url = Configuration.GetValue<string>("Urlidentity");
            }

            string apiName = Environment.GetEnvironmentVariable("ApiName");
            if (string.IsNullOrEmpty(apiName))
            {
                apiName = Configuration.GetValue<string>("ApiName");
            }
            //Fin para tomar tomar valores de appsetting.json

            services.AddSingleton<ServiceBusTopicSender>();

            services.AddAuthentication("Bearer")
               .AddIdentityServerAuthentication(option =>
               {
                   option.Authority = url; //Url del aplicativo identityserver4
                   option.RequireHttpsMetadata = false;
                   option.ApiName = apiName;
               });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
