using OpenQA.Selenium;

namespace Epam.TAF.Core.Browser
{
    public interface IDriverFactory
    {
        public IWebDriver GetDriver();
    }
}
