using Epam.TAF.Core.BasePage;
using Epam.TAF.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TAF.Web.PageObgects.Pages
{
    public class ServicesPage : BasePage
    {
        private const string _servicesBreadCrumbsXPath = "//*[@href = '/services' and @class='breadcrumbs__link']";

        public override string Url => "https://www.epam.com/services";

        public override Title Title => new Title(By.TagName("h1"));

        public BreadCrumbs ServicesPageBreadCrumbs => new BreadCrumbs(By.XPath(_servicesBreadCrumbsXPath));

        public bool ServisesPageBreadcrumbsIsDisplayed()
        {
            return ServicesPageBreadCrumbs.IsDisplayed();
        }
    }
}
