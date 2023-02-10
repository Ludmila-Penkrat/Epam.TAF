using Epam.TAF.Core.Utils;
using Epam.TAF.Web.PageObgects.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Epam.TAF.BDD.Steps.Pages
{
    [Binding]
    public class InvestorsPageSteps
    {
        private InvestorsPage Investors => new();

        [Then(@"I check that Investors page is opened")]
        public void ThenICheckThatInvestorsPageIsOpened()
        {
            Waiters.WaitForPageLoad();
            Assert.That(Investors.IsPageOpenedByUrl(), Is.True, "Investors page should be opened.");
        }

    }
}
