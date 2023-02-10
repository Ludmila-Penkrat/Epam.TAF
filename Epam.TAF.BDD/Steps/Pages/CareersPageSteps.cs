using Epam.TAF.Web.PageObgects.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Epam.TAF.BDD.Steps.Pages
{
    [Binding]
    public class CareersPageSteps
    {
        public CareersPage CareersPage => new();

        [Then(@"I check that 'Careers' page is opened")]
        public void ThenICheckThatPageIsOpened()
        {
            var careersPageIsOpened = CareersPage.CareersPageBreadcrumbsIsDisplayed();
            Assert.That(careersPageIsOpened, Is.True, "Careers page isn't opened");
        }
    }
}
