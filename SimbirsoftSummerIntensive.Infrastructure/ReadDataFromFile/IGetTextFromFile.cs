using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimbirsoftSummerIntensive.Infrastructure.ReadDataFromFile
{
    public interface IGetTextFromFile
    {
        Task<string> GetTextFromFile();
        void SetFilePath(string sourcePath);
    }
}
