using OpenQA.Selenium;

namespace Epam.TAF.Core.Elements
{
    public class Panel : BaseElement
    {
        public Panel(IWebElement element) : base(element)
        {
        }

        public Panel(By locator) : base(locator)
        {
        }
    }
}
