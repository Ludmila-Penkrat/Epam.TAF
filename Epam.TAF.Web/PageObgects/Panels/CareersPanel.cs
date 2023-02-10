using Epam.TAF.Core.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TAF.Web.PageObgects.Panels
{
    public class CareersPanel : BasePanel
    {
        public CareersPanel(By locator) : base(locator) { }

        private const string _joinOurTeamLinkOnCareerPanelXPath = "//*[@href='/careers/job-listings']";
        private const string _referralProgramLinkOnCareerPanelXPath = "//*[@href='/careers/external-referral-program']";


        public Link JoinOurTeamCareerLink => new Link(By.XPath(_joinOurTeamLinkOnCareerPanelXPath));
        public Link ReferralProgramCareerLink => new Link(By.XPath(_referralProgramLinkOnCareerPanelXPath));
    }

   

}
