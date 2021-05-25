using Ingaia.Data.Base;
using Ingaia.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TesteIngaia.Repository;
using TesteIngaia2.Repository.Interface;

namespace TesteIngaia2
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

            //var bancoContext = new BancoContext(config.MongoDB);
            //var repo = new ValorUnidadeMedidaRepository(bancoContext);

            services.AddTransient<IBancoContext, BancoContext>();

            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddTransient<IValorUnidadeMedidaRepository, ValorUnidadeMedidaRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new Info
                {
                    Title = "INGAIA API",
                    Version = "v2",
                    Description = "API_2 retorno do valor das unidades de medidas",
                    Contact = new Contact
                    {
                        Name = "Emerson Schulze",
                        Email = "emerson7e@gmail.com"
                    }
                });
              
            });
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "INGAIA API V2 DDD");
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
