using Epam.TAF.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TAF.Web.PageObgects.Panels
{
    public class HeaderBlock : BasePanel
    {
        public HeaderBlock(By locator) : base(locator) { }

        private const string _epamLogoHeaderXPath = "//*[@class='header__logo-container']";
        private const string _careersLinkHeaderXPath = "//*[@class ='top-navigation__item-link' and @href = '/careers']";
        private const string _servicesLinkHeaderXPath = "//*[@href='/services' and contains(@class, 'top-navigation__item-link')]";
        private const string _searchPanelXPath = "//*[contains(@class, 'header-search__panel')]";

        public SearchPanel SearchPanel => new SearchPanel(By.XPath(_searchPanelXPath));

        public Link EpamLogoHeader => new Link(By.XPath(_epamLogoHeaderXPath));

        public Link CareersLink => new Link(By.XPath(_careersLinkHeaderXPath));

        public Link ServicesLink => new Link(By.XPath(_servicesLinkHeaderXPath));
    }
}
