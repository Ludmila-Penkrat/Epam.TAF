using Epam.TAF.Core.Enums;
using Epam.TAF.Core.Utils;
using NUnit.Framework;

namespace Epam.TAF.Core.Helpers
{
    public static class TestSettings
    {
        public static TestContext? TestContext { get; set; }

        private static string GetParameter(string name, string? defaultName = null)
        {

            return TestContext.Parameters[name];


            if (!string.IsNullOrEmpty(defaultName))
            {
                return defaultName;
            }
            return string.Empty;
        }

        public static BrowserTypes Browser => EnumUtils.ParseEnum<BrowserTypes>(GetParameter("Browser", "Chrome"));

        public static string ApplicationUrl => GetParameter("ApplicationUrl", "https://www.epam.com/");

        public static string LogsPath => Path.Join(GetParameter("LogsPath"));

        public static string ScreenShotPath => Path.Join(GetParameter("ScreenShotPath"));

        //public static TimeSpan WebDriverTimeOut => TimeSpan.FromSeconds(int.Parse(TestContext.Parameters.Get("WebDriverTimeOut", 100).ToString()));
        public static TimeSpan WebDriverTimeOut => TimeSpan.FromSeconds(int.Parse(GetParameter("WebDriverTimeOut").ToString()));

        //public static TimeSpan WaitElementTimeOut => TimeSpan.FromSeconds(int.Parse(TestContext.Parameters.Get("WaitElementTimeOut", 100).ToString()));
        public static TimeSpan WaitElementTimeOut => TimeSpan.FromSeconds(int.Parse(GetParameter("WaitElementTimeOut", "100")));

        public static string DataDir => Path.Join(Directory.GetCurrentDirectory(), GetParameter("TestDataFolder"));
    }
}
