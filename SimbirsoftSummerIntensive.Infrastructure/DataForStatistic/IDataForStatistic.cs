using System;
using System.Collections.Generic;
using System.Text;

namespace SimbirsoftSummerIntensive.Infrastructure.DataForStatistic
{
    public interface IDataForStatistic
    {
        IEnumerable<string> GetDataForStatistic(string text);
    }
}
