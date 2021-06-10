using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SimbirsoftSummerIntensive.CLI.ConsoleReadData
{
    public class CheckRightFolderPath : ICheckRightInputData
    {
        public string _regular = "((?:[^/]*/)*)(.*)";

        public bool CheckRightInputData(string url)
           => Regex.IsMatch(url, _regular, RegexOptions.IgnoreCase);
    }
}
