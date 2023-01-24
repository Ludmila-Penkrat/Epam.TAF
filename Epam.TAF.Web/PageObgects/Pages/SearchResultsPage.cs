using Epam.TAF.Core.BasePage;
using Epam.TAF.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TAF.Web.PageObgects.Pages
{
    public class SearchResultsPage : BasePage
    {
        private const string _searchPageBreadCrumbsXPath = "//*[@href='/search' and @class='breadcrumbs__link']";
        private const string _searchResultTitleXPath = "//*[contains(@class, 'search-results__counter')]";
        private const string _searchResultLinksXPath = "//*[contains(@class, 'search-results__title-link')]";

        //Это переопределение свойства не реализовано до конца, потому как у меня есть вопросы
        public override string Url
        {
            get
            {
                string urlSearchPage = "https://www.epam.com/search?q=";
                return String.Join(urlSearchPage, "inputWords".Replace(' ', '+'));
            }
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
            return SearcheResultLinks.GetElements().Where(x => x.GetText().ToLower().Equals(linkName.ToLower())).FirstOrDefault();
        }
    }
}
