using Epam.TAF.Core.BasePage;
using Epam.TAF.Core.Browser;
using Epam.TAF.Core.Elements;
using Epam.TAF.Core.Helpers;
using OpenQA.Selenium;

namespace Epam.TAF.Web.PageObgects.Pages
{
    public class SearchResultsPage : BasePage
    {
        private const string _searchPageBreadCrumbsXPath = "//*[@href='/search' and @class='breadcrumbs__link']";
        private const string _searchResultTitleXPath = "//*[contains(@class, 'search-results__counter')]";
        private const string _searchResultLinksXPath = "//*[contains(@class, 'search-results__title-link')]";

        public override string Url
        {
            get
            {
                return string.Concat(TestSettings.ApplicationUrl, "search?q={0}");
            } 
        }

        public bool IsPageOpened(string inputWord)
        {
            return BrowserFactory.Browser.GetUrl().Equals(string.Format(Url, inputWord.Replace(' ', '+')));
        }
 
        public override Title Title => new Title(By.TagName("h1"));

        public ElementsList<Link> SearcheResultLinks => new ElementsList<Link>(By.XPath(_searchResultLinksXPath));

        public BreadCrumbs SearchPageBreadCrumbs => new BreadCrumbs(By.XPath(_searchPageBreadCrumbsXPath));

        public Title SearchResultTitleForArticles => new Title(By.XPath(_searchResultTitleXPath));

        public bool SearchPageBreadcrumbsIsDisplayed()
        {
            return SearchPageBreadCrumbs.IsDisplayed();
        }

        public Link GetSearchResultLinkByName(string linkName)
        {
            var searchResultLink = SearcheResultLinks.GetElements().Where(x => x.GetText().ToLower().Equals(linkName.ToLower())).FirstOrDefault();
            if (searchResultLink != null)
            {
                return searchResultLink;
            }
            else
            {
                throw new NoSuchElementException($"Search result link {linkName} isn't found");
            }
        }
    }
}
