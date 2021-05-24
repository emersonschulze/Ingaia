using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using MongoDB.Driver;
using TesteIngaia.Data;
using TesteIngaia.Config;
using TesteIngaia.Repository;
using TesteIngaia.Repository.Interface;
using System.Reflection;
using System.IO;

namespace TesteIngaia
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
            var config = new ServerConfig();
            Configuration.Bind(config);

            var bancoContext = new BancoContext(config.MongoDB);
            var repo = new ValorUnidadeMedidaRepository(bancoContext);

            services.AddSingleton<IValorUnidadeMedidaRepository>(repo);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "INGAIA API",
                    Version = "v1",
                    Description = "API_1 retorno do valor das unidades de medidas",
                });
                //  var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //  var xmlPath = Path.Combine(BancoContext.BaseDirectory, xmlFile);
                //  c.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "INGAIA API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
