using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebAppAspnetcore.Data;
using Microsoft.Extensions.DependencyInjection;


namespace WebAppAspnetcore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            SeedDB(host);

            host.Run();
            //CreateWebHostBuilder(args).Build().Run();
        }

        private static void SeedDB(IWebHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<DutchSeeder>();
                seeder.Seed();
            }

        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .ConfigureAppConfiguration(SetupConfiguration)
                  .UseStartup<Startup>().Build();

        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            builder.Sources.Clear();
            builder.AddJsonFile("config.json", false, true);
        }
    }
}