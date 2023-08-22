using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace uk.co.nfocus.projectv2.POM_Pages
{
    internal class LoginPOM
    {
        private IWebDriver _driver;

        // constructor
        public LoginPOM(IWebDriver driver)
        {
            _driver = driver;
        }

        // locators username, password and submit button
        private IWebElement _loginUsername => new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(drv => drv.FindElement(By.Id("username")));
        private IWebElement _loginPassword => new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(drv => drv.FindElement(By.Id("password")));
        private IWebElement _loginButton => _driver.FindElement(By.CssSelector("#customer_login > div.u-column1.col-1 > form > p:nth-child(3) > button"));
        private IWebElement _logoutButton => _driver.FindElement(By.LinkText("Logout"));

        // setter for username
        public LoginPOM SetUsername(string username)
        {
            _loginUsername.Clear();
            _loginUsername.SendKeys(username);
            return this;
        }

        // setter for password
        public LoginPOM SetPassword(string password)
        {
            _loginPassword.Clear();
            _loginPassword.SendKeys(password);
            return this;
        }
        
        // submit method
        public void Submit()
        {
            _loginButton.Click();
        }

        // login method
        public void Login(string username, string password)
        {
            SetUsername(username);
            SetPassword(password);
            Submit();
        }

        // logout method
        public void Logout()
        {
            _logoutButton.Click();
        }

    }
}
