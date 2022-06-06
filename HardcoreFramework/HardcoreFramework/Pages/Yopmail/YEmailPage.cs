using HardcoreFramework.Utils;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace HardcoreFramework.Pages.Yopmail
{
    public class YEmailPage : BasePage
    {
        private readonly By email = By.XPath("//div[@id='egen']");
        private readonly By checkInboxButton = By.XPath("//button[@onclick='egengo();']");

        Logger logger = LogManager.GetCurrentClassLogger();

        public YEmailPage() : base()
        {
            WaitPageLoading();
        }

        public string GetEmal()
        {
            Waiter.WaitElementIsVisible(email);
            string emailName = Driver.FindElement(email).Text;
            logger.Info($"Generated email: {emailName}");
            return emailName;
        }

        public YInboxPage CheckMessage()
        {
            Driver.FindElement(checkInboxButton).Click();
            return new YInboxPage();
        }

        private void WaitPageLoading()
        {
            Waiter.WaitPageLoading();
        }
    }
}
