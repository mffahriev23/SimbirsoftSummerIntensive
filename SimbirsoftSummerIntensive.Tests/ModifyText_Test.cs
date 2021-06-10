using SimbirsoftSummerIntensive.Infrastructure.ModifyText;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SimbirsoftSummerIntensive.Tests
{
    public class ModifyText_Test
    {
        [Theory]
        [InlineData("<div class=\"someclass\">Текст1<br/><div>Текст2.Текст3[Текст4]</div></div>")]
        public void ClearningHtml_Tags(string text)
        {        
            IModifyText act = new GetClearedTags();
            string text_without_tags = act.GetModifiedText(text);

            Assert.True(text_without_tags == "Текст1Текст2.Текст3[Текст4]");
        }

        [Theory]
        [InlineData("ТеКсT")]
        public void GetUpperWords(string text)
        {

            IModifyText act = new GetUpperWords();
            string upperText = act.GetModifiedText(text);

            Assert.True(upperText == "ТЕКСT");
        }
    }
}
