using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimbirsoftSummerIntensive.Core.DBModels
{
    public class Resource
    {
        public long Id { get; set; }
        [StringLength(10000)]
        public string Text { get; set; }
        [StringLength(10000)]
        [RegularExpression("((?:[^/]*/)*)(.*)")]
        public string FilePath { get; set; }
        public DateTimeOffset Created { get; set; }

        public IList<StatisticField> StatisticFields { get; set; }
    }
}
