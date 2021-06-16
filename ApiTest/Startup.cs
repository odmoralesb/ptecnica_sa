using ApiTest.Common.Domain.AutoMapperProfiles;
using ApiTest.Common.Domain.Repository;
using ApiTest.Common.Domain.Services;
using ApiTest.Common.Domain.Settings;
using ApiTest.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTest.Common.Persistence.Context;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using SharedAuditRequestResponseLibrary.AspNetCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ApiTest
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

            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("Database"));
            });

            // Repositorios
            services.AddScoped<IContratoslaboralesRepository, ContratoslaboralesRepository>();

            //services
            services.AddScoped<IContratoslaboralesService, IContratoslaboralesService>();            

            // Settings
            services.Configure<ClasesParametrosSettings>(
                Configuration.GetSection(nameof(ClasesParametrosSettings)));

            services.AddSingleton<IClasesParametrosSettings>(sp =>
                sp.GetRequiredService<IOptions<ClasesParametrosSettings>>().Value);  


            // activar Swagger
            services.AddCustomSwaggerGen();
            services.AddCustomApiVersioning();

            
           // Configuración AutoMapper
            services.AddAutoMapper(config =>
            {
                config.AddProfile<TestProfile>();
            });
            
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            }); // activar Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test API V1");
            });
        }

    }
}
