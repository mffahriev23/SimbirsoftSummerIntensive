using SimbirsoftSummerIntensive.CLI.AppExceptions;
using SimbirsoftSummerIntensive.CLI.ConsoleReadData;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimbirsoftSummerIntensive.CLI.MenuCLI
{
    public class MenuDowloadFile : IMenu
    {
        private string _inputedData;
        private ICheckRightInputData _checkService;

        public MenuDowloadFile(ICheckRightInputData checkService)
            => _checkService = checkService;

        public void Show()
        {
            Console.Write("Введите url: ");
            _inputedData = Console.ReadLine();
        }

        public T GetEnteredData<T>()
        {
            if (CheckRightInputedData(_checkService))
                return (T)Convert.ChangeType(_inputedData, typeof(T));
            else
                throw new InputUrlException($"неправильно введён url {_inputedData}");
        }

        public bool CheckRightInputedData(ICheckRightInputData service)
            => service.CheckRightInputData(_inputedData);
    }
}
