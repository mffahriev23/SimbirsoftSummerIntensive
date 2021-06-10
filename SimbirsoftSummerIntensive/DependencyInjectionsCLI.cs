using Microsoft.Extensions.DependencyInjection;
using SimbirsoftSummerIntensive.Infrastructure.ConsoleReadData;
using SimbirsoftSummerIntensive.CLI.MenuCLI;
using System;
using System.Collections.Generic;
using System.Text;
using SimbirsoftSummerIntensive.Infrastructure.ConfigFile;
using SimbirsoftSummerIntensive.Infrastructure.DB.Interfaces;
using SimbirsoftSummerIntensive.Infrastructure.DB.Repositories;

namespace SimbirsoftSummerIntensive.CLI
{
    public static class DependencyInjectionsCLI
    {
        private static ServiceProvider _serviceProvider;

        public static void InitializeStart()
        {
            ManipulateConfigFile configFile = new ManipulateConfigFile();

            _serviceProvider = new ServiceCollection()
                                    .AddSingleton<IManipulateConfigFile, ManipulateConfigFile>(x => configFile)
                                    .AddSingleton<IManipulateConfig, ManipulateConfigJson>(x => new ManipulateConfigJson(configFile))
                                    .BuildServiceProvider();
        }

        public static IManipulateConfigFile GetConfigFileManipulate()
            => _serviceProvider.GetService<IManipulateConfigFile>();

        public static IManipulateConfig GetConfigManipulate()
            => _serviceProvider.GetService<IManipulateConfig>();
    }
}
