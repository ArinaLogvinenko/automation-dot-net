using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverTests.EnterData;
using WebDriverTests.Models;
using WebDriverTests.Pages;
using WebDriverTests.Pages.MailPages;

namespace WebDriverTests.Tests
{
    public class SendLetterTests
    {
        private IWebDriver driver;
        public User validMailUser;
        public User validYandexUser;
        public Letter sendLetter;
        public Letter replyLetter;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            validMailUser = new User(MailEnterData.MailLogin, MailEnterData.MailPassword);
            validYandexUser = new User(YandexEnterData.YandexLogin, YandexEnterData.YandexPassword, YandexEnterData.YandexAddress);
            sendLetter = new Letter(MailEnterData.MailLogin, "Hello!");
            replyLetter = new Letter("arinalogvinenko9@yandex.ru", "Aria Log");
        }

        [Test]
        [Order(1)]
        public void IsNotRead_CorrectSender_CorrectLetter_Tests()
        {
            var yandex = new YandexHomePage(driver).SignIn().LoginAs(validYandexUser)
                .OpenWriteALetterPage()
                .WriteLetter(sendLetter.EmailReciever, sendLetter.LettersText);

            var mail = new MailAutorizationPage(driver).LoginAs(validMailUser);

            bool isNotRead = mail.UpdateLetters().IsNotReadedLastIncomingLetter();

            Assert.IsTrue(isNotRead);

            var openInbox = mail.OpenLastIncomingLetter();

            string text = openInbox.GetLetterText();
            Assert.AreEqual(sendLetter.LettersText, text);

            string email = openInbox.GetSenderEmail();
            Assert.AreEqual(validYandexUser.Address, email);

            openInbox.ReplyLetter(replyLetter.LettersText);
        }

        [Test]
        [Order(2)]
        public void ChangeNickName_Test()
        {
            var yandex = new YandexHomePage(driver).SignIn().LoginAs(validYandexUser);

            string nickName = yandex.UpdateLetters().OpenLastIncomingLetter().GetTextInLetter();

            string name = nickName.Split(' ', 2)[0];
            string lastname = nickName.Split(' ', 2)[1];

            string newNickname = yandex.OpenPersonalData().ChangeNickName(name, lastname).GetNickName();

            Assert.AreEqual(nickName, newNickname);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
