using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimbirsoftSummerIntensive.Infrastructure.DownloadResource
{
    public class DownloadFileByUrl : IDownloadResource
    {
        private readonly WebClient _webClient = new WebClient();
        private readonly string _filePath;

        public DownloadFileByUrl(string filePath)
            => _filePath = filePath;

        public async Task DownloadResource(string source)
        {
            if (!Directory.Exists(Path.GetDirectoryName(_filePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(_filePath));

            await _webClient.DownloadFileTaskAsync(new Uri(source), _filePath);
        }

        public async Task<string> GetDataFromResourse()
            => (await File.ReadAllTextAsync(_filePath));
    }
}
