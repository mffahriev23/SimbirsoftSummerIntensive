using SimbirsoftSummerIntensive.Core.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimbirsoftSummerIntensive.Infrastructure.DB.Interfaces
{
    interface IResourseRepository: IRepository<Resource>
    {
        public Task<List<Resource>> GetFreshResourseWithStatistic();
    }
}
