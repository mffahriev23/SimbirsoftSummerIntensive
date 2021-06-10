using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimbirsoftSummerIntensive.Infrastructure.ConfigFile
{
    public class ManipulateConfigJson : IManipulateConfig
    {
        private IManipulateConfigFile _configFileManipulate;

        public ManipulateConfigJson(IManipulateConfigFile configFileManipulate)
            => _configFileManipulate = configFileManipulate;

        public async Task<ConfigModel> GetConfigs()
            => JsonConvert.DeserializeObject<ConfigModel>(await _configFileManipulate.GetTextFromConfigFile());


        public async Task SetConfigs(ConfigModel configModel)
            => await _configFileManipulate.SetTextToConfigFile(JsonConvert.SerializeObject(configModel));
    }
}
