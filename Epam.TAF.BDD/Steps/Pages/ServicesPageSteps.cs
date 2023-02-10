using Epam.TAF.Web.PageObgects.Pages;
using TechTalk.SpecFlow;

namespace Epam.TAF.BDD.Steps.Pages
{
    public class ServicesPageSteps
    {
        private ServicesPage ServicesPage = new();

        [Then(@"I check that 'Services' page is opened")]
        public void ThenICheckThatServicesPageIsOpened()
        {
            ServicesPage.ServisesPageBreadcrumbsIsDisplayed();
        }

    }
}
