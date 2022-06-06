using OpenQA.Selenium;

namespace WebDriverTests.Pages
{
    public class YandexHomePage 
    {
        private IWebDriver Driver;

        private readonly By signInButton = By.XPath("//div[@class='HeadBanner-ButtonsWrapper']//span[text()='Войти']/parent::a");
        private const string path = "https://mail.yandex.by/";

        public YandexHomePage(IWebDriver driver) 
        {
            Driver = driver;

            Waiters.WaitTime = 40000;
            Waiters.Driver = Driver;

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(path);

            WaitPageLoading();
        }

        protected void WaitPageLoading()
        {
            Waiters.WaitPageLoading();
            Waiters.WaitElementIsVisible(signInButton);
        }

        public YandexAutorizationPage SignIn()
        {
            Waiters.WaitElementToBeClickable(signInButton);
            Driver.FindElement(signInButton).Click();
            return new YandexAutorizationPage(Driver);
        }
    }
}