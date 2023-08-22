using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using uk.co.nfocus.projectv2.POM_Pages;
using uk.co.nfocus.projectv2.Utilities;

namespace uk.co.nfocus.projectv2.StepDefinitions
{
    [Binding]
    public class OrderSteps : Base
    {
        [When(@"the user adds and item and checks out")]
        public void WhenTheUserAddsAndItemAndChecksOut()
        {
            // adds item to cart
            ShopPOM shop = new ShopPOM(driver);
            shop.AddItemToCart();

            // checks out
            CheckOutPOM checkout =new CheckOutPOM(driver);
            checkout.CheckOut();

        }

        [When(@"the user completes the billing form")]
        public void WhenTheUserCompletesTheBillingForm()
        {
            // fills in details
            BillingPOM billingInfo = new BillingPOM(driver);
            billingInfo.OrderDetails("Agile", "Tester", "nFocus Testing", "e-Innovation Centre", "Telford", "TF2 9FT", "0370 242 6235", "abc19072023@gmail.com");

            Thread.Sleep(500);

            // places order
            billingInfo.Order();

        }

        [Then(@"the order number is generated and also visible in Orders Page")]
        public void ThenTheOrderNumberIsGenerated()
        {
            // takes screenshot of order number
            ScreenshotHelper screenshot = new ScreenshotHelper(driver);
            screenshot.ScreenshotTaker();

            // order check
            OrderPOM orderCheck = new OrderPOM(driver);
            orderCheck.GetOrderNumber();

            // logout
            LoginPOM logout = new LoginPOM(driver);
            logout.Logout();
        }
    }
}
