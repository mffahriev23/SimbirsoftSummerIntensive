using System;
using System.Collections.Generic;
using System.Text;

namespace SimbirsoftSummerIntensive.Infrastructure.ModifyText
{
    public class GetUpperWords : IModifyText
    {
        public void GetModifiedText(ref string text)
            => text = text.ToUpper();
    }
}
