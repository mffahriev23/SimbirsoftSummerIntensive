using System;
using System.Collections.Generic;
using System.Text;

namespace SimbirsoftSummerIntensive.Infrastructure.Statistic
{
    public interface IGetStatisticText
    {
        public IDictionary<string, int> GetStatisticText(IEnumerable<string> words);
    }
}
