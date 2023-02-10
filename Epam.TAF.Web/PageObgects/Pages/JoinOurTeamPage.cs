using Epam.TAF.Core.BasePage;
using Epam.TAF.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TAF.Web.PageObgects.Pages
{
    public class JoinOurTeamPage : BasePage
    {
        private const string _keywordInputFieldXPath = "//input[starts-with(@id, 'new_form_job')]";

        private const string _locationFieldJoinOurTeamXPath = "//*[@class ='select2-selection__rendered']";
        private const string _countriesLinkInDropDownJoinOurTeamXPath = "//*[contains(@class, 'select2-results__group')]";
        private const string _citiesNestedLinkInDropDownJoinOurTeamXPath = "//*[contains(@class, 'select2-results__group')]/following-sibling::ul/li";

        private const string _skillsFieldXPath = "//*[contains(@class, 'selected-params')]";
        private const string _skillsDropDownXPath = "//*[@class= 'multi-select-dropdown']";
        private const string _checkBoxesSkillsInDropDownXPath = "//*[@class= 'checkbox-custom-label']";

        private const string _findButtonJoinOurTeamPageXPath = "//*[contains(@class, 'recruiting-search__submit')]";

        private const string _titleWithkeywordResultsXPath = "//*[contains(@class, 'search-result__heading')]";
        private const string _resultsOnJoinOurTeamPageXPath = "//*[@class='search-result__item']";
        private const string _searchResultListOnJoinOurTeamPageXPath = "//*[contains(@class, 'search-result__list')]";

        private const string _titleForEmptySearchResult = "//div[contains(@class, 'search-result__error-message')]";

        private const string _spinnerXPath = "//*[contains(@class, 'preloader')]";

        private const string _messageForEmptyResult = "Sorry, your search returned no results. Please try another combination.";

        public override string Url => PageUrls.JoinOurTeamPageUrl;

        public override Title Title => new Title(By.TagName("h1"));

        public Title EmptyResultTitle => new Title(By.XPath(_titleForEmptySearchResult));

        public TextInput KeyWordTextInput => new TextInput(By.XPath(_keywordInputFieldXPath));

        public Button FindButtonJoinOurTeamPage => new Button(By.XPath(_findButtonJoinOurTeamPageXPath));

        public Title TitleWithKeywordResults => new Title(By.XPath(_titleWithkeywordResultsXPath));

        public DropDown SkillsDropDownJoinOurTeam => new DropDown(By.XPath(_skillsFieldXPath));

        public DropDown LocationDropDownJoinOurTeam => new DropDown(By.XPath(_locationFieldJoinOurTeamXPath));

        public Panel CheckBoxesSkillsPanel => new Panel(By.XPath(_skillsDropDownXPath));

        public Panel SearchResultLinksPanel => new Panel(By.XPath(_searchResultListOnJoinOurTeamPageXPath));

        public SpinnerElement SpinnerElement => new SpinnerElement(By.XPath(_spinnerXPath));

        public ElementsList<CheckBox> CheckBoxSkills => new ElementsList<CheckBox>(By.XPath(_checkBoxesSkillsInDropDownXPath));

        public ElementsList<Link> ResultsSkillsOnJoinOurTeam => new ElementsList<Link>(By.XPath(_resultsOnJoinOurTeamPageXPath));

        public ElementsList<Link> CountriesLocationInDropDownOnJoinOurTeam => new ElementsList<Link>(By.XPath(_countriesLinkInDropDownJoinOurTeamXPath));

        public bool EmptyResultTitleDisplayed()
        {
            return EmptyResultTitle.IsDisplayed();
        }

        public bool IsMessageForNotFoundResult()
        {
            var displayedMessage = EmptyResultTitle.GetText();
            return displayedMessage.Equals(_messageForEmptyResult);
        }

        public bool IsTitleDisplayed()
        {
            return Title.IsDisplayed();
        }

        public bool IsTitleForPageWithResults()
        {
            var titleLine = GetTitleWithResult();

            return titleLine.Contains("job openings related to", StringComparison.OrdinalIgnoreCase);
        }
        public string GetTitleWithResult()
        {
            return Title.GetText().ToUpper();
        }

        public bool IsSpinnerIsDisplayed()
        {
            return SpinnerElement.IsDisplayed();
        }

        public void FillInSearchFileds(string? inputWord = null, string? selectedCheckboxName = null, string? country = null, string? city = null)
        {
            if(inputWord != null)
            {
                KeyWordTextInput.Click();
                KeyWordTextInput.SendKeys(inputWord);
            }
  
            if(selectedCheckboxName != null)
            {
                SkillsDropDownJoinOurTeam.Click();
                
                var listCheckbox = CheckBoxSkills.GetElements().ToList();
                var countCheckBoxes = listCheckbox.Count();

                for (int i = 0; i < countCheckBoxes; i++)
                {
                    string checkBoxName = listCheckbox.ElementAt(i).GetAttribut("innerText");

                    if (checkBoxName.Equals(selectedCheckboxName))
                    {
                        listCheckbox.ElementAt(i).Click();
                        break;
                    }
                }
            }

            if (country != null || city != null)
            {
                LocationDropDownJoinOurTeam.Click();

                var listLocationLinks = CountriesLocationInDropDownOnJoinOurTeam.GetElements().ToList();
                var countLocationLinks = listLocationLinks.Count();

                for (int i = 0; i < countLocationLinks; i++)
                {
                    string countryLocationName = listLocationLinks.ElementAt(i).GetAttribut("innerText");

                    if (countryLocationName.Contains(country))
                    {
                        listLocationLinks.ElementAt(i).Click();

                        var nestedCityLink = new ElementsList<Link>(By.XPath(_citiesNestedLinkInDropDownJoinOurTeamXPath));
                        nestedCityLink.GetElements().Where(x => x.GetAttribut("innerText").Contains(city)).FirstOrDefault().Click();
                        break;
                    }
                }
            }
            
        }

        public void ClickOnKeywordField()
        {
            KeyWordTextInput.Click();
        }

        public void InsertSearchWordInKeywordField(string input)
        {
            KeyWordTextInput.SendKeys(input);
        }

        public void OpenSkillsDropDownOnJoinOurTeamPage()
        {
            SkillsDropDownJoinOurTeam.Click();
        }

        public void OpenLocationDropDownOnJoinOurTeamPage()
        {
            LocationDropDownJoinOurTeam.Click();
        }

        public List<CheckBox> GetSkillsCheckBoxes()
        {
            var listCheckbox = CheckBoxSkills.GetElements().ToList();
            return listCheckbox;
        }

        public int GetCheckBoxesCount()
        {
            var count = GetSkillsCheckBoxes().Count();
            return count;
        }

        public void SelectCheckBoxByName(string selectedCheckboxName)
        {
            for (int i = 0; i < GetCheckBoxesCount(); i++)
            {
                string checkBoxName = GetSkillsCheckBoxes().ElementAt(i).GetAttribut("innerText");

                if (checkBoxName.Equals(selectedCheckboxName))
                {
                    GetSkillsCheckBoxes().ElementAt(i).Click();
                    break;
                }
            }
        }

        public List<Link> GetLocationLinks()
        {
            var listLocationLinks = CountriesLocationInDropDownOnJoinOurTeam.GetElements().ToList();
            return listLocationLinks;
        }

        public int GetLocationLinksCount()
        {
            var count = GetLocationLinks().Count();
            return count;
        }

        public void SelectCountryLocationByName(string country, string city)
        {
            for (int i = 0; i < GetLocationLinksCount(); i++)
            {
                string countryLocationName = GetLocationLinks().ElementAt(i).GetAttribut("innerText");

                if (countryLocationName.Contains(country))
                {
                    GetLocationLinks().ElementAt(i).Click();

                    var nestedCityLink = new ElementsList<Link>(By.XPath(_citiesNestedLinkInDropDownJoinOurTeamXPath));
                    nestedCityLink.GetElements().Where(x => x.GetAttribut("innerText").Contains(city)).FirstOrDefault().Click();
                    break;
                }
            }
        }

        public void FillInSearchFileds(string? inputWord = null, string? selectedCheckboxName = null, string? country = null, string? city = null)
        {
            KeyWordTextInput.Click();
            KeyWordTextInput.SendKeys(inputWord);

            SkillsDropDownJoinOurTeam.Click();
            LocationDropDownJoinOurTeam.Click();

            var listCheckbox = CheckBoxSkills.GetElements().ToList();
            var countCheckBoxes = listCheckbox.Count();

            for (int i = 0; i < countCheckBoxes; i++)
            {
                string checkBoxName = listCheckbox.ElementAt(i).GetAttribut("innerText");

                if (checkBoxName.Equals(selectedCheckboxName))
                {
                    listCheckbox.ElementAt(i).Click();
                    break;
                }
            }

            var listLocationLinks = CountriesLocationInDropDownOnJoinOurTeam.GetElements().ToList();
            var countLocationLinks = listLocationLinks.Count();

            for (int i = 0; i < countLocationLinks; i++)
            {
                string countryLocationName = listLocationLinks.ElementAt(i).GetAttribut("innerText");

                if (countryLocationName.Contains(country))
                {
                    listLocationLinks.ElementAt(i).Click();

                    var nestedCityLink = new ElementsList<Link>(By.XPath(_citiesNestedLinkInDropDownJoinOurTeamXPath));
                    nestedCityLink.GetElements().Where(x => x.GetAttribut("innerText").Contains(city)).FirstOrDefault().Click();
                    break;
                }
            }
        }

        public void ClickFindButtonOnJoinOurTeamPage()
        {
            FindButtonJoinOurTeamPage.Click();
        }

        public bool IsResultHasSearchWord(string searchWord)
        {
            var resultLinks = ResultsSkillsOnJoinOurTeam.GetElements().ToList().Select(x => x.GetAttribut("innerText").Contains(searchWord));
                       
            return resultLinks.Any();
        }
    }
}
