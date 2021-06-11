using Microsoft.Extensions.Configuration;
using Serilog;
using SimbirsoftSummerIntensive.CLI.BusinessLogic;
using SimbirsoftSummerIntensive.CLI.MenuCLI;
using SimbirsoftSummerIntensive.Core.DBContext;
using SimbirsoftSummerIntensive.Infrastructure.ConfigFile;
using SimbirsoftSummerIntensive.Infrastructure.ConsoleReadData;
using SimbirsoftSummerIntensive.Infrastructure.DB.Repositories;
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
            Console.WriteLine("Старт приложения");

            DependencyInjectionsCLI.InitializeStart();
            ConfigModel config = new ConfigModel();

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
                        IBusinessLogic<IDictionary<string, int>> statisticGetter = new StatisticWordsIntoHtml(url, $"{config.dataFolderPath}/{DateTime.Now.ToString("yyyyMMddhhmmssff")}.html", _logger,
                                                                                                        new ResourseRepository(context), new StatisticFieldRepository(context));

                        Console.WriteLine("Выполняется анализ . . .");
                        
                        IDictionary<string, int>  statistic = await statisticGetter.GetFinalData();

                        Console.WriteLine("*****РЕЗУЛЬТАТ*****");
                        foreach (var s in statistic)
                            Console.WriteLine($"{s.Key}-{s.Value}");
                        Console.WriteLine("*****КОНЕЦ*****");
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

        private static ILogger InitLogger(string logDirectory)
            => new LoggerConfiguration()
                   .WriteTo.File($"{logDirectory}\\{DateTime.Now.ToString("dd-MM-yyyy")}.log")
                   .CreateLogger();

        private static string GetInputedData(IMenu menu)
        {
            menu.Show();
            return menu.GetEnteredData<string>();
        }
    }
}
