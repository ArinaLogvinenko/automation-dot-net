using OpenQA.Selenium;

namespace WebDriverTests.Pages.YandexPages
{
    public class YandexWriteLetterPage
    {
        private IWebDriver Driver;

        private readonly By recieverInput = By.XPath("(//div[@data-class-bubble='yabble-compose js-yabble'])[1]");
        private readonly By letterInput = By.XPath("//div[@class='cke_wysiwyg_div cke_reset cke_enable_context_menu cke_editable cke_editable_themed cke_contents_ltr cke_htmlplaceholder']");
        private readonly By sendButton = By.XPath("//button[@class='Button2 Button2_pin_circle-circle Button2_view_default Button2_size_l']");
        private readonly By closeWriteMessageWindow = By.XPath("//div[@class='ComposeDoneScreen-Actions']");

        public YandexWriteLetterPage(IWebDriver driver)
        {
            Driver = driver;
            WaitPageLoading();
        }

        public YandexWriteLetterPage TypeRecieverName(string email)
        {
            Waiters.WaitElementIsVisible(recieverInput);
            Driver.FindElement(recieverInput).Click();
            Driver.FindElement(recieverInput).SendKeys("logvinenko-arina@mail.ru");

            return this;
        }

        public YandexWriteLetterPage TypeLetter(string letter)
        {
            Waiters.WaitElementIsVisible(letterInput);
            Driver.FindElement(letterInput).SendKeys(letter);

            return this;
        }

        public YandexWriteLetterPage SendMessage()
        {
            Waiters.WaitElementToBeClickable(sendButton);
            Driver.FindElement(sendButton).Click();

            return this;
        }

        public YandexInboxPage CloseLayerWindow()
        {
            Waiters.WaitElementToBeClickable(closeWriteMessageWindow);

            Driver.FindElement(closeWriteMessageWindow).Click();

            return new YandexInboxPage(Driver);
        }

        public YandexInboxPage WriteLetter(string email, string letter)
        {
            TypeRecieverName(email);
            TypeLetter(letter);
            SendMessage();

            return CloseLayerWindow();
        }

        public void WaitPageLoading()
        {
            Waiters.WaitPageLoading();
            Waiters.WaitElementIsVisible(sendButton);
        }
    }
}
