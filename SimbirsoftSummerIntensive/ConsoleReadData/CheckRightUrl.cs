using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SimbirsoftSummerIntensive.CLI.ConsoleReadData
{
    public class CheckRightUrl : ICheckRightInputData
    {
        private readonly string _regular = @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";

        public bool CheckRightInputData(string url)
            => Regex.IsMatch(url, _regular, RegexOptions.IgnoreCase);
    }
}
