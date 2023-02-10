
using Epam.TAF.Web.PageObgects.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Epam.TAF.BDD.Steps.Pages
{
    [Binding]
    public class OurWorkPageSteps
    {
        private OurWorkPage OurWorkPage = new();

        [Then(@"I check that 'Our Work' page is opened")]
        public void ThenICheckThatPageIsOpened()
        {
            var ourWorkPageIsOpened = OurWorkPage.OurWorkPageBreadcrumbsIsDisplayed();
            Assert.That(ourWorkPageIsOpened, Is.True, "The Our Work page isn't opened.");
        }

    }
}
