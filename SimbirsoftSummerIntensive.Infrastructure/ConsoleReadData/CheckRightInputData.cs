using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SimbirsoftSummerIntensive.Infrastructure.ConsoleReadData
{
    public abstract class CheckRightInputData
    {
        protected virtual string _regular { get; }
        public bool CheckRight(string inputData)
             => Regex.IsMatch(inputData, _regular, RegexOptions.IgnoreCase);
    }
}
