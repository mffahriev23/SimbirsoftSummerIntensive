using SimbirsoftSummerIntensive.Infrastructure.AppExceptions;
using SimbirsoftSummerIntensive.Infrastructure.ConsoleReadData;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimbirsoftSummerIntensive.CLI.MenuCLI
{
    class MenuConnectionString : IMenu
    {
        private string _inputedData;
        private CheckRightInputData _checkService;

        public MenuConnectionString(CheckRightInputData checkService)
            => _checkService = checkService;

        public void Show()
        {
            Console.Write("Введите строку подключения к базе (MSSQL): ");
            _inputedData = Console.ReadLine();
        }

        public T GetEnteredData<T>()
        {
            if (CheckRightInputedData(_checkService))
                return (T)Convert.ChangeType(_inputedData, typeof(T));
            else
                throw new InputUrlException($"неправильно введена строка подключения к базе {_inputedData}");
        }

        public bool CheckRightInputedData(CheckRightInputData service)
            => service.CheckRight(_inputedData);
    }
}
