using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimbirsoftSummerIntensive.Infrastructure.ConfigFile
{
    public interface IManipulateConfigFile
    {
        public bool CheckIsExistConfigFile(string folderPath);
        public string _configFileName { get; }
        public string _filePath { get; set; }
        public void SetFilePath(string value);
        public void CreateConfigFile(string folderPath);
        public Task<string> GetTextFromConfigFile();
        public Task SetTextToConfigFile(string configText);
    }
}
