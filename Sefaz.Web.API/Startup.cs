using Autofac;
using Autofac.Extensions.DependencyInjection;
using Infopen.Apresentacao.WorkServices;
using Infopen.Configuracao;
using Infopen.Web.API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Infopen.Web.API
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }

        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
            ConfiguracaoAudit.Configure(env, configuration);
        }

        public IConfiguration _configuration { get; }
        public IHostingEnvironment _env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var infopenClientCredentialsConfiguration = new InfopenBiometriaClientCredentialsConfiguration();
            _configuration.Bind("InfopenClientCredentials", infopenClientCredentialsConfiguration);

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<IConfiguration>(_configuration); //add Configuration to our services collection

            services.AddHealthChecks();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<BiometriaWorkService>();

            services.AddAuthentication(auth =>
            {
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = infopenClientCredentialsConfiguration.Authority;
                options.TokenValidationParameters.ValidateAudience = false;
                options.RequireHttpsMetadata = false;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("geral", builder =>
                {
                    builder.RequireScope(infopenClientCredentialsConfiguration.Scopes.First());
                });
            });

            // Configuracao Autofac
            this.ApplicationContainer = ConfiguracaoAutofac.ConfigurarDI(services);

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();

            app.UseHealthChecks("/health/live");

            ConfiguracaoAutoMapper.AutoMapperMapear();

        }
    }
}
