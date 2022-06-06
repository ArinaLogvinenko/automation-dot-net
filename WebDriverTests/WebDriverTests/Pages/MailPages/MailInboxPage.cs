using OpenQA.Selenium;

namespace WebDriverTests.Pages.MailPages
{
    public class MailInboxPage
    {
        private IWebDriver Driver;

        private readonly By incomingLetters = By.XPath("//div[text()='Входящие']");
        private readonly By lastIncomingLetter = By.XPath("(//span[@class='ll-crpt'])[1]");
        private readonly By notReadedIcon = By.XPath("//span[@class='ll-rs ll-rs_is-active ll-rs_dotSize_small']");

        public MailInboxPage(IWebDriver driver)
        {
            Driver = driver;

            WaitPageLoading();
        }

        public bool IsNotReadedLastIncomingLetter()
        {
            Waiters.WaitVisabilityOfAllElementLocatedBy(incomingLetters);
            return Driver.FindElement(notReadedIcon).Displayed;
        }

        public MailLetterPage OpenLastIncomingLetter()
        {
            Waiters.WaitVisabilityOfAllElementLocatedBy(incomingLetters);
            Waiters.WaitElementIsVisible(lastIncomingLetter);
            Driver.FindElement(lastIncomingLetter).Click();           

            return new MailLetterPage(Driver);
        }

        public MailInboxPage UpdateLetters()
        {
            Driver.Navigate().Refresh();
            Waiters.WaitElementIsVisible(notReadedIcon);
            return this;
        }

        public void WaitPageLoading()
        {
            Waiters.WaitPageLoading();
        }
    }
}
