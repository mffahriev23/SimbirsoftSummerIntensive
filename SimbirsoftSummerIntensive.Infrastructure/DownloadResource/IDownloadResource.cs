using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimbirsoftSummerIntensive.Infrastructure.DownloadResource
{
    public interface IDownloadResource
    {
        public Task DownloadResource(string source);
        Task<string> GetDataFromResourse();
    }
}
