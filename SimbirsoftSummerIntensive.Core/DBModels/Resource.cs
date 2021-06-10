using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimbirsoftSummerIntensive.Core.DBModels
{
    public class Resource
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [StringLength(10000)]
        public string SourcePath { get; set; }
        [StringLength(10000)]
        [RegularExpression("((?:[^/]*/)*)(.*)")]
        public string FilePath { get; set; }
        public DateTimeOffset Created { get; set; }

        public IList<StatisticField> StatisticFields { get; set; }
    }
}
