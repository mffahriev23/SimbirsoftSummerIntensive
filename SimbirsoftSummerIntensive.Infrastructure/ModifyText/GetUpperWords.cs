using System;
using System.Collections.Generic;
using System.Text;

namespace SimbirsoftSummerIntensive.Infrastructure.ModifyText
{
    public class GetUpperWords : IModifyText
    {
        public string GetModifiedText(string text)
            => text.ToUpper();
    }
}
