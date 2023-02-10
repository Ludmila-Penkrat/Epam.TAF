
using Epam.TAF.Web.PageObgects.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Epam.TAF.BDD.Steps.Pages
{
    [Binding]
    public class InsightsPageSteps
    {
        private InsightsPage InsightsPage => new();

        [Then(@"I check that 'Insights' page is opened")]
        public void ThenICheckThatPageIsOpened()
        {
            var insightsPageIsOpened = InsightsPage.InsightsPageBreadCrumbsIsDisplayed();
            Assert.That(insightsPageIsOpened, Is.True, "Insights page isn't opened");
        }
    }
}
