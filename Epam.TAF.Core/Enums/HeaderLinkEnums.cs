using Epam.TAF.Core.Helpers;
using NUnit.Framework;

namespace Epam.TAF.Core.Enums
{
    public enum HeaderLinkEnums
    {
        [HeaderLink("Services")]
        Services,
        [HeaderLink("Insights")]
        Insights,
        [HeaderLink("About")]
        About,
        [HeaderLink("Careers")]
        Careers,
        [HeaderLink("How We Do It")]
        HowWeDoIt,
        [HeaderLink("Our Work")]
        OurWork,
    }
}
