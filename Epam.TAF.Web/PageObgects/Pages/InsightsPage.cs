using Epam.TAF.Core.BasePage;
using Epam.TAF.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TAF.Web.PageObgects.Pages
{
    public class InsightsPage : BasePage
    {
        private const string _insightsPageBreadCrumbsXPath = "//*[@href = '/insights' and @class='breadcrumbs__link']";

        public override string Url => PageUrls.InsightsPageUrl;

        public override Title Title => new Title(By.XPath(_insightsPageBreadCrumbsXPath)); // use XPath for breadCrumbs beacause Title is missing for Insights Page

        public BreadCrumbs InsightsPageBreadCrumbs => new BreadCrumbs(By.XPath(_insightsPageBreadCrumbsXPath));

        public bool InsightsPageBreadCrumbsIsDisplayed()
        {
            return InsightsPageBreadCrumbs.IsDisplayed();
        }
    }
}
