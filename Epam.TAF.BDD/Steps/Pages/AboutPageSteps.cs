using Epam.TAF.Web.PageObgects.Pages;
using TechTalk.SpecFlow;
using NUnit.Framework;


namespace Epam.TAF.BDD.Steps.Pages
{
    [Binding]
    public class AboutPageSteps
    {
        private AboutPage AboutPage => new();

        [Then(@"I check that 'About' page is opened")]
        public void ThenICheckThatPageIsOpened()
        {
            var aboutPageIsOpened = AboutPage.AboutPageBreadCrumsIsDisplayed();
            Assert.That(aboutPageIsOpened, Is.True, "About page isn't opened");
        }
    }
}
