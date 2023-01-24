using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.TAF.Core.Helpers;
using Epam.TAF.Utilities;
using Epam.TAF.Core.ScreenShot;

namespace Epam.TAF.Core.Browser
{
    public class Browser
    {
        private IWebDriver _driver;

        public string Url
        {
            get => _driver.Url;
            set => _driver.Url = value;
        }

        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetUrl()
        {
            return _driver.Url;
        }

        public string GetTitle()
        {
            return _driver.Title;
        }

        public void Maximize()
        {
            _driver.Manage().Window.Maximize();
        }

        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void Close()
        {
            _driver.Close();
        }

        public void Quite()
        {
            if (_driver == null) return;
            _driver.Quit();
            _driver = null;
        }

        public void NavigateBack()
        {
            _driver.Navigate().Back();
        }

        public void Refresh()
        {
            _driver.Navigate().Refresh();
        }

        public void PageLoader()
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
        }

        #region Waiters

        public WebDriverWait Waiters() => new WebDriverWait(_driver, TestSettings.WebDriverTimeOut);

        #endregion

        #region Actions

        public Actions Actions() => new Actions(_driver);

        #endregion

        #region JavaScript Execution

        public object ExecuteScript(string script, params object[] args)
        {
            try
            {
                return ((IJavaScriptExecutor)_driver).ExecuteScript(script, args);
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.Info($"Error: Timeout Exeption thrown while running JS Script: {ex.Message} - {ex.StackTrace}");
            }
            return null;
        }

        public void SetSessionToken(string token)
        {
            var tokenValue = "{\"type\":\'beare\",\"value\":\"" + token + " \"}";
            ExecuteScript("javascript:localStorage.token = arguments[0];", tokenValue);
        }

        public void ScrollTop()
        {
            Logger.Info("Scroll page top");
            ExecuteScript($"(window).scrollTop(0)");
        }

        public void ScrollToElement(IWebElement element)
        {
            ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void ScrollBy(int px)
        {
            ExecuteScript($"window.scrollBy(0, {px});");
        }

        #endregion

        #region IWebElement

        public IWebElement FindElement(By locator)
        {
            return _driver.FindElement(locator);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return _driver.FindElements(by);
        }

        #endregion

        #region ScreenShot 

        public void SaveScreenShot(string screenShotName, string folderPath)
        {
            try
            {
                Logger.Info("Generating of screenshot started.");
                ScreenShotTaker.TakeScreenShot(_driver, screenShotName, folderPath);
                Logger.Info("Generating of screenshot finished.");
            }
            catch (Exception ex)
            {
                Logger.Info($"Failed to capture screenshot. Exception message {ex.Message}.");
            }
        }
        #endregion
    }
}
