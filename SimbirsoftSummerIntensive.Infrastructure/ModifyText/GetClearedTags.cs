using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SimbirsoftSummerIntensive.Infrastructure.ModifyText
{
    public class GetClearedTags : IModifyText
    {
        private readonly string _regex = @"<[^>]*>";

        public void GetModifiedText(ref string text)
        => text = Regex.Replace(text, _regex, String.Empty);
    }
}
