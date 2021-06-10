using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimbirsoftSummerIntensive.Infrastructure.ConfigFile
{
    public interface IManipulateConfig
    {
        public Task SetConfigs(ConfigModel configModel);
        public Task<ConfigModel> GetConfigs();
    }
}
