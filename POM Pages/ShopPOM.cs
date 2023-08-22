using OpenQA.Selenium;
using static uk.co.nfocus.projectv2.Utilities.Helpers;

namespace uk.co.nfocus.projectv2.POM_Pages
{
    internal class ShopPOM
    {
        private IWebDriver _driver;

        // constructor
        public ShopPOM(IWebDriver driver)
        {
            _driver = driver;
        }

        // locators
        private IWebElement _shopButton => _driver.FindElement(By.LinkText("Shop"));
        private IWebElement _closeMessage => _driver.FindElement(By.CssSelector("body > p > a"));
        private IWebElement _addItemButton => _driver.FindElement(By.CssSelector("#main > ul > li.product.type-product.post-27.status-publish.first.instock.product_cat-accessories.has-post-thumbnail.sale.shipping-taxable.purchasable.product-type-simple > a.button.product_type_simple.add_to_cart_button.ajax_add_to_cart"));
        private IWebElement _viewCartButton => WaitForElement(_driver, By.LinkText("View cart"));


        // navigation method
        public void NavigateToShop()
        {
            _shopButton.Click();
        }

        // closes messages if displayed
        public void CloseMessageIfDisplayed()
        {
            if (_closeMessage.Displayed)
            {
                _closeMessage.Click();
            }
        }

        // add item click method
        public void AddItem()
        {
            _addItemButton.Click();
        }

        // view cart click method
        public void ViewCart()
        {
            _viewCartButton.Click();
        }

        // method to add item and view cart
        public void AddItemToCart()
        {
            NavigateToShop();
            CloseMessageIfDisplayed();
            AddItem();
            ViewCart();
        }
    }
}

