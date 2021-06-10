using System;
using System.Collections.Generic;
using System.Text;

namespace SimbirsoftSummerIntensive.Core.DBModels
{
    public class Resource
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public DateTimeOffset Created { get; set; }

        public IList<StatisticField> StatisticFields { get; set; }
    }
}
