using OpenQA.Selenium;
namespace WebDriverTests.Pages.YandexPages
{
    public class YandexAccountPage
    {
        private IWebDriver Driver;

        private readonly By changePersonalDataButton = By.XPath("//div[@class='AdditionalPersonalInfo-change']");
        public YandexAccountPage(IWebDriver driver)
        {
            Driver = driver;
            WaitPageLoading();
        }

        public YandexPersonalDataPage OpenPersonalDataPage()
        {
            Waiters.WaitElementToBeClickable(changePersonalDataButton);
            Driver.FindElement(changePersonalDataButton).Click();

            return new YandexPersonalDataPage(Driver);
        }

        public void WaitPageLoading()
        {
            Waiters.WaitPageLoading();
        }
    }
}
