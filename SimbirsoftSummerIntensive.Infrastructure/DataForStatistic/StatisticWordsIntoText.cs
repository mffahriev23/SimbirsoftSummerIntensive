using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SimbirsoftSummerIntensive.Infrastructure.DataForStatistic
{
    public class StatisticWordsIntoText : IDataForStatistic
    {
        private readonly string _regex = @"[\w]+";

        public IEnumerable<string> GetDataForStatistic(string text)
        {
            foreach (Match match in Regex.Matches(text, _regex))
               yield return match.Value;
        }
    }
}
