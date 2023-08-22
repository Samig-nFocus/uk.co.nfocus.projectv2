using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace uk.co.nfocus.projectv2.POM_Pages
{
    internal class CouponPOM
    {
        private IWebDriver _driver;

        // constructor
        public CouponPOM(IWebDriver driver)
        {
            _driver = driver;
        }

        //locators for coupon
        private IWebElement _enterCoupon => _driver.FindElement(By.CssSelector("#coupon_code"));
        private IWebElement _applyCoupon => _driver.FindElement(By.CssSelector("#post-5 > div > div > form > table > tbody > tr:nth-child(2) > td > div > button"));

        //locators for discount and subtotal
        private IWebElement _discount => new WebDriverWait(_driver, TimeSpan.FromSeconds(5)).Until(drv => drv.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.cart-discount.coupon-edgewords > td > span"))); 
        private IWebElement _subtotal => _driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.cart-subtotal > td > span > bdi"));

        //locators for total and shipping
        private IWebElement _total => _driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.order-total > td > strong > span > bdi"));
        private IWebElement _shipping => _driver.FindElement(By.CssSelector("#shipping_method > li > label > span > bdi"));
        
        //setter for coupon
        public CouponPOM SetCoupon(string couponCode)
        {
            _enterCoupon.Click();
            _enterCoupon.Clear();
            _enterCoupon.SendKeys(couponCode);
            return this;
        }

        // apply coupon method
        public void ApplyCoupon()
        {
            _applyCoupon.Click();
        }
        
        // coupon method
        public void Coupon(string couponCode)
        {
            SetCoupon(couponCode);
            ApplyCoupon();
        }

        // discount method
        public void CheckDiscountedTotal(int p)
        {
            // convert the coupon and subtotal value into decimal and remove £
            decimal discountAmount = Decimal.Parse(_discount.Text.Replace("£", ""));
            decimal subtotalAmount = Decimal.Parse(_subtotal.Text.Replace("£", ""));
            decimal totalAmount = Decimal.Parse(_total.Text.Replace("£", ""));
            decimal shippingAmount = Decimal.Parse(_shipping.Text.Replace("£", ""));

            // expected discount is 15% (parameter) of subtotal
            decimal expectedDiscount = subtotalAmount * p/100;

            // assert expected discount matches discount calculated
            Assert.AreEqual(expectedDiscount, discountAmount, "Coupon discount is not 15% of subtotal");

            // expected total = selected values added up
            decimal expectedTotal = (subtotalAmount - discountAmount) + shippingAmount;

            // assert that expected total = displayed total
            Assert.AreEqual(expectedTotal, totalAmount, "Total is not correct");

        }
    }
}
