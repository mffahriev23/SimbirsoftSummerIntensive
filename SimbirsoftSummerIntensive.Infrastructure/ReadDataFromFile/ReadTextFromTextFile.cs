using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbirsoftSummerIntensive.Infrastructure.ReadDataFromFile
{
    public class ReadTextFromTextFile : IGetTextFromFile
    {
        private FileInfo _file;

        public void SetFilePath(string sourcePath)
            => _file = new DirectoryInfo(sourcePath).GetFiles()
                                                    .OrderByDescending(x => x.LastWriteTime)
                                                    .SingleOrDefault();

        public async Task<string> GetTextFromFile()
            => (await File.ReadAllTextAsync(_file.FullName));

    }
}
