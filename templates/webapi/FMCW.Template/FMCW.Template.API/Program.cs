using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.FastConsole;

namespace FMCW.Template.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                  .ConfigureLogging((hostingContext, logging) =>
                  {
                      logging.ClearProviders()
                          .AddSerilog(new LoggerConfiguration()
                              .ReadFrom.Configuration(hostingContext.Configuration, "Logging")
                              .Enrich.FromLogContext()
                              .Enrich.WithThreadId()
                              .Enrich.WithProcessId()
                              .Enrich.WithMachineName()
                              .WriteTo
                              .FastConsole(new FastConsoleSinkOptions { UseJson = false })
                              .WriteTo
                              .File("log.log", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 14)
                              .CreateLogger());
                  })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
