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

        public async Task DownloadResource(string source, string target)
        {
            if (!Directory.Exists(Path.GetDirectoryName(target)))
                Directory.CreateDirectory(Path.GetDirectoryName(target));

            await _webClient.DownloadFileTaskAsync(new Uri(source), target);
        }
        
    }
}
