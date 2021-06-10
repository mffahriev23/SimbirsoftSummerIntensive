using Microsoft.Extensions.Configuration;
using Serilog;
using SimbirsoftSummerIntensive.CLI.BusinessLogic;
using SimbirsoftSummerIntensive.CLI.MenuCLI;
using SimbirsoftSummerIntensive.Core.DBContext;
using SimbirsoftSummerIntensive.Infrastructure;
using SimbirsoftSummerIntensive.Infrastructure.ConfigFile;
using SimbirsoftSummerIntensive.Infrastructure.ConsoleReadData;
using SimbirsoftSummerIntensive.Infrastructure.DB.Repositories;
using SimbirsoftSummerIntensive.Infrastructure.ModifyText;
using SimbirsoftSummerIntensive.Infrastructure.ReadDataFromFile;
using System;
using System.Collections.Generic;
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

            DependencyInjectionsCLI.InitializeStart();
            ConfigModel config = new ConfigModel();

            for(; ; )
            {
                try
                {
                    if (!DependencyInjectionsCLI.GetConfigFileManipulate().CheckIsExistConfigFile(Environment.CurrentDirectory))
                    {
                        DependencyInjectionsCLI.GetConfigFileManipulate().CreateConfigFile(Environment.CurrentDirectory);

                        config.logFolderPath = GetInputedData(new MenuLogFolderPath(new CheckRightFolderPath()));
                        config.dataFolderPath = GetInputedData(new MenuKeeperDownLoadedFiles(new CheckRightFolderPath()));
                        config.connectionString = GetInputedData(new MenuConnectionString(new CheckRightConnectionString()));

                        await DependencyInjectionsCLI.GetConfigManipulate().SetConfigs(config);
                    }
                    else
                        DependencyInjectionsCLI.GetConfigFileManipulate().SetFilePath(Environment.CurrentDirectory);

                    config = await DependencyInjectionsCLI.GetConfigManipulate().GetConfigs();
                    AppDbContext context = new AppDbContext(config.connectionString);
                    _logger = InitLogger(config.logFolderPath);

                    for (; ; )
                    {
                        try
                        {
                            string url = GetInputedData(new MenuDowloadFile(new CheckRightUrl()));
                            IBusinessLogic<IDictionary<string, int>> statisticGetter = new StatisticWordsIntoHtml(url, config.dataFolderPath, _logger,
                                                                                                            new ResourseRepository(context), new StatisticFieldRepository(context));

                            IDictionary<string, int>  statistic = await statisticGetter.GetFinalData();

                            foreach (var s in statistic)
                                Console.WriteLine($"{s.Key}-{s.Value}");
                        }
                        catch(Exception ex)
                        {
                            _logger.Error(ex, string.Empty);
                            Console.WriteLine($"Возникла ошибка. Подробнее смотрите в логи.{ex.Message}");
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Не удалось сохранить конфиг.{ex.Message}");
                }
            }
        }

        private static ILogger InitLogger(string logDirectory)
            => new Serilog.LoggerConfiguration()
                   .WriteTo.File($"{logDirectory}\\{DateTime.Now.ToString("dd-MM-yyyy")}.log")
                   .CreateLogger();

        private static string GetInputedData(IMenu menu)
        {
            menu.Show();
            return menu.GetEnteredData<string>();
        }
    }
}
