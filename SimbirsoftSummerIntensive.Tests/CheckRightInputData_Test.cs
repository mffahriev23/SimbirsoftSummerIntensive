using SimbirsoftSummerIntensive.Infrastructure.ConsoleReadData;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SimbirsoftSummerIntensive.Tests
{
    public class CheckRightInputData_Test
    {
        [Theory]
        [InlineData("https://ru.wikipedia.org/wiki/%D0%97%D0%B0%D0%B3%D0%BB%D0%B0%D0%B2%D0%BD%D0%B0%D1%8F_%D1%81%D1%82%D1%80%D0%B0%D0%BD%D0%B8%D1%86%D0%B0")]
        public void CheckRight_Url(string inputData)
        {
            CheckRightInputData act = new CheckRightUrl();
            bool result = act.CheckRight(inputData);

            Assert.True(result);
        }

        [Theory]
        [InlineData(@"C:\a\b\c\")]
        public void CheckRight_FolderPath(string inputData)
        {
            CheckRightInputData act = new CheckRightFolderPath();
            bool result = act.CheckRight(inputData);

            Assert.True(result);
        }

        [Theory]
        [InlineData(@"Server=DESKTOP-73G6TMG\\SQLEXPRESS;Database=Simbirsoft;Trusted_Connection=True;MultipleActiveResultSets=true")]
        public void CheckRight_ConnectionString(string inputData)
        {
            CheckRightInputData act = new CheckRightConnectionString();
            bool result = act.CheckRight(inputData);

            Assert.True(result);
        }
    }
}
