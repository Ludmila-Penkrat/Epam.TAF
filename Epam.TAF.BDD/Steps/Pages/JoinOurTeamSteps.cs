using Epam.TAF.Core.Utils;
using Epam.TAF.Web.PageObgects.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.BindingSkeletons;

namespace Epam.TAF.BDD.Steps.Pages
{
    [Binding]
    public class JoinOurTeamSteps
    {
        private JoinOurTeamPage JoinOurTeamPage = new();

        [When(@"I insert (.*) in Keyword field on Join our Team Page")]
        public void WhenIInsertDevelopInKeywordFieldOnJoinOurTeamPage(string keyWord)
        {
            JoinOurTeamPage.ClickOnKeywordField();
            JoinOurTeamPage.InsertSearchWordInKeywordField(keyWord);
        }

        [StepDefinition(@"I click Find button on Join our Team Page")]
        public void WhenIClickFindButtonOnJoinOurTeamPage()
        {
            JoinOurTeamPage.ClickFindButtonOnJoinOurTeamPage();
        }

        [Then(@"I check that search result related to (.*)")]
        public void ThenICheckThatSearchResultRelatedToKeyword(string keyWord)
        {
            var articleSearchResult = JoinOurTeamPage.IsResultHasSearchWord(keyWord);
            Assert.That(articleSearchResult, Is.True, $"Search results don't contain input keyword {keyWord}.");
        }

        [When(@"I open Location drop down on Join our Team Page")]
        public void WhenIOpenLocationDropDownOnJoinOurTeamPage()
        {
            JoinOurTeamPage.OpenLocationDropDownOnJoinOurTeamPage();
        }

        [StepDefinition(@"I select (.*)  and (.*) in Location dropdown on Join our Team Page")]
        public void WhenISelectArgentinaAndAllCitiesInArgentinaInLocationDropdownOnJoinOurTeamPage(string country, string city)
        {
            JoinOurTeamPage.SelectCountryLocationByName(country, city);
        }

        [Then(@"I verify that search result related to country (.*) or city (.*)")]
        public void ThenIVerifyThatSearchResultRelatedToCountryArgentinaOrCityAllCitiesInArgentina(string country, string city)
        {
            var expectedResult = JoinOurTeamPage.IsResultHasSearchWord(country) || JoinOurTeamPage.IsResultHasSearchWord(city);

            Assert.That(expectedResult, Is.True, $"Search results don't contain selected location {country} or {city}.");
        }

        [When(@"I open Skills drop down on Join our Team Page")]
        public void WhenIOpenSkillsDropDownOnJoinOurTeamPage()
        {
            JoinOurTeamPage.OpenSkillsDropDownOnJoinOurTeamPage();
        }

        [StepDefinition(@"I select checbox (.*) in skill panel on Join our Team Page")]
        public void WhenISetChecboxProductManagementInSkillPanelOnJoinOurTeamPage(string checkboxSkill)
        {
            JoinOurTeamPage.SelectCheckBoxByName(checkboxSkill);
        }

        [Then(@"I check that search result contains selected skill (.*)")]
        public void ThenICheckThatSearchResultContainSelectedSkillProductManagement(string checkboxSkill)
        {
            var expectedResult = JoinOurTeamPage.IsResultHasSearchWord(checkboxSkill);

            Assert.That(expectedResult, Is.True, $"Search results don't contain selected skill {checkboxSkill}.");
        }

        [Then(@"I check that message is present that result not found")]
        public void ThenICheckThatMessageIsPresentThatResultNotFound()
        {
            Waiters.WaitForCondition(() => JoinOurTeamPage.EmptyResultTitleDisplayed());
            Assert.That(JoinOurTeamPage.IsMessageForNotFoundResult(), Is.True, "The result is present and message doesn't display.");
        }

    }
}
