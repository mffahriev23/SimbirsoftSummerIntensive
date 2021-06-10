using SimbirsoftSummerIntensive.Infrastructure.DataForStatistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SimbirsoftSummerIntensive.Tests
{
    public class DataForStatistic_Test
    {
        [Theory]
        [InlineData("Текст1     Текст2: Текст3 1221412? abc \n 234")]
        public void GetOnlyWords_List(string text)
        {
            IDataForStatistic act = new StatisticWordsIntoText();
            IEnumerable<string> statisticData = act.GetDataForStatistic(text);

            Assert.True(new List<string> { "Текст1", "Текст2", "Текст3", "1221412", "abc", "234" }.All(x => statisticData.Contains(x)));
        }
    }
}
