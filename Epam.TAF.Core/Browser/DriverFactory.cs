using Epam.TAF.Core.Enums;
using OpenQA.Selenium;

namespace Epam.TAF.Core.Browser
{
    public static class DriverFactory
    {
        public static IWebDriver GetWebDriver(BrowserTypes browserTypes)
        {
            IWebDriver createdWebDriver;
            switch (browserTypes)
            {
                case BrowserTypes.Firefox:
                    createdWebDriver = new FirefoxBrowser().GetDriver();
                    break;
                case BrowserTypes.Chrome:
                    createdWebDriver = new ChromeBrowser().GetDriver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Unknown browser selected {browserTypes}");
            }
            return createdWebDriver;
        }
    }
}
