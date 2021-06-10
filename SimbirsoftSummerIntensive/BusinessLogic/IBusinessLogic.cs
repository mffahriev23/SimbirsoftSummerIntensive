using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimbirsoftSummerIntensive.CLI.BusinessLogic
{
    public interface IBusinessLogic<T>
    {
        public Task<T> GetFinalData();
    }
}
