using Epam.TAF.Core.Browser;
using Epam.TAF.Core.Helpers;
using Epam.TAF.Core.Utils;
using Epam.TAF.Utilities.Logger;
using NUnit.Framework;

namespace Epam.TAF.Tests
{
    public abstract class BaseTest
    {
        public TestContext? TestContext { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Logger.InitLogger(TestContext.CurrentContext.Test.Name, Path.Join(TestContext.CurrentContext.TestDirectory, TestSettings.LogsPath));
        }

        [SetUp]
        public void BeforeTest()
        {
            Logger.Info("Test is began");
            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl);
            Waiters.WaitForPageLoad();
        }

        [TearDown]
        public void CleanTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Logger.Info("Test is failed");
                BrowserFactory.Browser.SaveScreenShot(TestContext.CurrentContext.Test.MethodName, Path.Join(TestContext.CurrentContext.TestDirectory, TestSettings.ScreenShotPath));
            }
            Logger.Info("Test is finished");
            BrowserFactory.CloseBrowser();
        }
    }
}
