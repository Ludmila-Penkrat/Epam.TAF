using Epam.TAF.Core.Browser;
using Epam.TAF.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TAF.Core.BasePage
{
    public abstract class BasePage
    {
        public abstract string Url { get; }

        public abstract Title Title { get; }

        public bool IsPageOpenedByUrl()
        {
            return BrowserFactory.Browser.GetUrl().Equals(Url);
        }

        public bool IsPageOpenedByTitle()
        {
            return Title.IsDisplayed();
        }

        public string GetPageUrl()
        {
            return BrowserFactory.Browser.GetUrl();
        }

        public void NavigateToPage()
        {
            BrowserFactory.Browser.GoToUrl(Url);
        }

        public IWebElement FindElement(By by)
        {
            return BrowserFactory.Browser.FindElement(by);
        }

        public IReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return BrowserFactory.Browser.FindElements(by);
        }
    }
}
