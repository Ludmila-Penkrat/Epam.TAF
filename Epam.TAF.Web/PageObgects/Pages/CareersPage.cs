using Epam.TAF.Core.BasePage;
using Epam.TAF.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TAF.Web.PageObgects.Pages
{
    public class CareersPage : BasePage
    {
        private const string _careersBreadCrumbsXPath = "//*[@href = '/careers' and @class='breadcrumbs__link']";

        public override string Url => PageUrls.CareersPageUrl;

        public override Title Title => new Title(By.TagName("h1"));

        public BreadCrumbs CareersPageBreadCrumbs => new BreadCrumbs(By.XPath(_careersBreadCrumbsXPath));

        public bool CareersPageBreadcrumbsIsDisplayed()
        {
            return CareersPageBreadCrumbs.IsDisplayed();
        }
    }
}
