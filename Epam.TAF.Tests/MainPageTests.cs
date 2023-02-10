using Epam.TAF.Core.Browser;
using Epam.TAF.Core.Utils;
using Epam.TAF.Web.PageObgects.Pages;
using NUnit.Framework;

namespace Epam.TAF.Tests
{
    [TestFixture]
    public class MainPageTests : BaseTest
    {
        private MainPage _mainPage => new MainPage();
        private HowWeDoItPage _howWeDoItPage => new HowWeDoItPage();
        private OurWorkPage _ourWorkPage => new OurWorkPage();

        [Test]
        public void MainPageIsOpened()
        {
            Waiters.WaitForPageLoad();
            var actualResult = BrowserFactory.Browser.GetUrl();
            var expectedUrlForMainPage = _mainPage.GetPageUrl();

            Assert.That(actualResult, Is.EqualTo(expectedUrlForMainPage), "Main page isn't opened.");
        }

        [Test]
        public void CheckWeDoItPageIsOpenedAfterMoveAndReload()
        {
            Waiters.WaitForPageLoad();
            _howWeDoItPage.NavigateToPage();
            _ourWorkPage.NavigateToPage();
            BrowserFactory.Browser.Refresh();
            BrowserFactory.Browser.NavigateBack();

            Assert.That(BrowserFactory.Browser.GetUrl(), Is.EqualTo(_howWeDoItPage.GetPageUrl()), $"Expected result {_mainPage.GetPageUrl} is'n equal to actual result {BrowserFactory.Browser.GetUrl()}");
        }
    }
}
