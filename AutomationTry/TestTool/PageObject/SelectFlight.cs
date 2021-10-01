using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomationTry.TestTool.PageObject
{
    public class SelectFlight
    {
        private readonly IWebDriver driver;
        private readonly By _flightList = By.XPath("//input[@value='Choose This Flight']");

        private By SelectedFlight(int index = 1) => By.XPath($"(//input[@value='Choose This Flight'])[{index}]");
        private IWebElement SelectedFlightElement(int index = 1) => driver.FindElement(SelectedFlight(index));
        private IList<IWebElement> FlightList => driver.FindElements(_flightList);

        public SelectFlight(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void SelectRandomFlight()
        {
            int count = FlightList.Count();
            SelectedFlightElement(new Random().Next(1, count)).Click();              
        }
    }
}
