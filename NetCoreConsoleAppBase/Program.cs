using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NetCoreConsoleAppBase
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .Build();

            IServiceCollection serviceCollection = new ServiceCollection()
                .AddSingleton<AppConfiguration, AppConfiguration>(provider =>
                    configuration.Get<AppConfiguration>())
                .AddSingleton<AppHost, AppHost>();

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            await serviceProvider.GetService<AppHost>().Run(args);
        }
    }
}
