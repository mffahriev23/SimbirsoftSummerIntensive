using System;
using System.Collections.Generic;
using System.Text;

namespace SimbirsoftSummerIntensive.Infrastructure.ConfigFile
{
    public class ConfigModel
    {
        public string connectionString { get; set; }
        public string logFolderPath { get; set; }
        public string dataFolderPath { get; set; }
    }
}
