using OpenQA.Selenium;

namespace uk.co.nfocus.projectv2.Utilities
{
    internal class ScreenshotHelper
    {
        private IWebDriver _driver;

        public ScreenshotHelper(IWebDriver driver)
        {
            _driver = driver;
        }

        // screenshot method
        public void ScreenshotTaker()
        {
            // screenshot driver
            Thread.Sleep(1000);
            ITakesScreenshot ssdriver = _driver as ITakesScreenshot;
            Screenshot screenshot = ssdriver.GetScreenshot();

            // returns the full path, from this directory to main parent directory (solution folder) 
            string solutionPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            // combines solution path to path to TestResults Folder
            string testResultsFolder = Path.Combine(solutionPath, "TestResults");

            // combines TestResults path to save screenshot
            string screenshotPath = Path.Combine(testResultsFolder, "OrderNumber.png");

            // saves screenshot on TestResults Folder
            screenshot.SaveAsFile(screenshotPath);
        }
    }
}
