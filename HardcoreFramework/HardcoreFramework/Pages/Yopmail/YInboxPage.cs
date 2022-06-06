using HardcoreFramework.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace HardcoreFramework.Pages.Yopmail
{
    public class YInboxPage : BasePage
    {
        private readonly By priceFromMailLocator = By.XPath("//*[contains(text(),'Estimated Bill')]/following-sibling::*[contains(text(),'Monthly')]");
        private readonly By frameWithMailLocator = By.Id("ifmail");
        private readonly By refreshButtonLocator = By.Id("refresh");

        private IWebElement priceFromMail;

        public YInboxPage() : base()
        {
            WaitPageLoading();
        }

        public double GetPriceFromMail()
        {
            int count = 0;
            while (count < 10)
            {
                try
                {
                    Driver.SwitchTo().Frame(Driver.FindElement(frameWithMailLocator));
                    Waiter.WaitElementIsVisible(priceFromMailLocator);
                    priceFromMail = Driver.FindElement(priceFromMailLocator);
                    break;
                }
                catch
                {
                    Driver.SwitchTo().DefaultContent();
                    Driver.FindElement(refreshButtonLocator).Click();
                    count++;
                }
            }
            string message = priceFromMail.Text;
            int first = message.IndexOf('D') + 1;
            message.Replace(",", "");

            Driver.SwitchTo().DefaultContent();

            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            return double.Parse(message.Substring(first), formatter);
        }

        private void WaitPageLoading()
        {
            Waiter.WaitPageLoading();
        }

    }
}
