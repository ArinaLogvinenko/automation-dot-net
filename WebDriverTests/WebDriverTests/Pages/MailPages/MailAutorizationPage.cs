using OpenQA.Selenium;
using System.Threading;
using WebDriverTests.Models;

namespace WebDriverTests.Pages.MailPages
{
    public class MailAutorizationPage
    {
        private IWebDriver Driver;

        private readonly string path = "https://account.mail.ru/";
        private readonly By loginInput = By.XPath("//input[@name='username']");
        private readonly By passwordInput = By.XPath("//input[@name='password']");
        private readonly By enterButton = By.XPath("//button[@class='base-0-2-87 primary-0-2-101 auto-0-2-113']");
        private readonly By errorMessage = By.XPath("//div[@class='EjBTad']");

        public MailAutorizationPage(IWebDriver driver)
        {
            Driver = driver;

            Waiters.WaitTime = 40000;
            Waiters.Driver = Driver;

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(path);

            WaitPageLoading();
        }

        public MailAutorizationPage Login(string login)
        {
            Waiters.WaitElementIsVisible(loginInput);
            Driver.FindElement(loginInput).SendKeys(login);
            Waiters.WaitElementToBeClickable(enterButton);
            Driver.FindElement(enterButton).Click();

            return this;
        }

        public MailInboxPage Password(string password)
        {
            Waiters.WaitElementIsVisible(passwordInput);
            Driver.FindElement(passwordInput).SendKeys(password);
            Waiters.WaitElementToBeClickable(enterButton);
            Driver.FindElement(enterButton).Click();

            return new MailInboxPage(Driver);
        }

        public MailInboxPage LoginAs(User user)
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
