using Epam.TAF.Core.Browser;
using Epam.TAF.Core.Helpers;
using Epam.TAF.Core.Utils;
using Epam.TAF.Utilities.Logger;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Epam.TAF.BDD.Steps.GeneralSteps
{
    [Binding]
    public class SetupSteps
    {
        [BeforeFeature(Order = 1)]
        public static void OneTimeSetUp()
        {
            Logger.InitLogger(TestContext.CurrentContext.Test.Name, Path.Join(TestContext.CurrentContext.TestDirectory, TestSettings.LogsPath));
        }

        [BeforeScenario()]
        public static void BeforeTest()
        {
            Logger.Info("Test is began");
            BrowserFactory.Browser.Maximize();
        }
    }
}
