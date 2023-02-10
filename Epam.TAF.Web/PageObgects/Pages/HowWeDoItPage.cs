using Epam.TAF.Core.BasePage;
using Epam.TAF.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TAF.Web.PageObgects.Pages
{
    public class HowWeDoItPage : BasePage
    {
        private const string _breadCrumbsHowWeDoItPageXPath = "//*[@href='/how-we-do-it' and @class='breadcrumbs__link']";

        public override string Url => PageUrls.HowWeDoItPageUrl;

        public override Title Title => new Title(By.TagName("h1"));

        public BreadCrumbs HowWeDoItPageBreadCrumbs => new BreadCrumbs(By.XPath(_breadCrumbsHowWeDoItPageXPath));

        public bool BreadCrumsHowWeDoItPageIsDisplayed()
        {
            return HowWeDoItPageBreadCrumbs.IsDisplayed();
        }
    }
}
