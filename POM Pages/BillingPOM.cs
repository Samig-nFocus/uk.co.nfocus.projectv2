using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.projectv2.POM_Pages
{
    internal class BillingPOM
    {
        private IWebDriver _driver;

        // constructor 
        public BillingPOM(IWebDriver driver)
        {
            _driver = driver;
        }

        // locators
        private IWebElement _nameField => _driver.FindElement(By.Id("billing_first_name"));
        private IWebElement _lastnameField => _driver.FindElement(By.Id("billing_last_name"));
        private IWebElement _companyName => _driver.FindElement(By.Id("billing_company"));
        private IWebElement _streetAddress => _driver.FindElement(By.Id("billing_address_1"));
        private IWebElement _city => _driver.FindElement(By.Id("billing_city"));
        private IWebElement _postcode => _driver.FindElement(By.Id("billing_postcode"));
        private IWebElement _phone => _driver.FindElement(By.Id("billing_phone"));
        private IWebElement _email => _driver.FindElement(By.Id("billing_email"));
        private IWebElement _paymentCheck => new WebDriverWait(_driver, TimeSpan.FromSeconds(5)).Until(drv => drv.FindElement(By.CssSelector("#payment > ul > li.wc_payment_method.payment_method_cheque > label")));
        private IWebElement _placeOrder => new WebDriverWait(_driver, TimeSpan.FromSeconds(5)).Until(drv => drv.FindElement(By.CssSelector("#place_order")));
       
        // setters
        public BillingPOM SetName(string name)
        {
            _nameField.Clear();
            _nameField.SendKeys(name);
            return this;

        }
        public BillingPOM SetLastname(string lastname)
        {
            _lastnameField.Clear();
            _lastnameField.SendKeys(lastname);
            return this;
        }
        public BillingPOM SetCompany(string company)
        {
            _companyName.Clear();
            _companyName.SendKeys(company);
            return this;
        }
        public BillingPOM SetAddress(string address)
        {
            _streetAddress.Clear();
            _streetAddress.SendKeys(address);
            return this;
        }
        public BillingPOM SetCity(string city)
        {
            _city.Clear();
            _city.SendKeys(city);
            return this;
        }
        public BillingPOM SetPostcode(string postcode)
        {
            _postcode.Clear();
            _postcode.SendKeys(postcode);
            return this;
        }
        public BillingPOM SetPhone(string phone)
        {
            _phone.Clear();
            _phone.SendKeys(phone);
            return this;
        }
        public BillingPOM SetEmail(string email)
        {
            _email.Clear();
            _email.SendKeys(email);
            return this;
        }

        // method to check payments
        public void CheckPayments()
        {
            _paymentCheck.Click();
            
        }

        // method to place order
        public void PlaceOrder()
        {
            _placeOrder.Click();
        }

        // method for billing details
        public void OrderDetails(string name, string lastname, string company, string address, string city, string postcode, string phone, string email)
        {
            SetName(name);
            SetLastname(lastname);
            SetCompany(company);
            SetAddress(address);
            SetCity(city);
            SetPostcode(postcode);
            SetPhone(phone);
            SetEmail(email);
        }

        // method for placing order
        public void Order()
        {
            CheckPayments();
            PlaceOrder();
        }
    }
}
