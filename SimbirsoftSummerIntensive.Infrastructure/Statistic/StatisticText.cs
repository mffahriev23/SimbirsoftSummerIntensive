using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimbirsoftSummerIntensive.Infrastructure.Statistic
{
    public class StatisticText : IGetStatisticText
    {
        public IDictionary<string, int> GetStatisticText(IEnumerable<string> words)
        {
            IDictionary<string, int> tempStatistic = new Dictionary<string, int>();

            words.ToList().ForEach(word => 
            { 
                if(!tempStatistic.Any(x => x.Key == word))
                    tempStatistic.Add(word, words.Count(x => x == word));
            });

            return tempStatistic;
        }
    }
}
