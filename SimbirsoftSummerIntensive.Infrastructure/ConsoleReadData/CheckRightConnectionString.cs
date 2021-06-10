using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SimbirsoftSummerIntensive.Infrastructure.ConsoleReadData
{
    public class CheckRightConnectionString: CheckRightInputData
    {
        protected override string _regular => @"(?<key>[^=;,]+)=(?<val>[^;,]+(,\d+)?)";
    }
}
