using Epam.TAF.Core.Helpers;
using OpenQA.Selenium;

namespace Epam.TAF.Core.ScreenShot
{
    public static class ScreenShotTaker
    {
        public static void TakeScreenShot(IWebDriver driver, string testName, string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string screenFileName = $"{testName}_{DateTime.Now:dd.MM}.{ScreenshotImageFormat.Jpeg.ToString().ToLowerInvariant()}";

            string screenPath = Path.Join(TestSettings.ScreenShotPath, screenFileName);

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(screenPath);
        }
    }
}
