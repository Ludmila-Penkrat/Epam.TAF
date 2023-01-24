using OpenQA.Selenium;

namespace Epam.TAF.Core.Elements
{
    public class CheckBox : BaseElement
    {
        public CheckBox(IWebElement element) : base(element)
        {
        }

        public CheckBox(By locator) : base(locator)
        {
        }
    }
}
