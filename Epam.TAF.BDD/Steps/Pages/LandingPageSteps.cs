using Epam.TAF.Core.Browser;
using Epam.TAF.Core.Utils;
using Epam.TAF.Web.PageObgects.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Epam.TAF.BDD.Steps.Pages
{
    [Binding]
    public class LandingPageSteps
    {
        private MainPage LandingPage => new();

        [Given(@"I navigate to landing page of EPAM site")]
        public void GivenINavigateToLandingPageOfEPAMSite()
        {
            BrowserFactory.Browser.GoToUrl(LandingPage.Url);
            Waiters.WaitForPageLoad();
        }

        [StepDefinition(@"I navigate to Join our team via Careers link on Header")]
        public void GivenINavigateToJoinOurTeamViaCareersLinkOnHeader()
        {
            LandingPage.HeaderBlock.OpenJoinOurTeamPageViaCareersHeaderLink();
        }

        [StepDefinition(@"I navigate to other pages using page (.*)")]
        public void GivenINavigateToOtherPagesUsingPageHttpsWww_Epam_ComAbout(string pageUrl)
        {
            BrowserFactory.Browser.GoToUrl(pageUrl);
        }

        [Then(@"I check that landing page is opened")]
        public void ThenICheckThatLandingPageIsOpened()
        {
            var actualOpenedPageUrl = BrowserFactory.Browser.GetUrl();
            var expectedPageUrl = LandingPage.Url;

            Assert.That(actualOpenedPageUrl, Is.EqualTo(expectedPageUrl), "The landing page isn't opened when click on Epam Logo.");
        }

    }
}
