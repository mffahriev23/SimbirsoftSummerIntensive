using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SimbirsoftSummerIntensive.Infrastructure.ConsoleReadData
{
    public class CheckRightFolderPath : CheckRightInputData
    {
        protected override string _regular => "((?:[^/]*/)*)(.*)";
    }
}
