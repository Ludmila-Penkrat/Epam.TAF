using Epam.TAF.Core.Enums;
using Epam.TAF.Core.Utils;
using NUnit.Framework;

namespace Epam.TAF.Core.Helpers
{
    public static class TestSettings
    {
        public static TestContext TestContext { get; set; }

        private static string GetParameter(string name, string defaultName = null)
        {

            return TestContext.Parameters[name];


            if (!string.IsNullOrEmpty(defaultName))
            {
                return defaultName;
            }
            return string.Empty;
        }

        public static BrowserTypes Browser => EnumUtils.ParseEnum<BrowserTypes>(GetParameter("Browser", "ChromeDriver"));

        public static string ApplicationUrl => GetParameter("ApplicationUrl", "https://www.epam.com/");

        //public static string LogsPath => Path.Combine(TestContext.TestDirectory, @GetParameter("LogsPath"));

        public static string LogsPath => Path.Combine(@GetParameter("LogsPath"));


        public static string ScreenShotPath => Path.Combine(GetParameter("ScreenShotPath"));

        public static TimeSpan WebDriverTimeOut => TimeSpan.FromSeconds(int.Parse(TestContext.Parameters.Get("WebDriverTimeOut").ToString()));

        public static TimeSpan WaitElementTimeOut => TimeSpan.FromSeconds(int.Parse(TestContext.Parameters.Get("WaitElementTimeOut").ToString()));
    }
}
