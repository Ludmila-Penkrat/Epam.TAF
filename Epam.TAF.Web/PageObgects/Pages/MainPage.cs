using Epam.TAF.Core.BasePage;
using Epam.TAF.Core.Elements;
using Epam.TAF.Web.PageObgects.Panels;
using OpenQA.Selenium;

namespace Epam.TAF.Web.PageObgects.Pages
{
    public class MainPage : BasePage
    {
        private const string _headerXPath = "//*[@class='header-ui']";
        private const string _footerXPath = "//*[@class='footer__holder']";
        private const string _footerCookiesBannerXPath = "//*[@id='onetrust-banner-sdk']";
        private const string _acceptAllCookiesButtonXPath = "//*[@id='onetrust-accept-btn-handler']";
        private const string _searchButtonHeaderXPath = "//*[@class = 'header-search__button header__icon']";

        public override string Url => "https://www.epam.com/";

        public override Title Title => new Title(By.TagName("h1"));

        public HeaderBlock HeaderBlock => new HeaderBlock(By.XPath(_headerXPath));

        public FooterBlock FooterBlock => new FooterBlock(By.XPath(_footerXPath));

        public Button AcceptAllCookiesButton => new Button(By.XPath(_acceptAllCookiesButtonXPath));

        public Panel BannerPanel => new Panel(By.XPath(_footerCookiesBannerXPath));

        public Button SearchButton => new Button(By.XPath(_searchButtonHeaderXPath));

        public void OpenSearchPanel()
        {
            SearchButton.Click();
        }

        public void AcceptAllCookies()
        {
            AcceptAllCookiesButton.Click();
        }

    }
}
