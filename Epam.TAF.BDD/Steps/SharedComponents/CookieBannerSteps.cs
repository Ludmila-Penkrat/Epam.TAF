using Epam.TAF.Web.PageObgects.Pages;
using TechTalk.SpecFlow;

namespace Epam.TAF.BDD.Steps.SharedComponents
{
    [Binding]
    public class CookieBannerSteps
    {
        private MainPage LandingPage => new();

        [Given(@"A accept all cookies on EPAM site")]
        public void GivenAAcceptAllCookiesOnEPAMSite()
        {
            LandingPage.AcceptAllCookies();
        }

    }
}
