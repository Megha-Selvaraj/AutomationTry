using Bogus;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomationTry.TestTool.PageObject
{
    public class SubmitDetails
    {
        private readonly IWebDriver driver;
        public static Faker Faker { get; } = new Faker();

        private readonly By _name = By.Id("inputName");
        private readonly By _cardNumber = By.Id("creditCardNumber");
        private readonly By _purchase = By.XPath("//input[@value='Purchase Flight']");
        private IWebElement Name => driver.FindElement(_name);
        private IWebElement CardNumber => driver.FindElement(_cardNumber);
        private IWebElement PurchaseButton => driver.FindElement(_purchase);
        public SubmitDetails(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void FillUserDetails()
        {
            Name.SendKeys(Faker.Name.FullName());
            CardNumber.SendKeys(Faker.Phone.PhoneNumber("##########"));
        }

        public void Purchase()
        {
            PurchaseButton.Click();
        }
    }
}
