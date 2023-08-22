using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace uk.co.nfocus.projectv2.Utilities
{
    public class Base
    {
        // children classes can access
        protected static IWebDriver driver;

        [Before]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [After]
        public void TearDown()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Test now Complete.");
            driver.Quit();
        }
    }
}
