using OpenQA.Selenium;
using WebDriverTests.Models;

namespace WebDriverTests.Pages
{
    public class YandexAutorizationPage
    {
        private IWebDriver Driver;

        private readonly By loginInput = By.XPath("//input[@name='login']");
        private readonly By passwordInput = By.XPath("//input[@type='password']");
        private readonly By enterButton = By.XPath("//div[@class='passp-button passp-sign-in-button']");
        private readonly By errorMessage = By.XPath("//div[@class='Textinput-Hint Textinput-Hint_state_error']");

        public YandexAutorizationPage(IWebDriver driver) 
        {
            Driver = driver;
            WaitPageLoading();
        }

        public YandexAutorizationPage Login(string login)
        {
            Waiters.WaitElementIsVisible(loginInput);
            Driver.FindElement(loginInput).SendKeys(login);
            Waiters.WaitElementToBeClickable(enterButton);
            Driver.FindElement(enterButton).Click();
            return this;
        }

        public YandexInboxPage Password(string password)
        {
            Waiters.WaitElementIsVisible(passwordInput);
            Driver.FindElement(passwordInput).SendKeys(password);
            Waiters.WaitElementToBeClickable(enterButton);
            Driver.FindElement(enterButton).Click();
            return new YandexInboxPage(Driver);
        }

        public YandexInboxPage LoginAs(User user)
        {
            Login(user.Login);
            return Password(user.Password);
        }

        public bool IsError()
        {
            Waiters.WaitElementIsVisible(errorMessage);
            return Driver.FindElement(errorMessage).Displayed;
        }

        public void WaitPageLoading()
        {
            Waiters.WaitPageLoading();
            Waiters.WaitElementIsVisible(loginInput);
        }
    }
}
