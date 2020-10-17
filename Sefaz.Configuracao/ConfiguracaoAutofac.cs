using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Sefaz.Infraestrutura.DAL.EF;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Sefaz.Configuracao
{
    public class ConfiguracaoAutofac
    {
        public static IContainer ConfigurarDI(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            var assemblies = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.TopDirectoryOnly)
                .Where(filePath => Path.GetFileName(filePath).StartsWith("Sefaz") && !Path.GetFileName(filePath).Contains("Configuracao"))
                .Select(Assembly.LoadFrom).ToArray();

            builder.RegisterType<SefazContext>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assemblies)
                .AsImplementedInterfaces();

            builder.Populate(services);

            return builder.Build();
        }
    }
}