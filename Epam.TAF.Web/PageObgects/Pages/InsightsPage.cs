using Epam.TAF.Core.BasePage;
using Epam.TAF.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TAF.Web.PageObgects.Pages
{
    public class InsightsPage : BasePage
    {
        private const string _insightsPageBreadCrumbsXPath = "//*[@href = '/insights' and @class='breadcrumbs__link']";

        public override string Url => "https://www.epam.com/insights";

        public override Title Title => new Title(By.TagName("h1"));

        public BreadCrumbs InsightsPageBreadCrumbs => new BreadCrumbs(By.XPath(_insightsPageBreadCrumbsXPath));

        public bool InsightsPageBreadCrumsIsDisplayed()
        {
            return InsightsPageBreadCrumbs.IsDisplayed();
        }
    }
}
