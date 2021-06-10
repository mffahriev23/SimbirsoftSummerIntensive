using SimbirsoftSummerIntensive.Infrastructure.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SimbirsoftSummerIntensive.Tests
{
    public class StatisticText_Test
    {
        [Fact]
        public void Statistic_Text()
        {
            IEnumerable<string> words = new List<string> { "Текст1", "Текст2", "Текст1" };

            IGetStatisticText statistic = new StatisticText();
            IDictionary<string, int> result = statistic.GetStatisticText(words);

            Assert.True(new Dictionary<string, int> { 
                { "Текст1", 2},
                { "Текст2", 1}
            }.All(x => result.Contains(x)));
        }
    }
}
