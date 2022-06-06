using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverTests.Pages.YandexPages
{
    public class YandexPersonalDataPage
    {
        private IWebDriver Driver;

        private readonly By nameInput = By.XPath("//input[@data-t='field:input-firstname']");
        private readonly By lastnameInput = By.XPath("//input[@data-t='field:input-lastname']");
        private readonly By saveButton = By.XPath("//button[@class='Button2 Button2_size_l Button2_view_action Button2_type_submit']");
        private readonly By changeInformationButton = By.XPath("//div[@class='AdditionalPersonalInfo-change']//a[@class='Link Link_view_default']");
        private readonly By firstName = By.XPath("//div[@class='personal-info__first']");
        private readonly By lastName = By.XPath("//div[@class='personal-info__last']");

        public YandexPersonalDataPage(IWebDriver driver)
        {
            Driver = driver;
            WaitPageLoading();
        }

        public YandexPersonalDataPage ChangeNickName(string name, string lastname)
        {
            Waiters.WaitElementIsVisible(changeInformationButton);
            Waiters.WaitElementToBeClickable(changeInformationButton);
            Driver.FindElement(changeInformationButton).Click();

            IWebElement nameArea = Driver.FindElement(nameInput);
            nameArea.SendKeys(Keys.Control + "a" + Keys.Backspace);
            nameArea.SendKeys(name);

            IWebElement lastnameArea = Driver.FindElement(lastnameInput);
            lastnameArea.SendKeys(Keys.Control + "a" + Keys.Backspace);
            lastnameArea.SendKeys(lastname);

            Waiters.WaitElementToBeClickable(saveButton);
            Driver.FindElement(saveButton).Click();
            return this;
        }

        public string GetNickName()
        {
            Driver.Navigate().Refresh();
            Waiters.WaitElementIsVisible(firstName);
            var name = Driver.FindElement(firstName).Text;
            Waiters.WaitElementIsVisible(lastName);
            var lastname = Driver.FindElement(lastName).Text;

            return string.Concat(name, ' ', lastname);
        }

        public void WaitPageLoading()
        {
            Waiters.WaitPageLoading();
        }
    }
}
