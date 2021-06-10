using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SimbirsoftSummerIntensive.Infrastructure.ConsoleReadData
{
    public class CheckRightUrl : CheckRightInputData
    {
       protected override string _regular => @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
    }
}
