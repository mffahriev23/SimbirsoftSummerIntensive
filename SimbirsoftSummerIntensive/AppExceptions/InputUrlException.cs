using System;
using System.Collections.Generic;
using System.Text;

namespace SimbirsoftSummerIntensive.CLI.AppExceptions
{
    public class InputUrlException : Exception
    {
        public InputUrlException(string message) 
            : base($"Введённые данные имеют неверный формат:{message}.") 
        { }
    }
}
