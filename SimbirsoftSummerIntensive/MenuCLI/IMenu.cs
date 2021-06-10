﻿using SimbirsoftSummerIntensive.CLI.ConsoleReadData;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimbirsoftSummerIntensive.CLI.MenuCLI
{
    public interface IMenu
    {
        public void Show();
        public T GetEnteredData<T>();
        public bool CheckRightInputedData(ICheckRightInputData service);
    }
}
