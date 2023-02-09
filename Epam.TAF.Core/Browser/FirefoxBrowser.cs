using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace Epam.TAF.Core.Browser
{
    public class FirefoxBrowser : IDriverFactory
    {
        public IWebDriver GetDriver()
        {
            return new FirefoxDriver();
        }
    }
}
