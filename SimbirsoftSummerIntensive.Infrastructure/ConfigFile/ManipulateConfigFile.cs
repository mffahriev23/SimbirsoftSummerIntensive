using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SimbirsoftSummerIntensive.Infrastructure.ConfigFile
{
    public class ManipulateConfigFile : IManipulateConfigFile
    {
        public string _configFileName { get => "appconfig.json"; }
        public string _filePath { get; set; }

        public bool CheckIsExistConfigFile(string folderPath)
            => File.Exists($"{folderPath}\\{_configFileName}");

        public void CreateConfigFile(string folderPath)
        {
            _filePath = $"{folderPath}\\{_configFileName}";

            if (!Directory.Exists(_filePath))
            {
                using (FileStream fs = File.Create(_filePath))
                { }
            }
        }

        public async Task<string> GetTextFromConfigFile()
            => await File.ReadAllTextAsync(_filePath);

        public void SetFilePath(string value)
            => _filePath = $"{value}\\{_configFileName}";


        public async Task SetTextToConfigFile(string configText)
            => await File.WriteAllTextAsync(_filePath, configText);
    }
}
