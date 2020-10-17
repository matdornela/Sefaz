using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sefaz.Configuracao;
using Sefaz.Infraestrutura.DAL.EF;
using System;

namespace Sefaz.Api
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }

        public Startup(IConfiguration configuration)
        {
            using (var client = new SefazContext())
            {
                client.Database.EnsureCreated();
            }

            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlite().AddDbContext<SefazContext>();
            services.AddControllers();

            services.AddSingleton<IConfiguration>(_configuration); //add Configuration to our services collection
            
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

            //Configuracao Autofac
            this.ApplicationContainer = ConfiguracaoAutofac.ConfigurarDI(services);

            //Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(ApplicationContainer);
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
            });
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API MENOR PRECO - SEFAZ");
                c.RoutePrefix = string.Empty;
            });

            ConfiguracaoAutoMapper.AutoMapperMapear();
        }
    }
}