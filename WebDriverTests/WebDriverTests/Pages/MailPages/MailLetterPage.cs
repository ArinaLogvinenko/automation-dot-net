using OpenQA.Selenium;

namespace WebDriverTests.Pages.MailPages
{
    public class MailLetterPage
    {
        private IWebDriver Driver;

        private readonly By senderEmail = By.XPath("(//span[@class='letter-contact letter-contact_pony-mode'])[1]");
        private readonly By showInformationButton = By.XPath("(//span[@class='letter-contact letter-contact_pony-mode'])[1]");
        private readonly By letterText = By.XPath("//div[@class='letter__body']");
        private readonly By answerButton = By.XPath("(//span[@title='Ответить'])[2]");
        private readonly By answerInput = By.XPath("//br/parent::div");
        private readonly By sendButton = By.XPath("//span[text()='Отправить']");
        private readonly By layerWindow = By.XPath("//a[@class='layer__link']");

        public MailLetterPage(IWebDriver driver)
        {
            Driver = driver;
            WaitPageLoading();
        }

        public string GetSenderEmail()
        {
            return Driver.FindElement(senderEmail).GetAttribute("title");
        }

        public string GetLetterText()
        {
            Waiters.WaitElementIsVisible(letterText);
            return Driver.FindElement(letterText).Text;
        }

        public MailLetterPage ReplyLetterButton()
        {
            Waiters.WaitElementToBeClickable(answerButton);
            Driver.FindElement(answerButton).Click();
            return this;
        }

        public MailLetterPage ReplyLetterInputText(string letterText)
        {
            Waiters.WaitElementIsVisible(answerInput);
            Driver.FindElement(answerInput).SendKeys(letterText);
            return this;
        }

        public MailLetterPage SendLetterButton()
        {
            Waiters.WaitElementToBeClickable(sendButton);
            Driver.FindElement(sendButton).Click();
            Waiters.WaitElementIsVisible(layerWindow);

            return this;
        }

        public MailLetterPage ReplyLetter(string letterText)
        {
            ReplyLetterButton();
            ReplyLetterInputText(letterText);
            SendLetterButton();

            return this;
        }

        public void WaitPageLoading()
        {
            Waiters.WaitPageLoading();
            Waiters.WaitElementIsVisible(showInformationButton);
        }
    }
}
