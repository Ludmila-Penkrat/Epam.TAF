using Epam.TAF.Core.Helpers;
using Epam.TAF.Core.Utils;
using Epam.TAF.TestData.Models;
using Epam.TAF.Utilities.Parser;
using Epam.TAF.Web.PageObgects.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TAF.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class HeaderLinkPagesTest :BaseTest
    {
        private MainPage _mainPage => new MainPage();
        private HeaderLinkPages _headerLinkPages => new HeaderLinkPages();

        [Test]
        [TestCaseSource(nameof(GetHeaderLinks))]
        public void HeaderLinkAreWorkingTest(HeaderLinkModel linkName)
        {
            Waiters.WaitForCondition(() => _mainPage.AcceptAllCookiesButton.IsDisplayed());
            _mainPage.AcceptAllCookiesButton.Click();
            _mainPage.AcceptAllCookies();
            _mainPage.HeaderBlock.GetHeaderNavigationLinkByName(linkName.HeaderLink).Click();

            Waiters.WaitForCondition(() => _headerLinkPages.Title.IsDisplayed());

            Assert.IsTrue(_headerLinkPages.IsPageOpenedByTitle(), $"Page by link with {linkName} isn't opened.");
        }

        private static List<HeaderLinkModel> GetHeaderLinks()
        {
            return JsonParser.DeserializeJsonToObjects<HeaderLinkModel>(File.ReadAllText($"{TestSettings.DataDir}\\HeaderLinks.json")).ToList();
        }
    }
}
