using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;

namespace NewsFood.Api
{
    public class Program
    {
        public IConfiguration Configuration { get; }
        public Program(IConfiguration configuration)
        {}

        public static void Main(string[] args)
        {
            NLog.Web.NLogBuilder.ConfigureNLog("nlog.config");
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
           .UseStartup<Startup>()
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
