using Epam.TAF.Core.BasePage;
using Epam.TAF.Core.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TAF.Web.PageObgects.Pages
{
    public class HeaderLinkPages : BasePage
    {
        public override string Url => throw new NotImplementedException();

        public override Title Title => new Title(By.TagName("h1"));

    }
}
