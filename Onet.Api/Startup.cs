using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Onet.Cliente.Repositories.Cliente.Implementations;
using Onet.Cliente.Repositories.Cliente.Interfaces;
using Onet.Cliente.Services.Cliente.Implementations;
using Onet.Cliente.Services.Cliente.Interfaces;
using Onet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onet.Api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Onet.Api", Version = "v1" });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<DbSession>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            // Client
            services.AddScoped<IClienteGetAllRepository, ClienteGetAllRepository>();
            services.AddScoped<IClienteGetAllServices, ClienteGetAllServices>();

            services.AddScoped<IClientGetByIdRepository, ClientGetByIdRepository>();
            services.AddScoped<IClientGetByIdService, ClientGetByIdService>();

            services.AddScoped<IClieteCreateRepository, ClieteCreateRepository>();
            services.AddScoped<IClieteCreateServices, ClieteCreateServices>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Onet.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
