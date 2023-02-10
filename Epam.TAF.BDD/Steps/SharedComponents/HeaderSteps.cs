
using Epam.TAF.Core.Enums;
using Epam.TAF.Core.Helpers;
using Epam.TAF.Web.PageObgects.Pages;
using Epam.TAF.Web.PageObgects.Panels;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Epam.TAF.BDD.Steps.SharedComponents
{
    [Binding]
    public class HeaderSteps
    {
        private HeaderBlock Header => new MainPage().HeaderBlock;

        [When(@"I click on Logo EPAM on Header")]
        public void WhenIClickOnLogoEPAMOnHeader()
        {
            Header.ClickLogoEpam();
        }

        [When(@"I click on Header Link '(Services|Insights|About|Careers|How We Do It|Our Work)'")]
        public void WhenIClickOnHeaderLinkServices(HeaderLinkEnums headerLink)
        {
             var linkName = headerLink.GetAttribute<HeaderLinkAttribute>().LinkName.ToString();
             Header.GetHeaderNavigationLinkByName(linkName).Click();
        }
    }
}

