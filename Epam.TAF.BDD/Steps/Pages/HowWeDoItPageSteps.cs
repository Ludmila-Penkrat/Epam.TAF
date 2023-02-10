using Epam.TAF.Web.PageObgects.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Epam.TAF.BDD.Steps.Pages
{
    [Binding]
    public class HowWeDoItPageSteps
    {
        private HowWeDoItPage HowWeDoItPage => new();

        [Then(@"I check that 'How We Do It' page is opened")]
        public void ThenICheckThatPageIsOpened()
        {
            var howWeDoItPageIsOpened = HowWeDoItPage.HowWeDoItPageBreadCrumsIsDisplayed();
            Assert.That(howWeDoItPageIsOpened, Is.True, "How We Do It page isn't opened");
        }
    }
}
