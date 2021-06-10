using SimbirsoftSummerIntensive.Infrastructure.AppExceptions;
using SimbirsoftSummerIntensive.Infrastructure.ConsoleReadData;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimbirsoftSummerIntensive.CLI.MenuCLI
{
    class MenuLogFolderPath: IMenu
    {
        private string _inputedData;
        private CheckRightInputData _checkService;

        public MenuLogFolderPath(CheckRightInputData checkService)
            => _checkService = checkService;

        public void Show()
        {
            Console.Write("Введите путь к папке логов: ");
            _inputedData = Console.ReadLine();
        }

        public T GetEnteredData<T>()
        {
            if (CheckRightInputedData(_checkService))
                return (T)Convert.ChangeType(_inputedData, typeof(T));
            else
                throw new InputUrlException($"неправильно введён путь к папке логов {_inputedData}");
        }

        public bool CheckRightInputedData(CheckRightInputData service)
            => service.CheckRight(_inputedData);
    }
}
