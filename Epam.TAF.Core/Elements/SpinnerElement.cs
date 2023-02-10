using OpenQA.Selenium;

namespace Epam.TAF.Core.Elements
{
    public class SpinnerElement : BaseElement
    {
        public SpinnerElement(IWebElement element) : base(element)
        {
        }

        public SpinnerElement(By locator) : base(locator)
        {
        }
    }
}
