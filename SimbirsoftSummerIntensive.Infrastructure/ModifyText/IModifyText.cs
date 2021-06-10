using System;
using System.Collections.Generic;
using System.Text;

namespace SimbirsoftSummerIntensive.Infrastructure.ModifyText
{
    public interface IModifyText
    {
        public void GetModifiedText(ref string text);
    }
}
