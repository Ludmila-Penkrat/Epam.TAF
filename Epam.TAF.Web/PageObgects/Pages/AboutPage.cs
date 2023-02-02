using Epam.TAF.Core.BasePage;
using Epam.TAF.Core.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TAF.Web.PageObgects.Pages
{
    public class AboutPage : BasePage
    {
        private const string _aboutPageBreadCrumbsXPath = "//*[@href = '/about' and @class='breadcrumbs__link']";

        public override string Url => "https://www.epam.com/about";

        public override Title Title => new Title(By.TagName("h1"));

        public BreadCrumbs AboutBreadCrumbs => new BreadCrumbs(By.XPath(_aboutPageBreadCrumbsXPath));

        public bool AboutPageBreadCrumsIsDisplayed()
        {
            return AboutBreadCrumbs.IsDisplayed();
        }
    }
}
