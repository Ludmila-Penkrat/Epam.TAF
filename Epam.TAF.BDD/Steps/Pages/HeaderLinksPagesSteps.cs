using Epam.TAF.Core.Enums;
using Epam.TAF.Web.PageObgects.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Epam.TAF.BDD.Steps.Pages
{
    [Binding]
    public class HeaderLinksPagesSteps
    {
        AboutPage AboutPage => new();
        CareersPage CareersPage => new();
        InsightsPage InsightsPage => new();
        ServicesPage ServicesPage => new();

        //[Then(@"I check that '(Services|Insights|About|Careers)' page is opened")]
        //public void ThenICheckThatPageIsOpened(HeaderLinkEnums headerLink)
        //{
        //    var expectedResult = false;
        //    switch (headerLink)
        //    {

        //        case HeaderLinkEnums.Services:
        //            expectedResult = ServicesPage.ServisesPageBreadcrumbsIsDisplayed();
        //            Assert.That(expectedResult, Is.True, "Servises page isn't opened");
        //            break;
        //        case HeaderLinkEnums.Insights:
        //            expectedResult = InsightsPage.InsightsPageBreadCrumbsIsDisplayed();
        //            Assert.That(expectedResult, Is.True, "Insights page isn't opened");
        //            break;
        //        case HeaderLinkEnums.About:
        //            expectedResult = AboutPage.AboutPageBreadCrumsIsDisplayed();
        //            Assert.That(expectedResult, Is.True, "About page isn't opened");
        //            break;
        //        case HeaderLinkEnums.Careers:
        //            expectedResult = CareersPage.CareersPageBreadcrumbsIsDisplayed();
        //            Assert.That(expectedResult, Is.True, "Careers page isn't opened");
        //            break;
        //    }
        //}
    }
}
