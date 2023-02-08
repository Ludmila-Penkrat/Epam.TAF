
namespace Epam.TAF.Core.Elements
{
    public interface IBaseElement
    {
        string GetText();

        string GetAttribut(string attributeName);

        void Click();

        void SendKeys(string text);

        void Clear();

        bool IsDisplayed();

        bool IsEnabled();
    }
}
