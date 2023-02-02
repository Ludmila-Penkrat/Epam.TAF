
using Epam.TAF.Core.Enums;
using Epam.TAF.Web.PageObgects.Pages;
using Epam.TAF.Web.PageObgects.Panels;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Epam.TAF.BDD.Steps.SharedComponents
{
    [Binding]
    public class HeaderSteps
    {
        private HeaderBlock Header => new MainPage().HeaderBlock;

        [When(@"I click on Logo EPAM on Header")]
        public void WhenIClickOnLogoEPAMOnHeader()
        {
            Header.ClickLogoEpam();
        }

        [When(@"I click on Header Link '(Services|Insights|About|Careers)'")]
        public void WhenIClickOnHeaderLinkServices(HeaderLinkEnums headerLink)
        {
                    Header.GetHeaderNavigationLinkByName(headerLink.ToString()).Click();
                    
            }

        }
    }

