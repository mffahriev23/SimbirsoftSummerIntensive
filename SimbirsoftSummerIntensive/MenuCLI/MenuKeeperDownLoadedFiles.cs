﻿using SimbirsoftSummerIntensive.Infrastructure.AppExceptions;
using SimbirsoftSummerIntensive.Infrastructure.ConsoleReadData;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimbirsoftSummerIntensive.CLI.MenuCLI
{
    public class MenuKeeperDownLoadedFiles : IMenu
    {
        private string _inputedData;
        private CheckRightInputData _checkService;

        public MenuKeeperDownLoadedFiles(CheckRightInputData checkService)
            => _checkService = checkService;

        public void Show()
        {
            Console.Write("Введите путь к папке с html документами: ");
            _inputedData = Console.ReadLine();
        }

        public T GetEnteredData<T>()
        {
            if (CheckRightInputedData(_checkService))
                return (T)Convert.ChangeType(_inputedData, typeof(T));
            else
                throw new InputUrlException($"неправильно введён путь к папке {_inputedData}");
        }

        public bool CheckRightInputedData(CheckRightInputData service)
            => service.CheckRight(_inputedData);
    }
}

