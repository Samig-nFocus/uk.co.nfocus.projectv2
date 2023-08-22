using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace uk.co.nfocus.projectv2.POM_Pages
{
    internal class OrderPOM
    {
        private IWebDriver _driver;

        // constructor
        public OrderPOM(IWebDriver driver)
        {
            _driver = driver;
        }

        //locators
        private IWebElement _orderNumber => _driver.FindElement(By.CssSelector("#post-6 > div > div > div > ul > li.woocommerce-order-overview__order.order > strong"));
        private IWebElement _navigateToAccount => _driver.FindElement(By.LinkText("My account"));
        private IWebElement _navigateToOrders => _driver.FindElement(By.CssSelector("#post-7 > div > div > nav > ul > li.woocommerce-MyAccount-navigation-link.woocommerce-MyAccount-navigation-link--orders > a"));
        private IWebElement _order => _driver.FindElement(By.CssSelector("#post-7 > div > div > div > table > tbody > tr:nth-child(1) > td.woocommerce-orders-table__cell.woocommerce-orders-table__cell-order-number > a"));

        //navigators
        public void NavigateAccount()
        {
            _navigateToAccount.Click(); 
        }
        public void NavigateOrders()
        {
            _navigateToOrders.Click();
        }

        //method to assert order exist in Orders Page
        public void GetOrderNumber()
        {
            //captures order number
            int orderNo = int.Parse(_orderNumber.Text);

            NavigateAccount();
            NavigateOrders();

            //captures the latest order and removes #
            int orderNo2 = int.Parse(_order.Text.Replace("#", ""));

            //asserts to check the same order
            Assert.AreEqual(orderNo, orderNo2, "Order does not correct");

        }
    }
}
