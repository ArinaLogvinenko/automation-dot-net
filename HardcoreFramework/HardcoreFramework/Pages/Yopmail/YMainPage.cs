using HardcoreFramework.Utils;
using OpenQA.Selenium;

namespace HardcoreFramework.Pages.Yopmail
{
    public class YMainPage : BasePage
    {
        private readonly By randomEmail = By.XPath("//a[@href='email-generator']/i/..");
        public YMainPage() : base()
        {
            WaitPageLoading();
        }

        public YEmailPage GenerateEmail()
        {
            Driver.FindElement(randomEmail).Click();
            return new YEmailPage();
        }

        private void WaitPageLoading()
        {
            Waiter.WaitPageLoading();
        }
    }
}
