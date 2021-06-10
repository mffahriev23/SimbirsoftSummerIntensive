using Microsoft.Extensions.DependencyInjection;
using SimbirsoftSummerIntensive.CLI.ConsoleReadData;
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
                                    .AddSingleton<ICheckRightInputData, CheckRightUrl>()
                                    .BuildServiceProvider();
        }

        public static IMenu GetMenu()
            => _serviceProvider.GetService<IMenu>();

        public static ICheckRightInputData GetCheckSourcePath()
            => _serviceProvider.GetService<ICheckRightInputData>();
    }
}
