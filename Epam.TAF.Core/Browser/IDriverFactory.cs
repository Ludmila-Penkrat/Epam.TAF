using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TAF.Core.Browser
{
    public interface IDriverFactory
    {
        public IWebDriver GetDriver();
    }
}
