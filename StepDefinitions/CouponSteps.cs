using uk.co.nfocus.projectv2.POM_Pages;
using uk.co.nfocus.projectv2.Utilities;

namespace uk.co.nfocus.projectv2.StepDefinitions
{
    [Binding]
    public class CouponSteps : Base
    {

        [Given(@"the user logs in with valid username '(.*)' and password '(.*)'")]
        public void GivenTheUserLogsInWithValidUsernameAndPassword(string username, string password)
        {
            // navigates to My Account Page
            MyAccountPOM myAccount = new MyAccountPOM(driver);
            myAccount.Navigate();

            // logs in with username and password
            LoginPOM login = new LoginPOM(driver);
            login.Login(username, password);
        }

        [When(@"the user adds an item and applies the coupon code '(.*)'")]
        public void WhenTheUserAddsAnAndAppliesTheCouponCode(string couponCode)
        {

            // adds item to cart
            ShopPOM shop = new ShopPOM(driver);
            shop.AddItemToCart();

            // applies the coupon code
            CouponPOM coupon = new CouponPOM(driver);
            coupon.Coupon(couponCode);
        }

        [Then(@"the coupon applies (.*)% discount to the total plus shipping")]
        public void ThenTheCouponAppliesDiscountToTheTotalPlusShipping(int discountValue)
        {
            // checks discount applied and total is correct
            CouponPOM discount = new CouponPOM(driver);
            discount.CheckDiscountedTotal(discountValue);
        }
    }
}
