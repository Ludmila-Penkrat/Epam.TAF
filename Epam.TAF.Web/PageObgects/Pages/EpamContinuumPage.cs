using Epam.TAF.Core.BasePage;
using Epam.TAF.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TAF.Web.PageObgects.Pages
{
    public class EpamContinuumPage : BasePage
    {
        private const string _breadCrumbsEpanContinuumPageXPath = "//*[@href='/services/consult-and-design' and @class='breadcrumbs__link']";

        public override string Url => PageUrls.EpamContinuumPageUrl;

        public override Title Title => new Title(By.TagName("h1"));

        public BreadCrumbs EpamContinuumPageBreadCrumbs => new BreadCrumbs(By.XPath(_breadCrumbsEpanContinuumPageXPath));

        public bool BreadCrumsIsDisplayed()
        {
            return EpamContinuumPageBreadCrumbs.IsDisplayed();
        }
    }
}
