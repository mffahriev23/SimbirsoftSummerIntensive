using Microsoft.Extensions.DependencyInjection;
using SimbirsoftSummerIntensive.Core.DBContext;
using SimbirsoftSummerIntensive.Infrastructure.DownloadResource;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimbirsoftSummerIntensive.Infrastructure
{
    public static class DependencyInjectionsCode
    {
        private static ServiceProvider _serviceProvider;

        public static void InitializeStart()
        {
            _serviceProvider = new ServiceCollection()
                                    .AddSingleton<AppDbContext>( x => new AppDbContext("Server=DESKTOP-73G6TMG\\SQLEXPRESS;Database=Simbirsoft;Trusted_Connection=True;MultipleActiveResultSets=true"))
                                    .BuildServiceProvider();
        }

        public static IDownloadResource GetDownloadResourceService()
            => _serviceProvider.GetService<IDownloadResource>();
    }
}
