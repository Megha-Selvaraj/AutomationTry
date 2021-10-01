using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationTry.TestTool.PageObject
{
    public class SelectLocationPage
    {
        private readonly By _fromPort = By.Name("fromPort");
        private readonly By _toPort = By.Name("toPort");
        private readonly By _submit = By.XPath("//input[@value='Find Flights']");

        private readonly IWebDriver driver;

        private IWebElement FromPort => driver.FindElement(_fromPort);
        private IWebElement ToPort => driver.FindElement(_toPort);
        private IWebElement Submit => driver.FindElement(_submit);

        public SelectLocationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SelectFromPort()
        {
            var selectElement = new SelectElement(FromPort);
            selectElement.SelectByIndex(new Random().Next(1, 5));              
        }

        public void SelectToPort()
        {
            var selectElement = new SelectElement(ToPort);
            selectElement.SelectByIndex(new Random().Next(1, 5));
        }

        public void SubmitForm()
        {
            Submit.Click();
        }
    }
}
