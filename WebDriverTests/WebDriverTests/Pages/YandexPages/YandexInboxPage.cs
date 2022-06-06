using OpenQA.Selenium;
using WebDriverTests.Pages.YandexPages;

namespace WebDriverTests.Pages
{
    public class YandexInboxPage
    {
        private IWebDriver Driver;

        private readonly By errorMessage = By.XPath("//div[@class='Textinput-Hint Textinput-Hint_state_error']");
        private readonly By writeMessageButton = By.XPath("//a[@class='mail-ComposeButton js-main-action-compose']");
        private readonly By incomingLetter = By.XPath("(//span[@class='mail-MessageSnippet-Item mail-MessageSnippet-Item_sender js-message-snippet-sender'])[1]");
        private readonly By lastIncomingLetter = By.XPath("(//span[@class='mail-MessageSnippet-Item mail-MessageSnippet-Item_sender js-message-snippet-sender'])[2]");
        private readonly By letterText = By.XPath("(//div[@class='MessageBody_body_pmf3j react-message-wrapper__body']/div)[1]");
        private readonly By accountButton = By.XPath("//a[@class='user-account user-account_left-name user-account_has-ticker_yes user-account_has-accent-letter_yes count-me legouser__current-account legouser__current-account i-bem']");
        private readonly By accountManageButton = By.XPath("//a[@class='menu__item menu__item_type_link count-me legouser__menu-item legouser__menu-item_action_passport legouser__menu-item legouser__menu-item_action_passport']");
        private readonly By updateButton = By.XPath("//span[@class='mail-ComposeButton-Refresh js-main-action-refresh ns-action']");
        public YandexInboxPage(IWebDriver driver) 
        {
            Driver = driver;
            WaitPageLoading();
        }

        public bool IsError()
        {
            Waiters.WaitElementIsVisible(errorMessage);
            return Driver.FindElement(errorMessage).Displayed;
        }

        public YandexWriteLetterPage OpenWriteALetterPage()
        {
            Waiters.WaitElementToBeClickable(writeMessageButton);
            Driver.FindElement(writeMessageButton).Click();

            return new YandexWriteLetterPage(Driver);
        }

        public YandexInboxPage OpenLastIncomingLetter()
        {
            Waiters.WaitElementIsVisible(incomingLetter);
            Driver.FindElement(incomingLetter).Click();
            Waiters.WaitElementIsVisible(lastIncomingLetter);
            Driver.FindElement(lastIncomingLetter).Click();

            return this;
        }

        public YandexAccountPage OpenAccount()
        {
            Waiters.WaitElementToBeClickable(accountButton);
            Driver.FindElement(accountButton).Click();
            Waiters.WaitElementToBeClickable(accountManageButton);
            Driver.FindElement(accountManageButton).Click();

            return new YandexAccountPage(Driver);
        }

        public string GetTextInLetter()
        {
            Waiters.WaitElementIsVisible(letterText);
            return Driver.FindElement(letterText).Text.Trim();
        }

        public YandexPersonalDataPage OpenPersonalData()
        {
            Waiters.WaitElementToBeClickable(accountButton);
            Driver.FindElement(accountButton).Click();
            Waiters.WaitElementToBeClickable(accountManageButton);
            Driver.FindElement(accountManageButton).Click();

            return new YandexPersonalDataPage(Driver);
        }

        public YandexInboxPage UpdateLetters()
        {
            Waiters.WaitElementToBeClickable(updateButton);
            Driver.FindElement(updateButton).Click();
            return this;
        }

        public void WaitPageLoading()
        {
            Waiters.WaitPageLoading();
        }
    }
}
