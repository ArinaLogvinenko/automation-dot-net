using HardcoreFramework.Utils;
using OpenQA.Selenium;

namespace HardcoreFramework.Pages.GoogleCloud
{
    public class GCResultPage : BasePage
    {
        private readonly By GClink = By.XPath("//*[@class='gsc-thumbnail-inside']//div//a[@href='https://cloud.google.com/products/calculator']");

        public GCResultPage() : base()
        {
            WaitPageLoading();
        }

        public GCPricingCalculatorPage GoToCalculator()
        {
            Waiter.WaitElementIsVisible(GClink);
            var pricingCalculatorElement = Driver.FindElement(GClink);
            pricingCalculatorElement.Click();

            return new GCPricingCalculatorPage();
        }

        private void WaitPageLoading()
        {
            Waiter.WaitPageLoading();
            Waiter.WaitElementIsVisible(GClink);
        }
    }
}
