using Epam.TAF.Core.BasePage;
using Epam.TAF.Core.Browser;
using Epam.TAF.Core.Elements;
using Epam.TAF.Core.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Epam.TAF.Web.PageObgects.Pages
{
    public class FooterLinkPages : BasePage
    {
        public override string Url
        {
            get
            {
                return string.Concat(TestSettings.ApplicationUrl, "{0}");
            }
        }

        public override Title Title => new Title(By.TagName("h1"));

        public bool IsPageOpened(string inputWord)
        {
            var link = BrowserFactory.Browser.GetUrl().Equals(string.Format(Url, inputWord.Replace(' ', '-').ToLower()));
            return link;
        }
    }
}
