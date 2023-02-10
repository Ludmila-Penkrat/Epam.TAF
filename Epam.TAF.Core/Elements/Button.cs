using OpenQA.Selenium;

namespace Epam.TAF.Core.Elements
{
    public class Button : BaseElement
    {
        public Button(IWebElement element) : base(element)
        {
        }

        public Button(By locator) : base(locator)
        {
        }
    }
}
