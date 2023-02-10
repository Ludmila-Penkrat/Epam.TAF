﻿using Epam.TAF.Core.Browser;
using Epam.TAF.Core.Helpers;
using Epam.TAF.Core.Utils;
using Epam.TAF.TestData.Models;
using Epam.TAF.Utilities.Parser;
using Epam.TAF.Web.PageObgects.Pages;
using NUnit.Framework;

namespace Epam.TAF.Tests
{
    [TestFixture]
    public class JoinOurTeamPageTests : BaseTest
    {
        private MainPage _mainPage => new MainPage();
        private JoinOurTeamPage _joinOurTeamPage = new JoinOurTeamPage();

        [SetUp]
        public void OpenJoinOurTeamPage()
        {
            _mainPage.HeaderBlock.OpenJoinOurTeamPageViaCareersHeaderLink();
        }

        [Test]
        [TestCaseSource(nameof(GetKeyWord))]
        public void CheckKeywordIsPresentOnJoinOurTeamPageWithResult(KeyWordModel keyword)
        {
            _joinOurTeamPage.FillInSearchFileds(keyword.KeyWord);
            _joinOurTeamPage.ClickFindButtonOnJoinOurTeamPage();

            Waiters.WaitForPageLoad();
            Waiters.WaitForCondition(() => _joinOurTeamPage.IsTitleDisplayed());
            
            var titleForSearcheResult = _joinOurTeamPage.GetTitleWithResult();

            var articleSearchResult = _joinOurTeamPage.IsResultHasSearchWord(keyword.KeyWord);

            Assert.Multiple(() =>
            {
                Assert.That(titleForSearcheResult.Contains(keyword.KeyWord, StringComparison.OrdinalIgnoreCase), Is.True, $"Search result title doesn't contain selected word {keyword.KeyWord}.");
                Assert.That(articleSearchResult, Is.True, $"Search results don't contain input keyword {keyword.KeyWord}.");
            });
        }

        [Test]
        [TestCaseSource(nameof(GetSkill))]
        public void CheckSkillIsPresentOnJoinOurTeamPageWithResult(SkillsJoinOurTeamModel skill)
        {
            _joinOurTeamPage.FillInSearchFileds(skill.SkillJoinOurTeam);
            //_joinOurTeamPage.OpenSkillsDropDownOnJoinOurTeamPage();

            //_joinOurTeamPage.SelectCheckBoxByName(skill.SkillJoinOurTeam);

            _joinOurTeamPage.ClickFindButtonOnJoinOurTeamPage();

            Waiters.WaitForCondition(() => _joinOurTeamPage.Title.IsEnabled());
            Thread.Sleep(2000);

            var expectedResult = _joinOurTeamPage.IsResultHasSearchWord(skill.SkillJoinOurTeam);
            Assert.That(expectedResult, Is.True, "Search results don't contain selected skill.");
        }

        [Test]
        [TestCaseSource(nameof(GetLocation))]
        public void CheckLocationPresentOnJoinOurTeamPageWithResult(LocationJoinOurTeamModel location)
        {
            //_joinOurTeamPage.OpenLocationDropDownOnJoinOurTeamPage();

            //_joinOurTeamPage.SelectCountryLocationByName(location.CountryLocationJoinOurTeam, location.LocationJoinOurTeam);
            _joinOurTeamPage.FillInSearchFileds(location.CountryLocationJoinOurTeam, location.LocationJoinOurTeam);
            _joinOurTeamPage.ClickFindButtonOnJoinOurTeamPage();

            Waiters.WaitForCondition(() => _joinOurTeamPage.Title.IsEnabled());

            var expectedResult = _joinOurTeamPage.IsResultHasSearchWord(location.LocationJoinOurTeam) || _joinOurTeamPage.IsResultHasSearchWord(location.CountryLocationJoinOurTeam);

            Assert.That(expectedResult, Is.True, $"Search results don't contain selected location {location.LocationJoinOurTeam} or {location.CountryLocationJoinOurTeam}.");
        }

        [Test]
        [TestCaseSource(nameof(GetAllFields))]
        public void CheckResultPresentWhenAllFieldsFilled(AllFieldsFillJoinOurTeamModel allfields)
        {
            //_joinOurTeamPage.ClickOnKeywordField();
            //_joinOurTeamPage.InsertSearchWordInKeywordField(allfields.KeyWordJoinOurTeam);


            //_joinOurTeamPage.OpenLocationDropDownOnJoinOurTeamPage();
            //_joinOurTeamPage.SelectCountryLocationByName(allfields.CountryLocationJoinOurTeam, allfields.CityLocationJoinOurTeam);

            //_joinOurTeamPage.OpenSkillsDropDownOnJoinOurTeamPage();
            //_joinOurTeamPage.SelectCheckBoxByName(allfields.SkillJoinOurTeam);

            _joinOurTeamPage.FillInSearchFileds(allfields.KeyWordJoinOurTeam, allfields.CountryLocationJoinOurTeam, allfields.CityLocationJoinOurTeam, allfields.SkillJoinOurTeam);
            _joinOurTeamPage.ClickFindButtonOnJoinOurTeamPage();

            Waiters.WaitForCondition(() => _joinOurTeamPage.IsTitleDisplayed());
            var actualTitleForResult = _joinOurTeamPage.GetTitleWithResult();

            var articlesContainsSearchWord = _joinOurTeamPage.IsResultHasSearchWord(allfields.KeyWordJoinOurTeam);

            var articlesContainLocation = _joinOurTeamPage.IsResultHasSearchWord(allfields.CountryLocationJoinOurTeam) || _joinOurTeamPage.IsResultHasSearchWord(allfields.CountryLocationJoinOurTeam);

            var articalsContainSelectedSkill =_joinOurTeamPage.IsResultHasSearchWord(allfields.SkillJoinOurTeam);

            Waiters.WaitForCondition(() => _joinOurTeamPage.IsTitleDisplayed());
            var actualTitleWithMarkedWords = _joinOurTeamPage.IsTitleForPageWithResults();

            Assert.Multiple(() =>
            {
                Assert.That(actualTitleForResult.Contains(allfields.KeyWordJoinOurTeam, StringComparison.OrdinalIgnoreCase), Is.True, $"Search result title doesn't contain selected word {allfields.KeyWordJoinOurTeam}.");
                Assert.That(articlesContainsSearchWord, Is.True, $"Search results don't contain input keyword {allfields.KeyWordJoinOurTeam}.");
                Assert.That(articlesContainLocation, Is.True, $"Search results don't contain selected location {allfields.CountryLocationJoinOurTeam} or {allfields.CityLocationJoinOurTeam}.");
                Assert.That(articalsContainSelectedSkill, Is.True, $"Search results don't contain selected skill {allfields.SkillJoinOurTeam}.");
                Assert.IsTrue(actualTitleWithMarkedWords, "Articles by search properties were not found.");
            });
        }

        [Test]
        [TestCaseSource(nameof(GetMessageWithoutSearchResult))]
        public void CheckDisplayMessageIfResultNotFound(ValueForGetMessageModel messageEmptyResult)
        {
            //_joinOurTeamPage.ClickOnKeywordField();
            //_joinOurTeamPage.InsertSearchWordInKeywordField(messageEmptyResult.KeyWordJoinOurTeam);

            //_joinOurTeamPage.OpenLocationDropDownOnJoinOurTeamPage();
            //_joinOurTeamPage.SelectCountryLocationByName(messageEmptyResult.CountryLocationJoinOurTeam, messageEmptyResult.CityLocationJoinOurTeam);

            _joinOurTeamPage.FillInSearchFileds(messageEmptyResult.KeyWordJoinOurTeam, messageEmptyResult.CountryLocationJoinOurTeam, messageEmptyResult.CityLocationJoinOurTeam);
            _joinOurTeamPage.ClickFindButtonOnJoinOurTeamPage();

            Waiters.WaitForCondition(() => _joinOurTeamPage.EmptyResultTitleDisplayed());

            Assert.Multiple(() =>
            {
                Assert.That(_joinOurTeamPage.EmptyResultTitleDisplayed(), Is.True, "The result is present and message doesn't display");
                Assert.That(_joinOurTeamPage.IsMessageForNotFoundResult(), Is.True, "The result is present and message doesn't display");
            });
        }

        private static List<KeyWordModel> GetKeyWord()
        {
            return JsonParser.DeserializeJsonToObjects<KeyWordModel>(File.ReadAllText($"{TestSettings.DataDir}\\KeyWords.json")).ToList();
        }

        private static List<SkillsJoinOurTeamModel> GetSkill()
        {
            return JsonParser.DeserializeJsonToObjects<SkillsJoinOurTeamModel>(File.ReadAllText($"{TestSettings.DataDir}\\SkillsJoinOurTeam.json")).ToList();
        }

        private static List<LocationJoinOurTeamModel> GetLocation()
        {
            return JsonParser.DeserializeJsonToObjects<LocationJoinOurTeamModel>(File.ReadAllText($"{TestSettings.DataDir}\\LocationJoinOurTeam.json")).ToList();
        }

        private static List<AllFieldsFillJoinOurTeamModel> GetAllFields()
        {
            return JsonParser.DeserializeJsonToObjects<AllFieldsFillJoinOurTeamModel>(File.ReadAllText($"{TestSettings.DataDir}\\AllFieldsFillJoinOurTeam.json")).ToList();
        }

        private static List<ValueForGetMessageModel> GetMessageWithoutSearchResult()
        {
            return JsonParser.DeserializeJsonToObjects<ValueForGetMessageModel>(File.ReadAllText($"{TestSettings.DataDir}\\ValueForGetMessageWithoutResults.json")).ToList();
        }
    }
}
