using Epam.TAF.Core.Browser;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Epam.TAF.Core.Elements
{
    public abstract class BaseElement : IBaseElement
    {
        private IWebElement _element;

        protected BaseElement(IWebElement element)
        {
            _element = element;
        }

        protected BaseElement(By locator)
        {
            _element = BrowserFactory.Browser.FindElement(locator);
        }

        public IWebElement OriginalElement => _element;

        public string GetAttribut(string attributeName) => OriginalElement.GetAttribute(attributeName);

        public string GetText() => OriginalElement.Text.Trim();

        public void Click()
        {
            OriginalElement.Click();
        }

        public void SendKeys(string text)
        {
            OriginalElement.SendKeys(text);
        }

        public void Clear()
        {
            OriginalElement.Clear();
        }

        public bool IsDisplayed() => OriginalElement.Displayed;

        public bool IsEnabled() => OriginalElement.Enabled;

        public IWebElement FindElement(By by) => OriginalElement.FindElement(by);

        public ReadOnlyCollection<IWebElement> FindElements(By by) => OriginalElement.FindElements(by);
    }
}