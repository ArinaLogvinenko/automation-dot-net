using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverTests.EnterData;
using WebDriverTests.Models;
using WebDriverTests.Pages;

namespace WebDriverTests
{
    public class AutorizationPageTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void CorrectLoginAndPassword_Test()
        {
            var user = new User(YandexEnterData.YandexLogin, YandexEnterData.YandexPassword);
            var homePage = new YandexHomePage(driver);
            homePage.SignIn()
                .Login(user.Login)
                .Password(user.Password);

            Assert.AreEqual(1, 1);
        }

        [Test]
        [TestCase("qwsfiuahroisdfsdfscvferlwer12344", "]'/mnbvcxsertyjklp987t--")]
        [TestCase("", "")]
        public void IncorrectLogin_ReturnTrue_Tests(string login, string password)
        {
            var user = new User(login, password);
            var homePage = new YandexHomePage(driver);
            bool condition = homePage.SignIn()
                                        .Login(user.Login)
                                        .IsError();

            Assert.IsTrue(condition);
        }

        [Test]
        [TestCase(YandexEnterData.YandexLogin, "]'/mnbvcxsertyjklp987t--")]
        [TestCase(YandexEnterData.YandexLogin, "")]
        public void IncorrectPassword_ReturnTrue_Tests(string login, string password)
        {
            var user = new User(login, password);
            var homePage = new YandexHomePage(driver);
            bool condition = homePage.SignIn()
                                        .Login(user.Login)
                                        .Password(user.Password)
                                        .IsError();

            Assert.IsTrue(condition);
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}