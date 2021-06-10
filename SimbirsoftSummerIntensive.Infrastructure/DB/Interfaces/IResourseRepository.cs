using SimbirsoftSummerIntensive.Core.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimbirsoftSummerIntensive.Infrastructure.DB.Interfaces
{
    public interface IResourseRepository: IRepository<Resource>
    {
        public Task<Resource> GetFreshResourse();
    }
}
