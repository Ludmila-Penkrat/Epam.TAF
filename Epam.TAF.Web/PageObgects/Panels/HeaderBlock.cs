using Epam.TAF.Core.Browser;
using Epam.TAF.Core.Elements;
using Epam.TAF.Web.PageObgects.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace Epam.TAF.Web.PageObgects.Panels
{
    public class HeaderBlock : BasePanel
    {
        public HeaderBlock(By locator) : base(locator) { }

        private const string _epamLogoHeaderXPath = "//*[@class='header__logo-container']";
        private const string _careersLinkHeaderXPath = "//*[@class ='top-navigation__item-link' and @href = '/careers']";
        private const string _servicesLinkHeaderXPath = "//*[@href='/services' and contains(@class, 'top-navigation__item-link')]";
        private const string _searchPanelXPath = "//*[contains(@class, 'header-search__panel')]";
        private const string _headerNavigationLinksXPath = "//li[contains(@class, 'top-navigation__item')]"; //"//*[@class='top-navigation__item epam']";
        private const string _careerPanelWithLinksXPath = "//*[@class='top-navigation__flyout']";

        public CareersPanel CareersPanel => new CareersPanel(By.XPath(_careerPanelWithLinksXPath));

        public SearchPanel SearchPanel => new SearchPanel(By.XPath(_searchPanelXPath));

        public Link EpamLogoHeader => new Link(By.XPath(_epamLogoHeaderXPath));

        public Link CareersLink => new Link(By.XPath(_careersLinkHeaderXPath));

        public Link ServicesLink => new Link(By.XPath(_servicesLinkHeaderXPath));

        public ElementsList<Link> HeaderNavigationLinks => new ElementsList<Link>(By.XPath(_headerNavigationLinksXPath));

        public Link GetHeaderNavigationLinkByName(string headerLinkName)
        {
            return HeaderNavigationLinks.GetElements().Where(x => x.GetText().ToLower().Equals(headerLinkName.ToLower())).FirstOrDefault();
        }

        public void OpenJoinOurTeamPageViaCareersHeaderLink()
        {
            BrowserFactory.Browser.Actions().MoveToElement(CareersLink.OriginalElement).Build().Perform();

            CareersPanel.JoinOurTeamCareerLink.Click();
        }

        public void ClickLogoEpam()
        {
            EpamLogoHeader.Click();
        }
    }
}
