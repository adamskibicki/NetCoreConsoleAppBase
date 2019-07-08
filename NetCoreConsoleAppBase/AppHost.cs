using System;
using System.Threading.Tasks;

namespace NetCoreConsoleAppBase
{
    class AppHost
    {
        private readonly AppConfiguration _appConfiguration;

        public AppHost(AppConfiguration appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }

        public async Task Run(string[] args)
        {
            Console.WriteLine($"Hello, {_appConfiguration.ApplicationName}!");

            Console.ReadKey();
        }
    }
}
