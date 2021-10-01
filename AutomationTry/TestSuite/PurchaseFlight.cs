using AutomationTry.TestTool.Configuration;
using AutomationTry.TestTool.PageObject;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace AutomationTry
{
    public class PurchaseFlight
    {
        private readonly string BrowserUrl = "https://blazedemo.com/";
        public IWebDriver webDriver;
        public PurchaseFlight()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(BrowserUrl);
        }

        [Fact]
        public void Test_Should_PurchaseFlight()
        {
            SelectLocationPage selectLocationPage = new SelectLocationPage(webDriver);
            selectLocationPage.SelectFromPort();
            selectLocationPage.SelectToPort();
            selectLocationPage.SubmitForm();

            SelectFlight selectFlight = new SelectFlight(webDriver);
            selectFlight.SelectRandomFlight();

            SubmitDetails submitDetails = new SubmitDetails(webDriver);
            submitDetails.FillUserDetails();
            submitDetails.Purchase();

            PurchaseConfirmationPage purchaseConfirmationPage = new PurchaseConfirmationPage(webDriver);
            string purchaseId = purchaseConfirmationPage.PurchaseConfirmed();
            purchaseId.Should().NotBeNull();

            webDriver.Quit();
        }

        [Fact]
        public void Test_Should_NotPurchaseFlightWhenDetailsNotSubmitted()
        {
            /*As of now test case will fail since there is NO UI Validation*/
            SelectLocationPage selectLocationPage = new SelectLocationPage(webDriver);
            selectLocationPage.SelectFromPort();
            selectLocationPage.SelectToPort();
            selectLocationPage.SubmitForm();

            SelectFlight selectFlight = new SelectFlight(webDriver);
            selectFlight.SelectRandomFlight();

            SubmitDetails submitDetails = new SubmitDetails(webDriver);
            submitDetails.Purchase();

            PurchaseConfirmationPage purchaseConfirmationPage = new PurchaseConfirmationPage(webDriver);
            string purchaseId = purchaseConfirmationPage.PurchaseConfirmed();
            purchaseId.Should().BeNull();

            webDriver.Quit();
        }

        [Fact]
        public void Test_Should_ReturnIdAfterPurchase()
        {
            /*As of now test case will fail since there is NO UI Validation*/
            SelectLocationPage selectLocationPage = new SelectLocationPage(webDriver);
            selectLocationPage.SelectFromPort();
            selectLocationPage.SelectToPort();
            selectLocationPage.SubmitForm();

            SelectFlight selectFlight = new SelectFlight(webDriver);
            selectFlight.SelectRandomFlight();

            SubmitDetails submitDetails = new SubmitDetails(webDriver);
            submitDetails.FillUserDetails();
            submitDetails.Purchase();

            PurchaseConfirmationPage purchaseConfirmationPage = new PurchaseConfirmationPage(webDriver);
            string purchaseId = purchaseConfirmationPage.PurchaseConfirmed();
            purchaseId.Should().NotBeNull();

            webDriver.Quit();
        }
    }
}
