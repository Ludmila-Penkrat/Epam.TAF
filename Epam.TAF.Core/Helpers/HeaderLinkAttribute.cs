
namespace Epam.TAF.Core.Helpers
{
    public class HeaderLinkAttribute : Attribute
    {
        public string LinkName { get; private set; }

        public HeaderLinkAttribute(string linkName)
        {
            LinkName = linkName;
        }
    }
}
