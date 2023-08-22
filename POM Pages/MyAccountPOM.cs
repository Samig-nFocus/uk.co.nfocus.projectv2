using OpenQA.Selenium;

namespace uk.co.nfocus.projectv2.POM_Pages
{
    internal class MyAccountPOM
    {
        private IWebDriver _driver;

        // constructor
        public MyAccountPOM(IWebDriver driver)
        {
            _driver = driver;
        }

        // navigates to My Account Page
        public void Navigate()
        {
            _driver.Url = "https://www.edgewordstraining.co.uk/demo-site/my-account/";
        }
    }
}
