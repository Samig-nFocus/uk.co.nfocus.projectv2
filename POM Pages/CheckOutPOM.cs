using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace uk.co.nfocus.projectv2.POM_Pages
{
    internal class CheckOutPOM
    {
        private IWebDriver _driver;

        // constructor
        public CheckOutPOM(IWebDriver driver)
        {
            _driver = driver;
        }

        // locator
        private IWebElement _checkoutButton => _driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > div > a"));

        // method to scroll down to checkout button and click
        public void CheckOut() 
        {
            Actions scrollDown = new Actions(_driver);
            scrollDown.MoveToElement(_checkoutButton);
            scrollDown.Perform();

            _checkoutButton.Click();
        }
    }
}
