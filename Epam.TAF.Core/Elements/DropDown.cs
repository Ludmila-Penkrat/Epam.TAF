using OpenQA.Selenium;

namespace Epam.TAF.Core.Elements
{
    public class DropDown :BaseElement
    {
        public DropDown(IWebElement element) : base(element)
        {
        }

        public DropDown(By locator) : base(locator)
        {
        }
    }
}
