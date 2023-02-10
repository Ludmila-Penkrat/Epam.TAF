using Epam.TAF.Core.Browser;
using Epam.TAF.Core.Utils;
using Epam.TAF.Web.PageObgects.Pages;
using NUnit.Framework;

namespace Epam.TAF.Tests
{
    [TestFixture]
    public class EpemContinuumPageTests : BaseTest
    {
        private MainPage _mainPage => new MainPage();
        private EpamContinuumPage _continuumPage => new EpamContinuumPage();

        [Test]
        public void EpamContinuumPageIsOpened()
        {
            Waiters.WaitForCondition(() => _mainPage.BannerPanel.IsDisplayed());
            _mainPage.AcceptAllCookies();

            BrowserFactory.Browser.ScrollToElement(_mainPage.FooterBlock.OriginalElement);
            _mainPage.FooterBlock.EpamContinuumLink.Click();

            Assert.That(_continuumPage.BreadCrumsIsDisplayed(), "Epam Continuum page isn't opened.");
        }
    }
}