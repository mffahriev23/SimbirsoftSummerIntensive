using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SimbirsoftSummerIntensive.Infrastructure.ModifyText
{
    public class GetClearedJS: IModifyText
    {
        private readonly string _regex = @"<script(.*)>[\w\W]*?<\/script>";

        public void GetModifiedText(ref string text)
        => text = Regex.Replace(text, _regex, String.Empty);
    }
}
