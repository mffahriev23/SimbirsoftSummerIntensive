using Microsoft.Extensions.DependencyInjection;
using SimbirsoftSummerIntensive.Infrastructure.ConsoleReadData;
using SimbirsoftSummerIntensive.CLI.MenuCLI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimbirsoftSummerIntensive.CLI
{
    public static class DependencyInjectionsCLI
    {
        private static ServiceProvider _serviceProvider;

        public static void InitializeStart()
        {
            _serviceProvider = new ServiceCollection()
                                    .AddSingleton<IMenu, MenuDowloadFile>()
                                    .AddSingleton<CheckRightInputData, CheckRightUrl>()
                                    .BuildServiceProvider();
        }

        public static IMenu GetMenu()
            => _serviceProvider.GetService<IMenu>();

        public static CheckRightInputData GetCheckSourcePath()
            => _serviceProvider.GetService<CheckRightInputData>();
    }
}
