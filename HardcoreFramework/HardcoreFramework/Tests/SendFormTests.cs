using HardcoreFramework.Models;
using HardcoreFramework.Pages.GoogleCloud;
using HardcoreFramework.Pages.Yopmail;
using HardcoreFramework.Service;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;

namespace HardcoreFramework.Tests
{
    [TestFixture]
    public class SendFormTests : CommonConditions
    {
        [Test]
        [Category("All")]
        public void FillFormAndCheckTest()
        {
            ComputeEngine form = ComputeEngineCreator.WithCredentialsFromProperty();

            driver.Navigate().GoToUrl(GOOGLE_CLOUD_URL);
            GCPricingCalculatorPage calc = new GCMainPage()
                .SearchInformation(INFO_TO_SEARCH)
                .GoToCalculator()
                .ActivateMode().FillComputerEngineForm(form);

            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.Navigate().GoToUrl(YOPMAIL_URL);

            var mailPage = new YMainPage().GenerateEmail();
            string mail = mailPage.GetEmal();

            driver.SwitchTo().Window(driver.WindowHandles[0]);

            calc.AddToEstimate();
            double priceFromGC = calc.GetTotalPrice();
            calc.EmailEstimate(mail);

            driver.SwitchTo().Window(driver.WindowHandles[1]);

            double priceFromEmail = mailPage.CheckMessage().GetPriceFromMail();

            Assert.AreEqual(priceFromGC, priceFromEmail);
        }
    }
}
