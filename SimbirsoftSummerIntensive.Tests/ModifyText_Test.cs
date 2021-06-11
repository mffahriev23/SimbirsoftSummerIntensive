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
            act.GetModifiedText(ref text);

            Assert.True(text == "Текст1Текст2.Текст3[Текст4]");
        }

        [Theory]
        [InlineData("<div>Текст1Текст2.Текст3[Текст4]</div><script src=\"text\\javascript\">console.log('log')</script>")]
        public void ClearningJs(string text)
        {
            IModifyText act = new GetClearedJS();
            act.GetModifiedText(ref text);

            Assert.True(text == "<div>Текст1Текст2.Текст3[Текст4]</div>");
        }

        [Theory]
        [InlineData("<div>Текст1Текст2.Текст3[Текст4]</div><style>.a{backgraoudcolog:red;}</style>")]
        public void ClearningCSS(string text)
        {
            IModifyText act = new GetClearedCss();
            act.GetModifiedText(ref text);

            Assert.True(text == "<div>Текст1Текст2.Текст3[Текст4]</div>");
        }

        [Theory]
        [InlineData("ТеКсT")]
        public void GetUpperWords(string text)
        {

            IModifyText act = new GetUpperWords();
            act.GetModifiedText(ref text);

            Assert.True(text == "ТЕКСT");
        }
    }
}
