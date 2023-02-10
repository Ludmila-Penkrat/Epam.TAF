using OpenQA.Selenium;

namespace Epam.TAF.Core.Elements
{
    public class TextInput : BaseElement
    {
        public TextInput(IWebElement element) : base(element)
        {
        }

        public TextInput(By locator) : base(locator)
        {
        }
    }
}
