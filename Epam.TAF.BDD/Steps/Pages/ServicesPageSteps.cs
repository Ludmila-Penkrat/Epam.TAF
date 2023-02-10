using Epam.TAF.Web.PageObgects.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Epam.TAF.BDD.Steps.Pages
{
    [Binding]
    public class ServicesPageSteps
    {
        private ServicesPage ServicesPage = new();

        [Then(@"I check that 'Services' page is opened")]
        public void ThenICheckThatServicesPageIsOpened()
        {
            var servisesPageIsOpened = ServicesPage.ServisesPageBreadcrumbsIsDisplayed();
            Assert.That(servisesPageIsOpened, Is.True, "Servises page isn't opened");
        }
    }
}
