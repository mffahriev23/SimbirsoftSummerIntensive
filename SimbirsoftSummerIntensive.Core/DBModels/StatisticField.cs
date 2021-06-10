using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimbirsoftSummerIntensive.Core.DBModels
{
    public class StatisticField
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string StatisticElement { get; set; }
        public int Count { get; set; }
        public long ResourseId { get; set; }

        public Resource Resource { get; set; }
    }
}
