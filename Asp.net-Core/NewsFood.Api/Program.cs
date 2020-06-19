using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;
using Microsoft.Extensions.Hosting;
using NewsFood.Api.ExtensionService;

namespace NewsFood.Api
{
    public class Program
    {
        public IConfiguration Configuration { get; }
        public Program(IConfiguration configuration)
        {
        }

        public static void Main(string[] args)
        {
            NLog.Web.NLogBuilder.ConfigureNLog("nlog.config");
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
           .UseStartup<Startup>()
          .ConfigureKestrel(kastrel =>
          {
              kastrel.ConfigureEndpoints();
          })
           .UseContentRoot(Directory.GetCurrentDirectory())
           .ConfigureAppConfiguration((hostingContext, config) =>
           {
               var currentDirector = Directory.GetCurrentDirectory();
               var env = hostingContext.HostingEnvironment;
               config.AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true);
               if (hostingContext.HostingEnvironment.IsDevelopment())
               {
                   config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
               }
               config.AddEnvironmentVariables();
           })
           .ConfigureLogging((hostingContext, logging) =>
           {
               logging.ClearProviders();
               logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
               if (hostingContext.HostingEnvironment.IsDevelopment())
               {
                   logging.AddConsole();
               }
           })
           .UseNLog();
    }
}
