using Bogus;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomationTry.TestTool.PageObject
{
    public class PurchaseConfirmationPage
    {
        private readonly IWebDriver driver;
      
        private readonly By _purchaseConfirmationId = By.XPath("//td[contains(text(),'Id')]/following::td[1]");
        private IWebElement PurchaseConfirmationId => driver.FindElement(_purchaseConfirmationId);

        public PurchaseConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public string PurchaseConfirmed()
        {
            return PurchaseConfirmationId.Text;        
        }
    }
}
