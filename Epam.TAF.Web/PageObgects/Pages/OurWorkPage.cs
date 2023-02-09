using Epam.TAF.Core.BasePage;
using Epam.TAF.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TAF.Web.PageObgects.Pages
{
    public class OurWorkPage : BasePage
    {
        private const string _ourWorkPageBreadCrumbsXPath = "//*[@href='/our-work' and @class='breadcrumbs__link']";

        public override string Url => PageUrls.OurWorkPageUrl;

        public override Title Title => new Title(By.TagName("h1"));

        public BreadCrumbs OurWorkPageBreadCrumbs => new BreadCrumbs(By.XPath(_ourWorkPageBreadCrumbsXPath));

        public bool OurWorkPageBreadcrumbsIsDisplayed()
        {
            return OurWorkPageBreadCrumbs.IsDisplayed();
        }
    }
}
