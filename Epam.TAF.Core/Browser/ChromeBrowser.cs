using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Epam.TAF.Core.Browser
{
    public class ChromeBrowser : IDriverFactory
    {
        public IWebDriver GetDriver()
        {
            var chromeOption = new ChromeOptions();
            chromeOption.AddArgument("--start-maximized");
            var service = ChromeDriverService.CreateDefaultService();
            var chromeDriver = new ChromeDriver(service, chromeOption, TimeSpan.FromMinutes(2));
            return chromeDriver;
        }
    }
}
