using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SimbirsoftSummerIntensive.CLI.ConsoleReadData
{
    public class CheckRightConnectionString: ICheckRightInputData
    {
        private readonly string _regular = @"(?<key>[^=;,]+)=(?<val>[^;,]+(,\d+)?)";

        public bool CheckRightInputData(string url)
           => Regex.IsMatch(url, _regular, RegexOptions.IgnoreCase);
    }
}
