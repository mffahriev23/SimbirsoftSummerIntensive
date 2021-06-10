using System;
using System.Collections.Generic;
using System.Text;

namespace SimbirsoftSummerIntensive.Core.DBModels
{
    public class StatisticField
    {
        public long Id { get; set; }
        public string StatisticElement { get; set; }
        public long ResourseId { get; set; }

        public Resource Resource { get; set; }
    }
}
