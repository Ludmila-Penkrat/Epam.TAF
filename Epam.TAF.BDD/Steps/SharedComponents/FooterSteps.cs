using Epam.TAF.Web.PageObgects.Pages;
using Epam.TAF.Web.PageObgects.Panels;
using TechTalk.SpecFlow;

namespace Epam.TAF.BDD.Steps.SharedComponents
{
    [Binding]
    public class FooterSteps
    {
        private FooterBlock Footer => new MainPage().FooterBlock;

        [When(@"I click '([^']*)' link on Footer of EPAM site")]
        public void WhenIClickLinkOnFooterOfEPAMSite(string link)
        {
            Footer.ClickOnLink(link);
        }

    }
}
