using Epam.TAF.Core.Browser;
using Epam.TAF.Core.Helpers;
using Epam.TAF.Utilities.Logger;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Epam.TAF.BDD.Steps.GeneralSteps
{
    [Binding]
    public class TearDownSteps
    {
        [AfterScenario]
        public static void CleanTest()
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
