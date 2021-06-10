using Microsoft.Extensions.Configuration;
using Serilog;
using SimbirsoftSummerIntensive.Core.DBContext;
using SimbirsoftSummerIntensive.Infrastructure;
using SimbirsoftSummerIntensive.Infrastructure.ModifyText;
using SimbirsoftSummerIntensive.Infrastructure.ReadDataFromFile;
using System;
using System.Threading.Tasks;

namespace SimbirsoftSummerIntensive.CLI
{
    public class Program
    {
        private static ILogger _logger;

        public static async Task Main(string[] args)
        {
            //_configuration = InitConfiguration(args);
            //_logger = InitLogger(_configuration["logPath"]);

            //try
            //{
            //    DependencyInjectionsCLI.InitializeStart();
            //    DependencyInjectionsCode.InitializeStart();

            //    DependencyInjectionsCLI.GetMenu().Show();
            //    string source = DependencyInjectionsCLI.GetMenu().GetEnteredData<string>();
            //    _logger.Information($"Ссылка на источник успешно получена: {source}.");

            //    await DependencyInjectionsCode.GetDownloadResourceService().DownloadResource(source,
            //                                                                $@"{_configuration["pathResource"]}{DateTime.Now.ToString("ddMMyyyyhhmmss")}.html");
            //    _logger.Information($"Данные из источника получены.");
            //}
            //catch (Exception ex)
            //{
            //    _logger.Error(ex, "Error.");
            //}

            //Console.ReadKey();

                Console.ReadKey();
        }

        private static ILogger InitLogger(string logDirectory)
            => new Serilog.LoggerConfiguration()
                   .WriteTo.File($"{logDirectory}\\{DateTime.Now.ToString("dd-MM-yyyy")}.log")
                   .CreateLogger();
    }
}
